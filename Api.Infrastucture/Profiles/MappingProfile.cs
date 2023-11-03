using Api.Infrastructure.Dto;
using Api.Infrastructure.Entities;
using AutoMapper;

namespace Api.Infrastructure.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EntityDto, Entity>();
    }
}