using BaumKantin.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaumKantin.Repository.Seeds
{
    public class CustomerSeed:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer 
            { Id=1,IdentityId = null, UserTypeEnum = 0,Name="Sanem",Phone="0998877", Rooms = null});
        }
    }
}
