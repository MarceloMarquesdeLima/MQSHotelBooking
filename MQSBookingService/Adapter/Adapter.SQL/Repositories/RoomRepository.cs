using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private MQSDbContext _context;
        public RoomRepository(MQSDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Domain.Entities.Room room)
        {
            _context.Roons.Add(room);
            await _context.SaveChangesAsync();
            return room.Id;
        }

        public Task<Domain.Entities.Room> Get(int Id)
        {
            return _context.Roons
                .Where(g => g.Id == Id).FirstOrDefaultAsync();
        }

        public Task<Domain.Entities.Room> GetAggregate(int Id)
        {
            return _context.Roons
                .Include(r => r.Bookings)
                .Where(g => g.Id == Id).FirstAsync();
        }
    }
}
