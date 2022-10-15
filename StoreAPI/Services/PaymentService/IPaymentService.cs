using StoreAPI.Utils;
using Stripe.Checkout;

namespace StoreAPI.Services
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}