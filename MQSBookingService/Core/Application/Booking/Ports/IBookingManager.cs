using Application.Booking.DTO;
using Application.Payment;
using static Application.Booking.DTO.PaymentRequestDTO;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(BookingDTO booking);
        Task<PaymentResponse> PayForABooking(PaymentRequestDto paymentRequestDTO);
        Task<BookingDTO> GetBooking(int id);
    }
}
