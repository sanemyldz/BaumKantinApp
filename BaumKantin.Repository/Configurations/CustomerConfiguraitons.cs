using BaumKantin.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaumKantin.Repository.Configurations
{
    internal class CustomerConfiguraitons:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //TODO
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Customers");
        }
    }
}
