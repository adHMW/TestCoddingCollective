using VOS_V1.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOS_V1.ViewModels;

namespace VOS_V1.Services
{
    public interface IAuthService
    {
        Task<bool> Authenticate(string username, string password);
        Task<Users> GetUserDetail(string username);
        Task<string> GetUsernameDetails(string name);
        Task<IEnumerable<Menu>> GetMenuList(string roleId);
        Task<string> GetRoleName(int roleID);
        Task<List<Role>> GetRoleList();
        Task<bool> AuthenticateLDAP(string username, string password);
        Task<IEnumerable<Menu>> GetParentList(string roleId);
        Task<IEnumerable<Menu>> GetMenuListNoParent(string roleId);
        Task<List<Users>> GetUserList();
    }
}
