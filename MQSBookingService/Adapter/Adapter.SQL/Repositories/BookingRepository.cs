using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private MQSDbContext _context;
        public BookingRepository(MQSDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Booking> CreateBooking(Domain.Entities.Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public Task<Domain.Entities.Booking> Get(int id)
        {
            return _context.Bookings.Include(b => b.Guest).Include(b => b.Room).Where(x => x.Id == id).FirstAsync();
        }
    }
}
