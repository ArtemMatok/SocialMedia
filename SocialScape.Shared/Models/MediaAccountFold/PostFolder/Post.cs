using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialScape.Shared.Models.MediaAccountFold.PostFolder
{
    public class Post
    {
        public int PostId { get; set; }
        public int MediaAccountId { get; set; } 
        public MediaAccount MediaAccount { get; set; }
        [Required(ErrorMessage ="You need to write a title")]
        public string Title { get; set; }
        public string Photo { get; set; }
        public List<Like> Likes { get; set; } = new List<Like>();

    }
}
