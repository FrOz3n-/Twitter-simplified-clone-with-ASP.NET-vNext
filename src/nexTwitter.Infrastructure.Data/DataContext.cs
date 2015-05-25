using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using nexTwitter.Domain.Entities;
using nexTwitter.Domain;
using System.Threading;
using Microsoft.Data.Entity.Relational.Metadata;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.ModelConventions;
using Microsoft.Framework.ConfigurationModel;

namespace nexTwitter.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        private IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<UserWithTweet> UsersWithTweets { get; set; }
        public DbSet<UserWithFollower> UsersWithFollowers { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                BaseEntity entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    //NOT SUPPORTED IN .NET 5.0 CORE
                    //string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        //entity.CreatedBy = identityName;
                        entity.DateCreated = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.DateCreated).IsModified = false;
                    }

                    //entity.UpdatedBy = identityName;
                    entity.LastModified = now;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Key(x => x.Id);
            builder.Entity<Tweet>().Key(x => x.Id);
            builder.Entity<UserWithTweet>().Key(x => x.Id);
            builder.Entity<UserWithFollower>().Key(x => x.Id);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=FROZ3N-PC;Initial Catalog=nexTwitter;Integrated Security=True;");
        }

    }
}
