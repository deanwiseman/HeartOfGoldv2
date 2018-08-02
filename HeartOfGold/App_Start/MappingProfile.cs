using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HeartOfGold.Models;
using HeartOfGold.Dtos;

namespace HeartOfGold.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping the domain models to data transfer objects
            Mapper.CreateMap<Item, DonationDto>();

            // Mapping the data transfer objects to the domain
            Mapper.CreateMap<DonationDto, Item>().ForMember(i => i.Id, opt => opt.Ignore());
        }
    }
}