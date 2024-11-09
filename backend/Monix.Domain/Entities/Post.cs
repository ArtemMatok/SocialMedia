using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostCaption { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Image { get; set; }
        public string Location { get; set; }

        //Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<AppUser> Likes { get; set; } = new List<AppUser>();
        public List<Save> Saves { get; set; } = new List<Save>();
    }
}
