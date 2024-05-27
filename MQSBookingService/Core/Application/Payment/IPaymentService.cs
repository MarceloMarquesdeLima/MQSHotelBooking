using Application.Payment.DTOS;

namespace Application.Payment
{
    public interface IPaymentService
    {
        Task<PaymentStateDTO> PayWithCreditCard(string paymentIntention);
        Task<PaymentStateDTO> PayWithDebeditCard(string paymentIntention);
        Task<PaymentStateDTO> PayWithTransfer(string paymentIntention);
    }
}
