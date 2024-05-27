using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IBookingRepository
    {
        Task<Entities.Booking> Get(int id);
        Task<Entities.Booking> CreateBooking(Entities.Booking booking);
    }
}
