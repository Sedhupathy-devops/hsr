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
    public class IRDetailsMappingProfile: Profile
    {
        public IRDetailsMappingProfile()
        {
            CreateMap<IRDetailsMapping, IRDetailsMappingDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Request_Id, opt => opt.MapFrom(src => src.Request_Id))
                .ForMember(dest => dest.InterfaceEngine, opt => opt.MapFrom(src => src.InterfaceEngine))
                .ForMember(dest => dest.EnvironmentType, opt => opt.MapFrom(src => src.EnvironmentType))
                .ForMember(dest => dest.EnvironmentAccessGateway, opt => opt.MapFrom(src => src.EnvironmentAccessGateway))
                .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.Created_By))
                .ForMember(dest => dest.Created_On, opt => opt.MapFrom(src => src.Created_On))
                .ForMember(dest => dest.Updated_By, opt => opt.MapFrom(src => src.Updated_By))
                .ForMember(dest => dest.Updated_On, opt => opt.MapFrom(src => src.Updated_On))
                .ForMember(dest => dest.MessageStandard, opt => opt.MapFrom(src => src.MessageStandard))
                .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Application))
                .ForMember(dest => dest.DestinationDetails, opt => opt.MapFrom(src => src.DestinationDetails))
                .ReverseMap();
        }
    }
}
