using Application;
using Application.Payment;
using Application.Payment.DTOS;
using Application.Payment.Ports;
using Domain.Enums;
using PaymentApplication.MercadoPago.Exceptions;

namespace PaymentApplication.MercadoPago
{
    public class MercadoPagoAdapter : IPaymentProcessor
    {
        public Task<PaymentResponse> CapturePayment(string paymentIntention)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(paymentIntention))
                {
                    throw new InvalidPaymentIntentionException();
                }

                paymentIntention += "/success";

                var dto = new PaymentStateDTO
                {
                    CreatedDate = DateTime.Now,
                    Message = $"Successfully paid {paymentIntention}",
                    PaymentId = "123",
                    Status = (Application.Payment.Enums.StatusEnum)Status.Success
                };

                var response = new PaymentResponse
                {
                    Data = dto,
                    Success = true,
                    Message = "Payment successfully processed"
                };

                return Task.FromResult(response);
            }
            catch (InvalidPaymentIntentionException)
            {
                var resp = new PaymentResponse()
                {
                    Success = false,
                    ErrorCode = ErrorCodes.PAYMENT_INVALID_PAYMENT_INTENTION,
                    Message = "The selected payment intention is invalid"
                };
                return Task.FromResult(resp);
            }
        }
    }
}

