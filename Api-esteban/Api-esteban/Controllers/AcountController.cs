using Api_esteban.DataAccess;
using Api_esteban.Helpers;
using Api_esteban.Models.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Api_esteban.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class AccountController : ControllerBase
        {       
                private readonly UniversityDBContext _context;
                
                private readonly JwtSettings _jwtSettings;

                public AccountController(UniversityDBContext context, JwtSettings _jwtSettings, JwtSettings jwtSettings)
                {
                        _context = context;
                        this._jwtSettings = _jwtSettings;
                }


                [HttpPost]
                public async Task<IActionResult> Login(UserLogins user)
                {
                        try
                        {
                                var Token = new UserTokens();

                                var Logins = _context.Users.ToList();
                                
                                //Verify if user is user from model and password 
                                
                                var Valid = Logins.Any(User =>
                                        User.Name.Equals(user.UserName, StringComparison.OrdinalIgnoreCase)
                                        &&User.Password.Equals(user.Password, StringComparison.OrdinalIgnoreCase));
                                
                                if (Valid)
                                {
                                        var User = Logins.FirstOrDefault(User =>
                                                User.Name.Equals(user.UserName,
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
                                        return BadRequest("User doesnt Exists");
                                }

                                return Ok(Token);
                        }
                        catch (Exception e)
                        {
                                throw new Exception("getTokenError", e);
                        }
                }

                [HttpGet]

                [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
                public IActionResult GetUserList()
                {
                        return Ok(_context.Users.ToList());
                }
        }
}
