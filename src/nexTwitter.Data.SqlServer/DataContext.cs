using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using nexTwitter.Domain.Entities;
using nexTwitter.Domain;
using System.Threading;

namespace nexTwitter.Infrastructure.Data
{
    public class DataContext : DbContext
    {
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


    }
}
