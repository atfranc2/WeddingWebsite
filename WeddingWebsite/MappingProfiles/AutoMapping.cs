using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Dtos;
using WeddingWebsite.Models;

namespace WeddingWebsite.MappingProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Guest, GuestDto>(); 
            CreateMap<GuestDto, Guest>();

            CreateMap<Couple, CoupleDto>();
            CreateMap<CoupleDto, Couple>();
        }
    }
}
