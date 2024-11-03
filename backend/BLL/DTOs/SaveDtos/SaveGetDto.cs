using Businness.DTOs.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.DTOs.SaveDtos
{
    public class SaveGetDto
    {
        public int SaveId { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; } 
        public PostGetDto Post { get; set; }    
    }
}
