using Aplication.Mappers;
using AutoMapper;
using Domain.Entities;
using WebApi.Commons;

namespace Aplication.Dtos
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<SampleDto, SampleEntity>()
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ReverseMap();
            CreateMap<TaskEntity, TaskEntityDto>()
                .ReverseMap();
            CreateMap<Project, ProjectDto>()
                .ReverseMap();
            CreateMap<Collaborator, CollaboratorDto>()
                .ReverseMap();
            CreateMap<Comment, CommentDto>()
                .ReverseMap();
            CreateMap<User, TokenClaims>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();

        }
    }
}
