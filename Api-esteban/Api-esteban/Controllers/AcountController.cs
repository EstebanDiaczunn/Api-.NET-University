using Api_esteban.Helpers;
using Api_esteban.Models.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Api_esteban.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
                private readonly JwtSettings _jwtSettings;


                public AccountController(JwtSettings _jwtSettings)
                {
                        _jwtSettings = _jwtSettings;
                }

                private IEnumerable<User> Logins = new List<User>()
                {
                        new User
                        {
                                Id = 8,
                                Email = "estebandiaczun@gmail.com",
                                Name = "admin",
                                Password = "Admin"
                        },
                        new User
                        {
                                Id = 9,
                                Email = "estebandiaczun@gmail.com",
                                Name = "admin",
                                Password = "pepe"
                        }
                };

                [HttpPost]
                public IActionResult Login(UserLogins userLogin)
                {
                        try
                        {
                                var Token = new UserTokens();
                                var Valid = Logins.Any(User =>
                                        User.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                                if (Valid)
                                {
                                        var User = Logins.FirstOrDefault(User =>
                                                User.Name.Equals(userLogin.UserName,
                                                        StringComparison.OrdinalIgnoreCase));

                                        Token = JwtHelpers.GenTokenKey(new UserTokens
                                        {
                                                UserName = User.Name,
                                                EmailId = User.Email,
                                                Id = User.Id,
                                                GuidId = Guid.NewGuid()
                                        }, _jwtSettings);
                                }

                                else
                                {
                                        return BadRequest("Wrong Password");
                                }

                                return Ok(Token);
                        }
                        catch (Exception e)
                        {
                                throw new Exception("getTokenError", e);
                        }
                }

                [HttpGet]

                [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
                public IActionResult GetUserList()
                {
                        return Ok(Logins);
                }
        }
}
