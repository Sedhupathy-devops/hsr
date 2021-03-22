using AutoMapper;
using ICS.DAL.DTOs;
using ICS.Services.Entities;
using ICS.Services.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICS.Services.MapperProfiles
{
    public class UserTypeMappingProfile: Profile
    {
        public UserTypeMappingProfile()
        {
            CreateMap<UserTypeInputModel, UserTypeDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap();
        }
    }
}
