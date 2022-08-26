using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOS_V1.Models;
using VOS_V1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VOS_V1.Utility;
using System.Diagnostics;

namespace VOS_V1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _service;

        public LoginController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(string username, string password)
        {

            try

            {
                if (await _service.AuthenticateLDAP(username, password))
                {
                    //_auditLog.Log(username, StaticValue.Audit_LogIn, "");
                    var userDetail = await _service.GetUserDetail(username);
                    var roleName = await _service.GetRoleName(userDetail.ROLEID);
                    var usernameDetail = await _service.GetUsernameDetails(userDetail.USERID);

                    HttpContext.Session.SetString("UserID", username);

                    TempData["UserID"] = userDetail.USERID;

                    TempData["RoleID"] = userDetail.ROLEID;
                    TempData["BranchID"] = userDetail.BRANCHID;

                    //TempData["NPK"] = userDetail.NPK;
                    TempData["RoleName"] = roleName;
                    TempData["UserNameID"] = usernameDetail;
                    HttpContext.Session.SetString("RoleName", roleName);
                    HttpContext.Session.SetString("UserNameID", usernameDetail);

                    TempData["Success"] = "Login Success";
                    return RedirectToAction("Index", "Dashboard");
                    //return RedirectToAction("Index", "Home");
                }


                TempData["Error"] = "Cek kembali username & password anda";

            }
            catch (Exception ex)
            {
                
                TempData["Error"] = "Ada Kesalahan";
            }
            return RedirectToAction("Index", "Login");

        }

        [SessionTimeout]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SignOut()
        {
            var username = TempData.Peek("UserID").ToString();
            try
            {
               
                foreach (var key in TempData.Keys.ToList())
                {
                    HttpContext.Session.Remove(key.ToString());
                    TempData.Remove(key.ToString());
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ada Kesalahan";
            }
            return RedirectToAction("Index", "Login");
        }
    }
}