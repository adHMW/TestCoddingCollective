using VOS_V1.Contexts;
using VOS_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VOS_V1.Utility;
//using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Microsoft.Extensions.Configuration;
using VOS_V1.ViewModels;

namespace VOS_V1.Services
{
    public class AuthService : IAuthService
    {
        private readonly VOSDBContext _context;
        private readonly String _ldapDomain;
        public IConfiguration Configuration { get; }

        public AuthService(VOSDBContext context, String ldapDomain)
        {
            _context = context;
            _ldapDomain = ldapDomain;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();

                string conString = configuration.GetConnectionString("DevConnection");

                using (OracleConnection con = new OracleConnection(conString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        try
                        {
                            con.Open();
                            cmd.CommandText = "select * from USER_VOS where userid = :userid";

                            OracleParameter userid = new OracleParameter("userid", username);
                            cmd.Parameters.Add(userid);

                            OracleDataReader reader = cmd.ExecuteReader();
                            return await Task.FromResult(reader.GetString(0).Count() == 1);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AuthenticateLDAP(string username, string password)
        {
            try
            {
                //return await Task.FromResult(true);
                using (var context = new PrincipalContext(ContextType.Domain, _ldapDomain, username, password))
                {
                    bool validate;

                    validate = context.ValidateCredentials(username, password);
                    if (validate)
                    {
                        return await Task.FromResult(validate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // User not authenticated
            return await Task.FromResult(false);
        }

        public async Task<Users> GetUserDetail(string username)
        {
            Users _user = new Users();

            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select userid,roleid,branchid,addisplayname, STATUS_CUTI , STATUS from USER_VOS where userid = '" + username + "' and status = 'Active'", con);
                cmd.CommandType = System.Data.CommandType.Text;

                reader = cmd.ExecuteReader();
                reader.Read();
                
                _user.USERID = reader.GetOracleString(0).ToString();
                _user.ROLEID = int.Parse(reader.GetOracleValue(1).ToString());
                _user.BRANCHID = reader.GetOracleString(2).ToString();
                _user.ADDISPLAYNAME = reader.GetOracleString(3).ToString();
                _user.STATUS_CUTI = reader.GetOracleString(4).ToString();
                _user.STATUS = reader.GetOracleString(5).ToString();
                
                return await Task.FromResult(_user);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
        }

        public async Task<string> GetRoleName(int roleID)
        {
            string role = "";
            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select ROLENAME from ROLE_VOS where ROLEID = '" + roleID + "'", con);
                cmd.CommandType = System.Data.CommandType.Text;

                reader = cmd.ExecuteReader();
                reader.Read();
                role = reader.GetOracleString(0).ToString();
                return await Task.FromResult(role);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
        }

        public async Task<string> GetUsernameDetails(string name)
        {
            string role = "";
            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select ADDISPLAYNAME from USER_VOS where USERID = '" + name + "'", con);
                cmd.CommandType = System.Data.CommandType.Text;

                reader = cmd.ExecuteReader();
                reader.Read();
                role = reader.GetOracleString(0).ToString();

                return await Task.FromResult(role);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
        }


        public async Task<List<Role>> GetRoleList()
        {
            try
            {
                var result = _context.ROLE_VOS.ToList();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Menu>> GetMenuList(string roleId)
        {

            Menu menu; //= new Menu();
            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select mv.* from menu_vos mv inner join ROLE_MENU rm on mv.MENUID = rm.MENUID where rm.ROLEID = '" + roleId + "'  order by mv.MENUORDER", con);
                cmd.CommandType = System.Data.CommandType.Text;
                List<Menu> listMenu = new List<Menu>();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menu = new Menu();
                    menu.MENUID = reader.GetOracleValue(1).ToString();
                    menu.MENUNAME = (reader.GetOracleValue(2).ToString());
                    menu.MENUCONTROLLER = reader.GetOracleValue(3).ToString();
                    menu.MENUPARENT = reader.GetOracleValue(4).ToString();
                    listMenu.Add(menu);
                }
                return await Task.FromResult(listMenu);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
            
        }


        public async Task<IEnumerable<Menu>> GetParentList(string roleId)
        {

            Menu menu; //= new Menu();
            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select distinct(mv.MENUPARENT) from menu_vos mv inner join ROLE_MENU rm on mv.MENUID = rm.MENUID where rm.ROLEID = '" + roleId + "'", con);
                cmd.CommandType = System.Data.CommandType.Text;
                List<Menu> listMenu = new List<Menu>();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menu = new Menu();

                    menu.MENUPARENT = reader.GetOracleValue(0).ToString();
                    listMenu.Add(menu);
                }
                return await Task.FromResult(listMenu);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

        }

        public async Task<IEnumerable<Menu>> GetMenuListNoParent(string roleId)
        {

            Menu menu; //= new Menu();
            OracleConnection con = null;
            OracleCommand cmd = null;
            OracleDataReader reader = null;
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
                string constr = configuration.GetConnectionString("DevConnection");
                con = new OracleConnection(constr);
                con.Open();
                cmd = new OracleCommand("select mv.MENUNAME,mv.MENUCONTROLLER from menu_vos mv inner join ROLE_MENU rm on mv.MENUID = rm.MENUID where rm.ROLEID = '" + roleId + "' and mv.MENUPARENT is null", con);
                cmd.CommandType = System.Data.CommandType.Text;
                List<Menu> listMenu = new List<Menu>();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menu = new Menu();

                    menu.MENUNAME = reader.GetOracleValue(0).ToString();
                    menu.MENUCONTROLLER = reader.GetOracleValue(1).ToString();
                    listMenu.Add(menu);
                }
                return await Task.FromResult(listMenu);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

        }

        public async Task<List<Users>> GetUserList()
        {
            try
            {
                var result = _context.USER_VOS.ToList();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsersMV>> GetUserListFormatted()
        {
            try
            {
                
                var masterJenisJKPMV = (from br in _context.USER_VOS
                                        select new UsersMV()
                                        {
                                            NPK = br.NPK,
                                            FULLNAME = br.ADDISPLAYNAME,
                                            NPK_NAME_FORMATED = br.USERID + " - " + br.ADDISPLAYNAME,
                                            USERAD = br.USERID
                                        }).ToList();
                return masterJenisJKPMV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
