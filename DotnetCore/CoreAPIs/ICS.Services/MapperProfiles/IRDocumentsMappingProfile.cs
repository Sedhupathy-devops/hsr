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
    public class IRDocumentsMappingProfile: Profile
    {
        public IRDocumentsMappingProfile()
        {
            CreateMap<IRDocumentsMapping, IRDocumentsMappingDTO>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.RequestId))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
                .ForMember(dest => dest.DocumentUrl, opt => opt.MapFrom(src => src.DocumentUrl))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.Created_By))
                .ForMember(dest => dest.Created_On, opt => opt.MapFrom(src => src.Created_On))
                .ForMember(dest => dest.Updated_By, opt => opt.MapFrom(src => src.Updated_By))
                .ForMember(dest => dest.Updated_On, opt => opt.MapFrom(src => src.Updated_On))
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File))
                .ReverseMap();
        }
    }
}
