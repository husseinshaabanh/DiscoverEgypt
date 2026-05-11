using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Nationalities.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class NationalityProfile : Profile
    {
        public NationalityProfile()
        {
            CreateMap<Nationality, NationalityDto>();
            CreateMap<CreateNationalityDto, Nationality>();
        }
    }
}