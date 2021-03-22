using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ICS.Services.MapperProfiles
{
    public static class MappingProfilesConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var profiles = new Profile[] {
                    new UserMappingProfile(),
                    new UserTypeMappingProfile(),
                    new InterfaceRequestMappingProfile(),
                    new IRDetailsMappingProfile(),
                    new IRDocumentsMappingProfile(),
                     new DropdownListMappingProfile(),
                     new EnterpriseProfileMappingProfile()
                    };

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            return config;
        }
    }
}
