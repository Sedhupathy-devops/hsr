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
    public class EnterpriseProfileMappingProfile: Profile
    {
        public EnterpriseProfileMappingProfile()
        {
            CreateMap<EnterpriseProfile, EnterpriseProfileDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.User_Id, opt => opt.MapFrom(src => src.User_Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Is_Active, opt => opt.MapFrom(src => src.Is_Active))
                .ForMember(dest => dest.No_Facilities, opt => opt.MapFrom(src => src.No_Facilities))
                .ForMember(dest => dest.Website_Url, opt => opt.MapFrom(src => src.Website_Url))
                .ForMember(dest => dest.Billing_Address, opt => opt.MapFrom(src => src.Billing_Address))
                .ForMember(dest => dest.Enterprise_Name, opt => opt.MapFrom(src => src.Enterprise_Name))
                .ForMember(dest => dest.Contact_Person_First_Name, opt => opt.MapFrom(src => src.Contact_Person_First_Name))
                .ForMember(dest => dest.Contact_Person_Last_Name, opt => opt.MapFrom(src => src.Contact_Person_Last_Name))
                .ForMember(dest => dest.Contact_Person_Phone_No, opt => opt.MapFrom(src => src.Contact_Person_Phone_No))
                .ForMember(dest => dest.Contact_Person_Email, opt => opt.MapFrom(src => src.Contact_Person_Email))
                .ForMember(dest => dest.Intergration_Engine_Used, opt => opt.MapFrom(src => src.Intergration_Engine_Used))
                .ForMember(dest => dest.Emr_Or_Registration_System_Used, opt => opt.MapFrom(src => src.Emr_Or_Registration_System_Used))
                .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.Created_By))
                .ForMember(dest => dest.Created_On, opt => opt.MapFrom(src => src.Created_On))
                .ForMember(dest => dest.Updated_By, opt => opt.MapFrom(src => src.Updated_By))
                .ForMember(dest => dest.Updated_On, opt => opt.MapFrom(src => src.Updated_On))
                .ReverseMap();
        }
    }
}
