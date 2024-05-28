using Application.Booking.DTO;
using Application.Payment.Ports;
using PaymentApplications.MercadoPago;
using static Application.Booking.DTO.PaymentRequestDTO;

namespace PaymentsApplication
{
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        public IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider)
        {
            switch (selectedPaymentProvider)
            {
                case SupportedPaymentProviders.MercadoPago:
                    return new MercadoPagoAdapter();

                default: return new NotImplementedPaymentProvider();
            }
        }
    }
}
