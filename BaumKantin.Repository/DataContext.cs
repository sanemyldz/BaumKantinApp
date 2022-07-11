using BaumKantin.Core;
using BaumKantin.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BaumKantin.Repository
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguraitons());
            builder.ApplyConfiguration(new RoomConfigurations());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
