using Application.Booking.DTO;
using MediatR;

namespace Application.Booking.Commands
{
    public class CreateBookingCommand : IRequest<BookingResponse>
    {
        public BookingDTO BookingDTO { get; set; }
    }
}
