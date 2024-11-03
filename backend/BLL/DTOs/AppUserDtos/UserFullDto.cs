using Businness.DTOs.PostDtos;
using Businness.DTOs.SaveDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.DTOs.AppUserDtos
{
    public class UserFullDto
    {
        public string Id { get; set; } 
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public List<PostGetDto> Posts { get; set; } 
        public List<PostLikeDto> LikedPosts { get;set; }
        public List<SaveGetDto> Saves { get; set; }


    }
}
