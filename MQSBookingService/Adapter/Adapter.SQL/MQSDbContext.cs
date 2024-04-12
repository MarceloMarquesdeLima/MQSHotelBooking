using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Adapter.SQL
{
	public class MQSDbContext : DbContext
	{
		public MQSDbContext(DbContextOptions<MQSDbContext>options) : base(options)	{ }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>();
        }*/

        public virtual DbSet<Entities.Guest> Guests { get; set; }
	}
}

