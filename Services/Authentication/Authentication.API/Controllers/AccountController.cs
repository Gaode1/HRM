using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {    
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;
        //register
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User()
            {
                Email = model.Email, LastName = model.LastName, FirstName = model.FirstName,
                UserName = model.Email
            };
            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Errors.Any())
            {
                return CreatedAtRoute("GetUser", new { Controller = "account", id = user.Id }, 
                    "Account Created");
            }
            return BadRequest(identityResult.Errors.Select(error=> error.Description).ToList());
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok("1");
        }

        //login   "email": "user@example.com", // andy@  //user1@example.com
        //        "password": "qweASD123."     // qweASD1. //String1!
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new { error = "Please check email/password format" });

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("username does not exist");

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if (isAuthenticated)
                return Ok(new { token = CreateJWT(user) });
            return Unauthorized("username password is invalid");    
        }


        private string CreateJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(_configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "HRM",
                Audience = "HRM Users",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim("language", "english"),
                    new Claim("location", "USA/DC")
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
