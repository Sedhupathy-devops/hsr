using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Mappers;
using ICS.DAL.DTOs;
using ICS.Services.Entities;
using ICS.Services.Entities.Models;

namespace ICS.Services.MapperProfiles
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserInputModel, UserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.User_Type_Id, opt => opt.MapFrom(src => src.User_Type_Id))
            .ForMember(dest => dest.User_Role_Id, opt => opt.MapFrom(src => src.User_Role_Id))
            .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
            .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Password_Updated_On, opt => opt.MapFrom(src => src.Password_Updated_On))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.IsLocked, opt => opt.MapFrom(src => src.IsLocked))
            .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.Created_By))
            .ForMember(dest => dest.Created_On, opt => opt.MapFrom(src => src.Created_On))
            .ForMember(dest => dest.Updated_By, opt => opt.MapFrom(src => src.Updated_By))
            .ForMember(dest => dest.Updated_On, opt => opt.MapFrom(src => src.Updated_On))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        }
    }
}
