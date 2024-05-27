using static Application.Booking.DTO.PaymentRequestDTO;

namespace Application.Payment.Ports
{
    public interface IPaymentProcessorFactory
    {
        IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider);
    }
}
