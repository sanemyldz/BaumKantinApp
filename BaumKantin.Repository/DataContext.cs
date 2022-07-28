using BaumKantin.Core;
using BaumKantin.Core.Models;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BaumKantin.Repository
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public readonly IUnitOfWork _UnitOfWork;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguraitons());
            builder.ApplyConfiguration(new RoomConfigurations());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = this.ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added)
                                   .Select(x => x.Entity);

            foreach (var entityEntry in entries)
            {
                var auditableEntity = entityEntry as BaseEntity;

                if (auditableEntity != null)
                {
                    auditableEntity.CreateDate = DateTime.Now;
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                var auditableEntity = modifiedEntry as BaseEntity;
                if (auditableEntity != null)
                {
                    auditableEntity.UpdateDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync();
        }
    }
}

