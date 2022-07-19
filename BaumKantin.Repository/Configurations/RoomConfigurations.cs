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
            //CONFIGURE NULLABLE PROPERTIES
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Number).IsRequired().HasMaxLength(50);
            builder.ToTable("Rooms");
        }
    }

}
