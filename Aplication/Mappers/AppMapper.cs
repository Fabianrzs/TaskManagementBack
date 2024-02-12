using Aplication.Mappers;
using AutoMapper;
using Domain.Entities;

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
        }
    }
}
