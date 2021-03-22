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
    public class InterfaceRequestMappingProfile: Profile
    {
        public InterfaceRequestMappingProfile()
        {
            CreateMap<InterfaceRequestInputModel, InterfaceRequestDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.User_Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Project_Name, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.No_Interfaces, opt => opt.MapFrom(src => src.NoInterfaces))
                .ForMember(dest => dest.Project_Description, opt => opt.MapFrom(src => src.ProjectDescription))
                .ForMember(dest => dest.Budget_Upper_Limit, opt => opt.MapFrom(src => src.BudgetUpperLimit))
                .ForMember(dest => dest.Budget_Lower_Limit, opt => opt.MapFrom(src => src.BudgetLowerLimit))
                .ForMember(dest => dest.Expected_Timeline, opt => opt.MapFrom(src => src.ExpectedTimeline))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.Created_By, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Created_On, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.Updated_By, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.Updated_On, opt => opt.MapFrom(src => src.UpdatedOn))
                .ForMember(dest => dest.Order_Status_Id, opt => opt.MapFrom(src => src.OrderStatusId))
                .ForMember(dest => dest.Start_Date, opt => opt.MapFrom(src => src.StartDate))
                //.ForMember(dest => dest.InterfaceDetailsList, opt => opt.MapFrom(src => src.InterfaceDetailsList))
                .ReverseMap();
        }
        

    }
}
