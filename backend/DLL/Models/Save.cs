using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Save
    {
        public int SaveId { get; set; }

        //Relation
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int PostId { get; set; } 
        public Post Post { get; set; }  
    }
}
