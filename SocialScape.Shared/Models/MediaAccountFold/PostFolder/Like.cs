using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialScape.Shared.Models.MediaAccountFold.PostFolder
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int MediaAccountId { get; set; }
        public MediaAccount MediaAccount { get; set; }
    }
}
