﻿using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Helpers;
using dot_net_backend_test.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace dot_net_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly TestDBContext _context;
        private readonly IStringLocalizer<AccountController> _stringLocalizer;
     

        public AccountController(
            JwtSettings jwtSettings, 
            TestDBContext context, 
            IStringLocalizer<AccountController> stringLocalizer)
        {
            _jwtSettings = jwtSettings;
            _context = context;
            _stringLocalizer = stringLocalizer;
        }

        
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {

                var message = _stringLocalizer.GetString("LoginMessage").Value ?? String.Empty;
                var Token = new UserTokens();

                var currentUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                
                if (currentUser != null)
                {
                   
                    Token = JwtHelpers.GenerateTokenKey(new UserTokens()
                    {
                        UserName = currentUser.Name,
                        EmailId = currentUser.Email,
                        Id = currentUser.Id,
                        Role = currentUser.Role,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                } else
                {
                    var badCredentials = _stringLocalizer.GetString("BadCredentials").Value ?? String.Empty;

                    return BadRequest(badCredentials);
                }
                return Ok(new
                {
                    Token,
                    Message = message
                });
            }
            catch (Exception ex)
            {

                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult GetUserList()
        {
            var users = from user in _context.Users select user;
            return Ok(users);
        }
    }
}
