using Com.Common;
using Com.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Com.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfig(modelBuilder.Entity<User>());
            new AddressConfig(modelBuilder.Entity<Address>());
            new AdsConfig(modelBuilder.Entity<Ad>());

            // Types config
            new TypeConfig<AddressTypes, AddressType>(modelBuilder.Entity<AddressType>());
            new TypeConfig<UserTypes, UserType>(modelBuilder.Entity<UserType>());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entity in ChangeTracker.Entries().Where(en => en.State == EntityState.Added || en.State == EntityState.Modified))
            {
                if (entity.Metadata.FindProperty("ModifiedDate") != null)
                {
                    entity.Property("ModifiedDate").CurrentValue = DateTime.Now;
                }

                if (entity.Metadata.FindProperty("AddedDate") != null && entity.State == EntityState.Added)
                {
                    entity.Property("AddedDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
