using Application.Payment.Enums;

namespace Application.Payment.DTOS
{
    public class PaymentStateDTO
    {
        public StatusEnum Status { get; set; }
        public string PaymentId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
