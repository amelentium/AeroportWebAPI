using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SkillAppAdoDapperWebApi.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Token;

namespace SkillAppAdoDapperWebApi.BLL.Services
{
    public class UserService : IUserService
    {
        protected readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<IdentityUser>> GetUsersList()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<bool> IsUserExist(string UserEmail)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == UserEmail);
        }

        public async Task<bool> RegisterUser(string UserEmail, string UserPassword)
        {
            if (string.IsNullOrEmpty(UserEmail) || string.IsNullOrEmpty(UserPassword) || await IsUserExist(UserEmail))
                return false;
            IdentityUser user = new IdentityUser();
            user.UserName = user.Email = UserEmail;
            user.PasswordHash = UserPassword;
            await _userManager.CreateAsync(user);
            return true;
        }

        public async Task<string> GetToken(string UserEmail, string UserPassword)
        {
            if (string.IsNullOrEmpty(UserEmail) || string.IsNullOrEmpty(UserPassword))
                return null;
            var user = await _userManager.FindByNameAsync(UserEmail);
            if (user == null || user.PasswordHash != UserPassword)
                return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var jwt = new JwtSecurityToken
            (
                issuer: AeroTokenOptions.ISSUER,
                audience: AeroTokenOptions.AUDIENCE,
                notBefore: DateTime.UtcNow,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(4)),
                signingCredentials: new SigningCredentials(AeroTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
