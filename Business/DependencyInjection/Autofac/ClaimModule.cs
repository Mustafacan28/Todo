using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyInjection.Autofac
{
    public class ClaimModule
    {
        IConfiguration _configuration;

        public ClaimModule(IConfiguration configuration)
        {
            _configuration = configuration;

        }
       
        public string Claim(User userData)
        {       
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userData.UserId.ToString()),
                        new Claim("UserName", userData.UserName),
                        new Claim("LastName", userData.LastName),
                        new Claim("Telephone", userData.Telephone)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
