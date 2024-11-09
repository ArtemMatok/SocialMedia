
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monix.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Image { get; set; } = String.Empty;
        public string Bio { get; set; } = String.Empty;

        //Relation
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Post> LikedPosts { get; set; } = new List<Post>();
        public List<Save> Saves { get; set; } = new List<Save>();
    }
}
