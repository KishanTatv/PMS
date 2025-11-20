using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PMS.Entity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PMS.Common.JWT
{
    public static class JwtToken
    {
        public static string GenerateToken(IdentityUser user, JwtSettingDto jwtSettingDto)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingDto.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtSettingDto.Issuer,
                audience: jwtSettingDto.Audience,
                claims: claims,
                expires: jwtSettingDto.ExpiresIn,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
