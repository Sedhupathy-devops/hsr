using AutoMapper;
using ICS.DAL.DTOs;
using ICS.Services.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Services.MapperProfiles
{
    public class DropdownListMappingProfile: Profile
    {
        public DropdownListMappingProfile()
        {
            CreateMap<DropdownList, DropdownListDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
