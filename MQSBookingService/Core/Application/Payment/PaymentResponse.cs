using Application.Payment.DTOS;

namespace Application.Payment
{
    public class PaymentResponse : Response
    {
        public PaymentStateDTO Data { get; set; }
    }
}
