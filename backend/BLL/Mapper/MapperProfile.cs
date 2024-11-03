using AutoMapper;
using Businness.DTOs.AppUserDtos;
using Businness.DTOs.PostDtos;
using Businness.DTOs.SaveDtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser,UserFullDto>().ReverseMap();
            CreateMap<Post,PostGetDto>().ReverseMap();
            CreateMap<Post, PostLikeDto>().ReverseMap();
            CreateMap<Save, SaveGetDto>().ReverseMap();
        }
    }
}
