using Microsoft.AspNetCore.Authentication.JwtBearer;
using StoreAPI.Utils;
using StoreAPI.Models;
using StoreAPI.Services;
using Stripe;
using Stripe.Checkout;

namespace StoreAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "whsec_f805a6ec3cf411e6009bf9223cd93b58d5e462707ebecf9564232d9c3903e169";

        public PaymentService(
            ICartService cartService,
            IAuthService authService,
            IOrderService orderService
        )
        {
            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products!.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.ProductName,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "US" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "http://localhost:3000/checkout/order-success",
                CancelUrl = "http://localhost:3000/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session!.CustomerEmail);
                    var address = session.ShippingDetails.Address;
                    var addressLine1 = address.Line1 != string.Empty || address.Line1 != null ? address.Line1 + ", " : "";
                    // var addressLine2 = address.Line2 != string.Empty || address.Line2 != null ? address.Line2 + ", " : "";
                    var city = address.City != string.Empty || address.City != null ? address.City + ", " : "";
                    var country = address.Country != string.Empty || address.Country != null ? address.Country : "";
                    var shipAddress = $"{addressLine1}{city}{country}";

                    await _orderService.PlaceOrder(user!.UserId, shipAddress);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}