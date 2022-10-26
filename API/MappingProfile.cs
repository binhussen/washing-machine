using API.Entity;
using API.Entity.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http.Headers;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Machine, MachineDto>();
            CreateMap<Time, TimeDto>();
            CreateMap<MachineDto,Machine >();
            CreateMap<TimeDto,Time>();
        }
    }
}
