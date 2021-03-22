using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ICS.Services;
using ICS.DAL.DTOs;
using ICS.Services.Enums;
using ICS.Services.Entities.Models;
using Newtonsoft.Json.Linq;
using ICS.Services.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using IdentityModel.Client;
using System.IdentityModel.Tokens.Jwt;
using ICS.WebAPI.Infrastructure;
using System.Security.Principal;
using IdentityModel;

namespace ICS.WebAPI.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class CrowdSourceController : ControllerBase
    {
        private IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<CrowdSourceController> _logger;

        public CrowdSourceController(ILogger<CrowdSourceController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            List<UserInputModel> users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost("User")]
        public IActionResult GetUser([FromBody]string id)
        {
            UserInputModel user = _userService.GetUser(Convert.ToInt32(id));
            return Ok(user);
        }

        [HttpGet("UserTypes")]
        public IActionResult GetUserTypes()
        {
            List<UserTypeInputModel> usertypes = _userService.GetUserTypes();
            return Ok(usertypes);
        }

        [AllowAnonymous]
        [HttpPost("AddDeveloper")]
        public bool AddDeveloper([FromBody]string userDetails)
        {
            UserInputModel requestData = JsonConvert.DeserializeObject<UserInputModel>(userDetails);
            requestData.User_Type_Id = Convert.ToInt32(USERTYPE.RESOURCE);
            requestData.User_Role_Id = Convert.ToInt32(USERROLE.DEVELOPER);
            requestData.Firstname = requestData.Firstname;
            requestData.Lastname = requestData.Lastname;
            requestData.Email = requestData.Email;
            requestData.Password = requestData.Password;
            requestData.Password_Updated_On = DateTime.Now;
            requestData.IsLocked = 0;
            requestData.IsDeleted = 0;
            requestData.Created_By = 0;
            requestData.Created_On = DateTime.Now;
            requestData.Updated_By = 0;
            requestData.Updated_On = DateTime.Now;
            bool isUserAdded = _userService.AddUser(requestData);
            return isUserAdded;
        }

        [AllowAnonymous]
        [HttpPost("AddEnterprise")]
        public bool AddEnterprise([FromBody]string userDetails)
        {
            UserInputModel requestData = JsonConvert.DeserializeObject<UserInputModel>(userDetails);
            requestData.User_Type_Id = Convert.ToInt32(USERTYPE.ENTERPRISE);
            requestData.User_Role_Id = Convert.ToInt32(USERROLE.ENTERPRISE);
            requestData.Firstname = requestData.Firstname;
            requestData.Lastname = requestData.Lastname;
            requestData.Email = requestData.Email;
            requestData.Password = requestData.Password;
            requestData.Password_Updated_On = DateTime.Now;
            requestData.IsLocked = 0;
            requestData.IsDeleted = 0;
            requestData.Created_By = 0;
            requestData.Created_On = DateTime.Now;
            requestData.Updated_By = 0;
            requestData.Updated_On = DateTime.Now;
            bool isUserAdded = _userService.AddUser(requestData);
            return isUserAdded;
        }

        
        [HttpPost("LoginUser")]
        public ActionResult LoginUser([FromBody]string credentials)
        {
            string responseData = string.Empty;
            UserInputModel requestData = JsonConvert.DeserializeObject<UserInputModel>(credentials);
            UserInputModel userData = _userService.ValidateCredentials(requestData);
            UserViewModel user = new UserViewModel();
            if (userData != null)
            {
               user.userDetails = userData;

                string userType = Enum.GetName(typeof(USERTYPE), userData.User_Type_Id);
                string role = Enum.GetName(typeof(USERROLE), userData.User_Role_Id);
                Claim[] claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier ,userData.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
                };

                var jwtResult = _jwtAuthManager.GenerateTokens(userData.Id.ToString(), claims, DateTime.Now);
                _logger.LogInformation($"User [{userData.Id}] logged in the system.");

                UserTokenModel userToken = new UserTokenModel()
                {
                    UserId = userData.Id,
                    Token = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString,
                    RefreshTokenExpiration = jwtResult.RefreshToken.ExpireAt,
                    Created_On = DateTime.Now
                };
                user.userToken = userToken;
                if (userToken.Token.Length > 0)
                    responseData = JsonConvert.SerializeObject(user);
            }
            else
            {
                user = null;
            }
            return Ok(user);
        }

        
        [HttpPost("LogoutUser")]
        public ActionResult LogoutUser()
        {
            var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            _jwtAuthManager.RemoveRefreshTokenByUserID(userID);
            _logger.LogInformation($"User [{userID}] logged out the system.");
            return Ok();
        }


        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                _logger.LogInformation($"User [{userID}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now, userID);
                _logger.LogInformation($"User [{userID}] has refreshed JWT token.");
                return Ok(new UserTokenModel
                {
                    UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                    Token = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString,
                    RefreshTokenExpiration = jwtResult.RefreshToken.ExpireAt,
                    Created_On = DateTime.Now
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); 
            }
        }

        [HttpPost("NewInterfaceRequest")]
        public ActionResult NewInterfaceRequest([FromBody]string request)
        {
            InterfaceRequestInputModel requestData = JsonConvert.DeserializeObject<InterfaceRequestInputModel>(request);
            requestData.NoInterfaces = requestData.InterfaceDetailsList.Count;
            
            bool isInterfaceAdded = _userService.AddInterfaceRequest(requestData);
            return Ok(isInterfaceAdded);
        }

        [HttpPost("AllInterfaceRequests")]
        public IActionResult AllInterfaceRequests([FromBody]string id)
        {
            List<InterfaceRequestInputModel> iRequests = _userService.GetAllInterfaceRequests(Convert.ToInt32(id));
            return Ok(iRequests);
        }

        [HttpPost("GetInterfaceRequestById")]
        public IActionResult GetInterfaceRequestById([FromBody]string id)
        {
            InterfaceRequestInputModel iRequest = _userService.GetInterfaceRequestById(Convert.ToInt32(id));
            return Ok(iRequest);
        }

        [HttpPost("UpdateInterfaceRequest")]
        public IActionResult UpdateInterfaceRequest([FromBody]string request)
        {
            InterfaceRequestInputModel iRequestData = JsonConvert.DeserializeObject<InterfaceRequestInputModel>(request);
            _userService.UpdateInterfaceRequest(iRequestData);
            return Ok();
        }

        [HttpGet("GetInterfaceEngines")]
        public IActionResult GetInterfaceEngines()
        {
            return Ok(_userService.GetInterfaceEngines());
        }

        [HttpGet("GetEnvironmentTypes")]
        public IActionResult GetEnvironmentTypes()
        {
            return Ok(_userService.GetEnvironmentTypes());
        }

        [HttpGet("GetEnvironmentAccessTypes")]
        public IActionResult GetEnvironmentAccessTypes()
        {
            return Ok(_userService.GetEnvironmentAccessTypes());
        }

        [HttpGet("GetMessageStandards")]
        public IActionResult GetMessageStandards()
        {
            return Ok(_userService.GetMessageStandards());
        }

        [HttpPost("GetEnterpriseProfile")]
        public IActionResult GetEnterpriseProfile([FromBody]string id)
        {
            return Ok(_userService.GetEnterpriseProfile(Convert.ToInt32(id)));
        }

        [HttpPost("UpdateEnterpriseProfile")]
        public IActionResult UpdateEnterpriseProfile([FromBody]string parameters)
        {
            EnterpriseProfile updatedDetails = JsonConvert.DeserializeObject<EnterpriseProfile>(parameters);
            return Ok(_userService.UpdateEnterpriseProfile(updatedDetails));
        }
    }
}
