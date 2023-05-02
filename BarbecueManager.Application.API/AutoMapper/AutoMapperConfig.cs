using AutoMapper;
using BarbecueManager.Application.API.Dtos;
using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Application.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Person, PersonsDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<Barbecue, BarbecuesDto>();
            CreateMap<BarbecueDto, Barbecue>();
        }
    }
}
