using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.BLL.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<IdentityUser>> GetUsersList();
        public Task<bool> IsUserExist(string UserEmail);
        public Task<bool> RegisterUser(string UserEmail, string UserPassword);
        public Task<string> GetToken(string UserEmail, string UserPassword);
    }
}
