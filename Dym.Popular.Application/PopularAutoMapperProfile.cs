using AutoMapper;
using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.Entities.Mis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dym.Popular.Application
{
    public class PopularAutoMapperProfile : Profile
    {
        public PopularAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<VehicleEntity, VehicleDto>();
            CreateMap<VehicleEntity, VehicleExportDto>();
            CreateMap<VehicleDto, VehicleEntity>();

            CreateMap<DriverEntity, DriverDto>();
            CreateMap<VehicleDto, VehicleEntity>();
        }
    }
}
