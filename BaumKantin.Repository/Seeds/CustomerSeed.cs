using BaumKantin.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaumKantin.Repository.Seeds
{
    public class CustomerSeed:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //TODO : seed data
        }
    }
}
