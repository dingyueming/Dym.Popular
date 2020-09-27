using AutoMapper;
using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application
{
    public class PopularAutoMapperProfile : Profile
    {
        public PopularAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
