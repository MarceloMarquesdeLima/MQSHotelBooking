using Application.Payment.DTOS;

namespace Application.Payment
{
    public interface IStripePaymentService
    {
        Task<PaymentStateDTO> StripePayWithCreditCard(string paymentIntention);
        Task<PaymentStateDTO> StripePayWithDebeditCard(string paymentIntention);
        Task<PaymentStateDTO> StripePayWithTransfer(string paymentIntention);
    }
}
