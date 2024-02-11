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
        }
    }
}
