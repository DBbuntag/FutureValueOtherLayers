using FutureValue.API.Model;
using FutureValue.Application.Dtos;
using FutureValue.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        //POST: api/ApplicationUser/Register
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserDto applicationUserDto)
        {
            try
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = applicationUserDto.Username,
                    FullName = applicationUserDto.FullName
                };

                var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST: api/ApplicationUser/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(ApplicationUserDto applicationUserDto)
        {
            try
            {
                //user manager will be used to check if we have a user with the given credentials
                var user = await _userManager.FindByNameAsync(applicationUserDto.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, applicationUserDto.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserId", user.Id.ToString())
                    }),
                        Expires = DateTime.Now.AddDays(1), //token will be expired after 1 day
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    return BadRequest(new { message = "Incorrect Username or Password. " });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
