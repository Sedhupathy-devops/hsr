using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICS.Services.MapperProfiles;
using ICS.Services;
using ICS.DAL.Infrastructure;
using ICS.DAL.DTOs;
using ICS.DAL.Repos;
using System.Configuration;
using ICS.Services.Entities.Models;
using ICS.WebAPI.Infrastructure;

namespace ICS.WebAPI
{
    public class DependencyRegistration
    {
        public static void Configure(IUnityContainer container, IConfiguration Configuration)
        {

            container.RegisterInstance(MappingProfilesConfiguration.InitializeAutoMapper());
            container.RegisterInstance<IDatabaseManager>(new DatabaseManager(new DatabaseFactory())
            {
                ConnectionString = "server=crowdsourcedev.c8owe0hgyui5.ap-south-1.rds.amazonaws.com,3306;uid=admin;pwd=Emids12345;database=crowdsourcedev" //Configuration.get
            }) ;

            container.RegisterType<IDapperManager, DapperManager>();
            container.RegisterType<IGenericRepository<UserDTO>, GenericRepository<UserDTO>>();
            container.RegisterType<IGenericRepository<UserTypeDTO>, GenericRepository<UserTypeDTO>>();
            container.RegisterType<IGenericRepository<InterfaceRequestDTO>, GenericRepository<InterfaceRequestDTO>>();
            container.RegisterType<IGenericRepository<IRDocumentsMappingDTO>, GenericRepository<IRDocumentsMappingDTO>>();
            container.RegisterType<IGenericRepository<IRDetailsMappingDTO>, GenericRepository<IRDetailsMappingDTO>>();
            container.RegisterType<IGenericRepository<DropdownListDTO>, GenericRepository<DropdownListDTO>>();
            container.RegisterType<IGenericRepository<EnterpriseProfileDTO>, GenericRepository<EnterpriseProfileDTO>>();
            container.RegisterType<IGenericRepository<UserInputModel>, GenericRepository<UserInputModel>>();
            container.RegisterType<IGenericRepository<UserTypeInputModel>, GenericRepository<UserTypeInputModel>>();
            container.RegisterType<IGenericRepository<InterfaceRequestInputModel>, GenericRepository<InterfaceRequestInputModel>>();
            container.RegisterType<IGenericRepository<IRDocumentsMapping>, GenericRepository<IRDocumentsMapping>>();
            container.RegisterType<IGenericRepository<IRDetailsMapping>, GenericRepository<IRDetailsMapping>>();
            container.RegisterType<IGenericRepository<DropdownList>, GenericRepository<DropdownList>>();
            container.RegisterType<IGenericRepository<EnterpriseProfile>, GenericRepository<EnterpriseProfile>>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IJwtAuthManager, JwtAuthManager>();
        }
    }
}
