using BaumKantin.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaumKantin.Repository.Seeds
{
    public class RoomSeed:IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //builder.HasData(
            //    new Room { Id = 1, Floor = "1", Number = "206"
            //    });
        }
    }
}
