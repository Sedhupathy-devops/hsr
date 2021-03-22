using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ICS.DAL.DTOs;
using ICS.DAL.Infrastructure;
using System.Linq;

namespace ICS.DAL.Repos
{
    public interface IUserRepo
    {
        IEnumerable<UserDTO> GetUsers();
        IEnumerable<UserTypeDTO> GetUserTypes();
        bool AddUser(UserDTO userDetails);
        UserDTO ValidateCredentials(UserDTO credentials);
        int AddInterfaceRequest(InterfaceRequestDTO iRequestDetails);
        List<InterfaceRequestDTO> GetAllInterfaceRequests(int id);
        InterfaceRequestDTO GetInterfaceRequestById(int id);
        void UpdateInterfaceRequest(InterfaceRequestDTO iRequestDetails);
        UserDTO GetUser(int id);
        bool AddInterfaceDetails(IRDetailsMappingDTO iRequestDetails);
        List<DropdownListDTO> GetInterfaceEngines();
        List<DropdownListDTO> GetEnvironmentTypes();
        List<DropdownListDTO> GetEnvironmentAccessTypes();
        List<DropdownListDTO> GetMessageStandards();
        EnterpriseProfileDTO GetEnterpriseProfile(int id);
        bool UpdateEnterpriseProfile(EnterpriseProfileDTO updatedDetails);
        UserDTO IfUserExists(string email);
    }
    public class UserRepo: IUserRepo
    {
        private IDapperManager _dapperManager;

        public UserRepo(IDapperManager dapperManager)
        {
            _dapperManager = dapperManager;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            string query = "Select * FROM User";
            return _dapperManager.Query<UserDTO>(query);
        }
        
        public UserDTO GetUser(int id)
        {
            UserDTO userDTO = new UserDTO();
            List<UserDTO> users = _dapperManager.Query<UserDTO>(@"SELECT * FROM User WHERE ID=@ID",
                                                        new
                                                        {
                                                            ID = id
                                                        }).ToList();

            if (users.Count == 1)
            {
                userDTO = users.FirstOrDefault();
                return userDTO;
            }
            else
                return null;
        }

        public IEnumerable<UserTypeDTO> GetUserTypes()
        {
            string query = "SELECT * FROM UserType";
            return _dapperManager.Query<UserTypeDTO>(query);
        }

        public bool AddUser(UserDTO userDetails)
        {
            userDetails.Password = Encrypt(userDetails.Password);
            int rowsAffected = _dapperManager.Execute(@"INSERT INTO User(USER_TYPE_ID,USER_ROLE_ID,FIRSTNAME,LASTNAME,EMAIL,PASSWORD,PASSWORD_UPDATED_ON,ISDELETED,ISLOCKED,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) VALUES (@USER_TYPE_ID,@USER_ROLE_ID,@FIRSTNAME,@LASTNAME,@EMAIL,@PASSWORD,@PASSWORD_UPDATED_ON,@ISDELETED,@ISLOCKED,@CREATED_BY,@CREATED_ON,@UPDATED_BY,@UPDATED_ON)", 
                                    new { 
                                            USER_TYPE_ID = userDetails.User_Type_Id, 
                                            USER_ROLE_ID = userDetails.User_Role_Id, 
                                            FIRSTNAME = userDetails.Firstname, 
                                            LASTNAME = userDetails.Lastname,
                                            EMAIL = userDetails.Email,
                                            PASSWORD = userDetails.Password,
                                            PASSWORD_UPDATED_ON = userDetails.Password_Updated_On,
                                            ISDELETED = userDetails.IsDeleted,
                                            ISLOCKED = userDetails.IsLocked,
                                            CREATED_BY = userDetails.Created_By,
                                            CREATED_ON = userDetails.Created_On,
                                            UPDATED_BY = userDetails.Updated_By,
                                            UPDATED_ON = userDetails.Updated_On
                                    });
            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public UserDTO ValidateCredentials(UserDTO credentials)
        {
            UserDTO user = new UserDTO();
            List<UserDTO> users = _dapperManager.Query<UserDTO>(@"SELECT * FROM User WHERE EMAIL=@EMAIL",
                                                                new
                                                                {
                                                                    EMAIL = credentials.Email,
                                                                }).ToList();
            if (users.Count == 1)
            {
                user = users.FirstOrDefault();
                string password = Decrypt(user.Password);
                if (password == credentials.Password)
                    return user;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public int AddInterfaceRequest(InterfaceRequestDTO iRequestDetails)
        {
            int id = _dapperManager.QuerySingle<int>(@"INSERT INTO InterfaceRequest(USER_ID,PROJECT_NAME,NO_INTERFACES,PROJECT_DESCRIPTION,BUDGET_UPPER_LIMIT,BUDGET_LOWER_LIMIT,EXPECTED_TIMELINE,ISDELETED,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,ORDER_STATUS_ID,START_DATE) VALUES (@USERID,@PROJECT_NAME,@NO_INTERFACES,@PROJECT_DESCRIPTION,@BUDGET_UPPER_LIMIT,@BUDGET_LOWER_LIMIT,@EXPECTED_TIMELINE,@ISDELETED,@CREATED_BY,@CREATED_ON,@UPDATED_BY,@UPDATED_ON,@ORDER_STATUS_ID,@START_DATE);SELECT LAST_INSERT_ID()",
                                    new
                                    {
                                        USERID = iRequestDetails.User_Id,
                                        PROJECT_NAME = iRequestDetails.Project_Name,
                                        NO_INTERFACES = iRequestDetails.No_Interfaces,
                                        PROJECT_DESCRIPTION = iRequestDetails.Project_Description,
                                        BUDGET_UPPER_LIMIT = iRequestDetails.Budget_Upper_Limit,
                                        BUDGET_LOWER_LIMIT = iRequestDetails.Budget_Lower_Limit,
                                        EXPECTED_TIMELINE = iRequestDetails.Expected_Timeline,
                                        ISDELETED = iRequestDetails.IsDeleted,
                                        CREATED_BY = iRequestDetails.Created_By,
                                        CREATED_ON = iRequestDetails.Created_On,
                                        UPDATED_BY = iRequestDetails.Updated_By,
                                        UPDATED_ON = iRequestDetails.Updated_On,
                                        ORDER_STATUS_ID = iRequestDetails.Order_Status_Id,
                                        START_DATE = iRequestDetails.Start_Date
                                    });
            if (id > 0)
                return id;
            else
                return 0;
        }
        public bool AddInterfaceDetails(IRDetailsMappingDTO iRequestDetails)
        {
            int rowsAffected = _dapperManager.Execute(@"INSERT INTO InterfaceRequest_Details_Mapping(REQUEST_ID,INTERFACE_ENGINE,ENVIRONMENT_TYPE,ENVIRONMENT_ACCESS_GATEWAY,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,MESSAGE_STANDARD,APPLICATION,DESTINATION_DETAILS) VALUES (@REQUEST_ID,@INTERFACE_ENGINE,@ENVIRONMENT_TYPE,@ENVIRONMENT_ACCESS_GATEWAY,@CREATED_BY,@CREATED_ON,@UPDATED_BY,@UPDATED_ON,@MESSAGE_STANDARD,@APPLICATION,@DESTINATION_DETAILS)",
                                    new
                                    {
                                        REQUEST_ID = iRequestDetails.Request_Id,
                                        INTERFACE_ENGINE = iRequestDetails.InterfaceEngine,
                                        ENVIRONMENT_TYPE = iRequestDetails.EnvironmentType,
                                        ENVIRONMENT_ACCESS_GATEWAY = iRequestDetails.EnvironmentAccessGateway,
                                        CREATED_BY = iRequestDetails.Created_By,
                                        CREATED_ON = iRequestDetails.Created_On,
                                        UPDATED_BY = iRequestDetails.Updated_By,
                                        UPDATED_ON = iRequestDetails.Updated_On,
                                        MESSAGE_STANDARD = iRequestDetails.MessageStandard,
                                        APPLICATION = iRequestDetails.Application,
                                        DESTINATION_DETAILS = iRequestDetails.DestinationDetails
                                    });
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public List<InterfaceRequestDTO> GetAllInterfaceRequests(int id)
        {
            //string query = "Select * FROM InterfaceRequest";
            //return _dapperManager.Query<InterfaceRequestDTO>(query);
            List<InterfaceRequestDTO> iRequests = new List<InterfaceRequestDTO>();
            iRequests = _dapperManager.Query<InterfaceRequestDTO>(@"SELECT ID,USER_ID, PROJECT_NAME,NO_INTERFACES,PROJECT_DESCRIPTION,BUDGET_UPPER_LIMIT,BUDGET_LOWER_LIMIT,EXPECTED_TIMELINE,ISDELETED,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,ORDER_STATUS_ID,START_DATE FROM InterfaceRequest WHERE USER_ID=@ID",
                                                        new
                                                        {
                                                            ID = id
                                                        }).ToList();
            return iRequests;
        }

        public InterfaceRequestDTO GetInterfaceRequestById(int id)
        {
            InterfaceRequestDTO iRequestDTO = new InterfaceRequestDTO();
            List<InterfaceRequestDTO> iRequests = _dapperManager.Query<InterfaceRequestDTO>(@"SELECT * FROM InterfaceRequest WHERE USER_ID=@ID",
                                                        new
                                                        {
                                                            ID = id
                                                        }).ToList();

            if (iRequests.Count == 1)
            {
                iRequestDTO = iRequests.FirstOrDefault();
                return iRequestDTO;
            }
            else
                return null;
        }

        public void UpdateInterfaceRequest(InterfaceRequestDTO iRequestDetails)
        {
            //int rowsAffected = _dapperManager.Execute(@"UPDATE InterfaceRequest SET USERID=@USERID,PROJECT_NAME=@PROJECT_NAME,NO_INTERFACES=@NO_INTERFACES,PROJECT_DESCRIPTION=@PROJECT_DESCRIPTION,BUDGET_UPPER_LIMIT=@BUDGET_UPPER_LIMIT,BUDGET_LOWER_LIMIT=@BUDGET_LOWER_LIMIT,EXPECTED_TIMELINE=@EXPECTED_TIMELINE,INTERFACE_ENGINE=@INTERFACE_ENGINE,ENVIRONMENT_TYPE=@ENVIRONMENT_TYPE,ENVIRONMENT_ACCESS_GATEWAY=@ENVIRONMENT_ACCESS_GATEWAY,MESSAGE_STANDARD=@MESSAGE_STANDARD,APPLICATION=@APPLICATION,DESTINATION_DETAILS=@DESTINATION_DETAILS,ISDELETED=@ISDELETED,CREATED_BY=@CREATED_BY,CREATED_ON=@CREATED_ON,UPDATED_BY=@UPDATED_BY,UPDATED_ON=@UPDATED_ON WHERE ID=@ID",
            //                        new
            //                        {
            //                            USERID = iRequestDetails.UserId,
            //                            PROJECT_NAME = iRequestDetails.ProjectName,
            //                            NO_INTERFACES = iRequestDetails.NoInterfaces,
            //                            PROJECT_DESCRIPTION = iRequestDetails.ProjectDescription,
            //                            BUDGET_UPPER_LIMIT = iRequestDetails.BudgetUpperLimit,
            //                            BUDGET_LOWER_LIMIT = iRequestDetails.BudgetLowerLimit,
            //                            EXPECTED_TIMELINE = iRequestDetails.ExpectedTimeline,
            //                            INTERFACE_ENGINE = iRequestDetails.InterfaceEngine,
            //                            ENVIRONMENT_TYPE = iRequestDetails.EnvironmentType,
            //                            ENVIRONMENT_ACCESS_GATEWAY = iRequestDetails.EnvironmentAccessGateway,
            //                            MESSAGE_STANDARD = iRequestDetails.MessageStandard,
            //                            APPLICATION = iRequestDetails.Application,
            //                            DESTINATION_DETAILS = iRequestDetails.DestinationDetails,
            //                            ISDELETED = iRequestDetails.IsDeleted,
            //                            CREATED_BY = iRequestDetails.CreatedBy,
            //                            CREATED_ON = iRequestDetails.CreatedOn,
            //                            UPDATED_BY = iRequestDetails.UpdatedBy,
            //                            UPDATED_ON = iRequestDetails.UpdatedOn
            //                        });
            return;
        }

        public EnterpriseProfileDTO GetEnterpriseProfile(int id)
        {
            EnterpriseProfileDTO enterpriseProfile = new EnterpriseProfileDTO();
            enterpriseProfile = _dapperManager.Query<EnterpriseProfileDTO>(@"SELECT * FROM EnterpriseProfile WHERE USER_ID=@USER_ID",
                                        new
                                        {
                                            USER_ID = id
                                        }).FirstOrDefault();
            return enterpriseProfile;
        }

        public bool UpdateEnterpriseProfile(EnterpriseProfileDTO updatedDetails)
        {
            int rowsAffected = _dapperManager.Execute(@"UPDATE EnterpriseProfile SET IMAGE=@IMAGE,IS_ACTIVE=@IS_ACTIVE,NO_FACILITIES=@NO_FACILITIES,WEBSITE_URL=@WEBSITE_URL,BILLING_ADDRESS=@BILLING_ADDRESS,ENTERPRISE_NAME=@ENTERPRISE_NAME,CONTACT_PERSON_FIRST_NAME=@CONTACT_PERSON_FIRST_NAME,CONTACT_PERSON_LAST_NAME=@CONTACT_PERSON_LAST_NAME,CONTACT_PERSON_PHONE_NO=@CONTACT_PERSON_PHONE_NO,CONTACT_PERSON_EMAIL=@CONTACT_PERSON_EMAIL,INTEGRATION_ENGINE_USED=@INTEGRATION_ENGINE_USED,EMR_OR_REGISTRATION_SYSTEM_USED=@EMR_OR_REGISTRATION_SYSTEM_USED,CREATED_BY=@CREATED_BY,CREATED_ON=@CREATED_ON,UPDATED_BY=@UPDATED_BY,UPDATED_ON=@UPDATED_ON WHERE ID=@ID AND @USER_ID=@USER_ID",
                                        new
                                        {
                                            IMAGE = updatedDetails.Image,
                                            IS_ACTIVE = updatedDetails.Is_Active,
                                            NO_FACILITIES = updatedDetails.No_Facilities,
                                            WEBSITE_URL = updatedDetails.Website_Url,
                                            BILLING_ADDRESS = updatedDetails.Billing_Address,
                                            ENTERPRISE_NAME = updatedDetails.Enterprise_Name,
                                            CONTACT_PERSON_FIRST_NAME = updatedDetails.Contact_Person_First_Name,
                                            CONTACT_PERSON_LAST_NAME = updatedDetails.Contact_Person_Last_Name,
                                            CONTACT_PERSON_PHONE_NO = updatedDetails.Contact_Person_Phone_No,
                                            CONTACT_PERSON_EMAIL = updatedDetails.Contact_Person_Email,
                                            INTEGRATION_ENGINE_USED = updatedDetails.Intergration_Engine_Used,
                                            EMR_OR_REGISTRATION_SYSTEM_USED = updatedDetails.Emr_Or_Registration_System_Used,
                                            CREATED_BY = updatedDetails.Created_By,
                                            CREATED_ON = updatedDetails.Created_On,
                                            UPDATED_BY = updatedDetails.Updated_By,
                                            UPDATED_ON = updatedDetails.Updated_On,
                                            USER_ID = updatedDetails.User_Id,
                                            ID = updatedDetails.Id
                                        });
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        public List<DropdownListDTO> GetInterfaceEngines()
        {
            string query = "SELECT * FROM Interface_Engine_Lookup";
            return _dapperManager.Query<DropdownListDTO>(query).ToList();
        }

        public List<DropdownListDTO> GetEnvironmentTypes()
        {
            string query = "SELECT * FROM Environment_Type_Lookup";
            return _dapperManager.Query<DropdownListDTO>(query).ToList();
        }

        public List<DropdownListDTO> GetEnvironmentAccessTypes()
        {
            string query = "SELECT * FROM Environment_Access_Gateway_Lookup";
            return _dapperManager.Query<DropdownListDTO>(query).ToList();
        }

        public List<DropdownListDTO> GetMessageStandards()
        {
            string query = "SELECT * FROM Message_Standard_Lookup";
            return _dapperManager.Query<DropdownListDTO>(query).ToList();
        }

        public UserDTO IfUserExists(string email)
        {
            UserDTO user = _dapperManager.Query<UserDTO>(@"SELECT * FROM User WHERE EMAIL=@EMAIL",
                new
                {
                    EMAIL = email
                }).FirstOrDefault();

            return user;
        }
    }
}
