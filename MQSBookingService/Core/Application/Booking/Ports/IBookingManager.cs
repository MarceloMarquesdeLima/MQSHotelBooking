using Application.Booking.DTO;
using Application.Payment;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(BookingDTO booking);
        Task<PaymentResponse> PayForABooking(PaymentRequestDTO paymentRequestDTO);
        Task<BookingDTO> GetBooking(int id);
    }
}
