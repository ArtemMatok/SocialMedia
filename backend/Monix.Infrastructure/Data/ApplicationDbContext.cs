using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monix.Domain.Entities;
using Monix.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Save> Saves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Post>()
                .HasIndex(x => x.PostCaption);

            builder.Entity<Post>()
                .HasMany(x => x.Likes)
                .WithMany(u => u.LikedPosts)
                .UsingEntity(x => x.ToTable("UserLikePost"));

            builder.Entity<AppUser>()
                .HasMany(x => x.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
