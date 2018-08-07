using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JWTExample.Model.Entity;
using JWTExample.Model.Repository.Interface;
using JWTExample.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration Config;
        private IUserRepository Repository;
        public TokenController(IConfiguration Config, IUserRepository Repository)
        {
            this.Config = Config;
            this.Repository = Repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(Config["Jwt:Issuer"], Config["Jwt:Issuer"], expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginViewModel login)
        {
            User user = null;

            if (login.Username == "Test" && login.Password == "pass")
            {
                user = Repository.Get(1);
            }
            return user;
        }
    }
}
