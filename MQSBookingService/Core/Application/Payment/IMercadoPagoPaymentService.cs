using Application.Payment.DTOS;

namespace Application.Payment
{
    public interface IMercadoPagoPaymentService
    {
        Task<PaymentStateDTO> MercadoPagoPayWithCreditCard(string paymentIntention);
        Task<PaymentStateDTO> MercadoPagoPayWithDebeditCard(string paymentIntention);
        Task<PaymentStateDTO> MercadoPagoPayWithTransfer(string paymentIntention);
    }
}
