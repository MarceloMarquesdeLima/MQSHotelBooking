using Application.Payment;
using Application.Payment.DTOS;
using PaymentApplication.MercadoPago.Exceptions;

namespace PaymentApplication.MercadoPago
{
    public class MercadoPagoAdapter : IMercadoPagoPaymentService
    {
        public Task<PaymentStateDTO> MercadoPagoPayWithCreditCard(string paymentIntention)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentStateDTO> MercadoPagoPayWithDebeditCard(string paymentIntention)
        {
            if (string.IsNullOrWhiteSpace(paymentIntention))
            {
                throw new InvalidPaymentIntentionException();
            }

            paymentIntention += "Success";

            var dto = new PaymentStateDTO
            {
                CreateDate = DateTime.Now,
                Message = $"SuccessFally paid {paymentIntention}",
                PaymentId = "123",
                Status = Application.Payment.Enums.StatusEnum.Success,
            };

            return Task.FromResult(dto);
        }

        public Task<PaymentStateDTO> MercadoPagoPayWithTransfer(string paymentIntention)
        {
            throw new NotImplementedException();
        }
    }
}
