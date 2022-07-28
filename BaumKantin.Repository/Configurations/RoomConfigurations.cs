using BaumKantin.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaumKantin.Repository.Configurations
{
    internal class RoomConfigurations : IEntityTypeConfiguration<Room> 
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //TODO
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Rooms");
        }
    }

}
