using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialScape.Shared.Models.MediaAccountFold;



namespace SocialScape.Server.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }

        public DbSet<MediaAccount> MediaAccounts { get; set; }  
        
    }
}
