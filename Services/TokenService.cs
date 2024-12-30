﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppVote01.Models;

namespace AppVote01.Services
{
    public class TokenService
    {

        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[] {
           new Claim("username", user.UserName),
           new Claim("id", user.Id),
           
           new Claim("loginTimestamp", DateTime.UtcNow.ToString())
           };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }
    }
}