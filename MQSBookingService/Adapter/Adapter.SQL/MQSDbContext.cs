using Adapter.SQL.Configurations;
using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Adapter.SQL
{
	public class MQSDbContext : DbContext
	{
        public MQSDbContext(DbContextOptions<MQSDbContext> options) : base(options) { }

        public virtual DbSet<Entities.Guest> Guests { get; set; }
		public virtual DbSet<Entities.Room> Rooms { get; set; }
		public virtual DbSet<Entities.Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}

