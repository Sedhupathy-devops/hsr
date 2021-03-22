using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ICS.DAL.DTOs;
using ICS.DAL.Repos;
using ICS.Services.Entities;
using ICS.Services.Entities.Models;
using ICS.Services.MapperProfiles;
using System.Linq;

namespace ICS.Services
{
    public interface IUserService
    {
        List<UserInputModel> GetUsers();
        List<UserTypeInputModel> GetUserTypes();
        bool AddUser(UserInputModel userDetails);
        UserInputModel ValidateCredentials(UserInputModel credentials);
        bool AddInterfaceRequest(InterfaceRequestInputModel requestDetails);
        List<InterfaceRequestInputModel> GetAllInterfaceRequests(int id);
        InterfaceRequestInputModel GetInterfaceRequestById(int id);
        void UpdateInterfaceRequest(InterfaceRequestInputModel iRequestDetails);
        UserInputModel GetUser(int id);
        List<DropdownList> GetInterfaceEngines();
        List<DropdownList> GetEnvironmentTypes();
        List<DropdownList> GetEnvironmentAccessTypes();
        List<DropdownList> GetMessageStandards();
        EnterpriseProfile GetEnterpriseProfile(int id);
        bool UpdateEnterpriseProfile(EnterpriseProfile updatedDetails);
    }

    public class UserService: IUserService
    {
        private IUserRepo _repo;
        private IMapper _mapper;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
            _mapper = new Mapper(MappingProfilesConfiguration.InitializeAutoMapper());
        }

        public bool AddInterfaceRequest(InterfaceRequestInputModel requestDetails)
        {
            bool isInterfaceAdded = false;
            InterfaceRequestDTO iRequestDetails = _mapper.Map<InterfaceRequestDTO>(requestDetails);
            int interfaceID = _repo.AddInterfaceRequest(iRequestDetails);
            if (interfaceID > 0)
            {
                isInterfaceAdded = true;
                foreach (IRDetailsMapping interfaceDetail in requestDetails.InterfaceDetailsList)
                {
                    interfaceDetail.Request_Id = interfaceID;
                    bool isDetailsAdded = _repo.AddInterfaceDetails(_mapper.Map<IRDetailsMappingDTO>(interfaceDetail));
                    if (isDetailsAdded)
                        continue;
                    else
                    {
                        isInterfaceAdded = false;
                        break;
                    }

                }
            }
            return isInterfaceAdded;
        }

        public bool AddUser(UserInputModel userDetails)
        {
            UserDTO userDTO = _mapper.Map<UserDTO>(userDetails);
            bool isuserExist = IfUserExists(userDetails.Email);
            if (!isuserExist)
                return _repo.AddUser(userDTO);
            else
                return false;
        }

        private bool IfUserExists(string email)
        {
            UserDTO user = _repo.IfUserExists(email);
            if (user == null)
                return false;
            else
                return true;
        }

        public List<InterfaceRequestInputModel> GetAllInterfaceRequests(int id)
        {
            List<InterfaceRequestDTO> interfaceRequests = (_repo.GetAllInterfaceRequests(id)).ToList();
            return _mapper.Map<List<InterfaceRequestInputModel>>(interfaceRequests);
        }

        public InterfaceRequestInputModel GetInterfaceRequestById(int id)
        {
            InterfaceRequestDTO iRequestDTO = new InterfaceRequestDTO();
            iRequestDTO = _repo.GetInterfaceRequestById(id);
            return _mapper.Map<InterfaceRequestInputModel>(iRequestDTO);
        }

        public List<UserInputModel> GetUsers()
        {
            List<UserDTO> users = (_repo.GetUsers()).ToList();
            return _mapper.Map<List<UserInputModel>>(users);
             
        }

        public UserInputModel GetUser(int id)
        {
            UserDTO userDTO = (_repo.GetUser(id));
            return _mapper.Map<UserInputModel>(userDTO);
        }

        public List<UserTypeInputModel> GetUserTypes()
        {
            List<UserTypeDTO> userTypes = (_repo.GetUserTypes()).ToList();
            return _mapper.Map<List<UserTypeInputModel>>(userTypes);
        }

        public void UpdateInterfaceRequest(InterfaceRequestInputModel iRequestDetails)
        {
            InterfaceRequestDTO userDTO = _mapper.Map<InterfaceRequestDTO>(iRequestDetails);
            _repo.UpdateInterfaceRequest(userDTO);
            return;
        }

        public UserInputModel ValidateCredentials(UserInputModel credentials)
        {
            UserDTO userDTO = _mapper.Map<UserDTO>(credentials);
            UserDTO userData = _repo.ValidateCredentials(userDTO);
            return _mapper.Map<UserInputModel>(userData);
        }

        public List<DropdownList> GetInterfaceEngines()
        {
            return _mapper.Map<List<DropdownList>>(_repo.GetInterfaceEngines());
        }

        public List<DropdownList> GetEnvironmentTypes()
        {
            return _mapper.Map<List<DropdownList>>(_repo.GetEnvironmentTypes());
        }

        public List<DropdownList> GetEnvironmentAccessTypes()
        {
            return _mapper.Map<List<DropdownList>>(_repo.GetEnvironmentAccessTypes());
        }

        public List<DropdownList> GetMessageStandards()
        {
            return _mapper.Map<List<DropdownList>>(_repo.GetMessageStandards());
        }

        public EnterpriseProfile GetEnterpriseProfile(int id)
        {
            return _mapper.Map<EnterpriseProfile>(_repo.GetEnterpriseProfile(id));
        }

        public bool UpdateEnterpriseProfile(EnterpriseProfile updatedDetails)
        {
            return _repo.UpdateEnterpriseProfile(_mapper.Map<EnterpriseProfileDTO>(updatedDetails));
        }
    }
}
