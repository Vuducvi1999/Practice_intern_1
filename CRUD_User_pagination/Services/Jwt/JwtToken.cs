using Domain.Dtos.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Services.Jwt
{
    public class JwtToken : IJwtToken
    {
        private IConfiguration _config;

        public JwtToken(IConfiguration config)
        {
            _config = config;
        }
        public string Generate(UserLogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
