// using Stripe.Checkout;
using StoreAPI.Utils;

namespace StoreAPI.Services
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}