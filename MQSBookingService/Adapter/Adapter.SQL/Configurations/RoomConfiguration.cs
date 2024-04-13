using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQL.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Price)
                .Property(x => x.Currency);
            builder.OwnsOne(x => x.Price)
                .Property(x => x.Value);
        }
    }
}
