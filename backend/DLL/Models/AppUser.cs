using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Image { get; set; } = "https://www.shutterstock.com/image-vector/blank-avatar-photo-place-holder-600nw-1095249842.jpg";
        public string Bio { get; set; } = String.Empty;

        //Relation
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Post> LikedPosts { get; set; } = new List<Post>();
        public List<Save> Saves { get; set; } = new List<Save>();
    }
}
