using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialScape.Shared.Models.MediaAccountFold;
using SocialScape.Shared.Models.MediaAccountFold.PostFolder;



namespace SocialScape.Server.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }

       

        public DbSet<MediaAccount> MediaAccounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> PostLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>()
                .HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
