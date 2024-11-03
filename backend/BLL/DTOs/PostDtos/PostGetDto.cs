using Businness.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.DTOs.PostDtos
{
    public class PostGetDto
    {
        public int PostId { get; set; }
        public string PostCaption { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Image { get; set; }
        public string Location { get; set; }
        public string UserId { get; set; }
        public List<UserLikeDto> Likes { get; set; }
    }
}
