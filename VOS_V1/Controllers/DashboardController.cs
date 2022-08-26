using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VOS_V1.Models;
using VOS_V1.Services;
using VOS_V1.Utility;
using VOS_V1.ViewModels;


namespace VOS_V1.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IAuthService _authService;
        public DashboardController(IDashboardService branchService, IAuthService authService)
        {
            _dashboardService = branchService;
            _authService = authService;
        }

        [SessionTimeout]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            PaginatedList<DashboardModel> result = new PaginatedList<DashboardModel>();
            var username = TempData.Peek("UserID").ToString();
            try
            {
                string userid = HttpContext.Session.GetString("UserID");
                var userDetail = await _authService.GetUserDetail(userid);
                var roleName = await _authService.GetRoleName(userDetail.ROLEID);

                TempData["ActiveMenu"] = "VOS_HOME_01";
                
                switch (roleName.ToUpper())
                {
                   
                    case StaticValue.Role_operator:
                        //Perubahan Transaksi
                        var countPerubahanTransaksi = await _dashboardService.GetPerubahanTransaksi(roleName, userid);
                        ViewData["countPerubahanTransaksi"] = countPerubahanTransaksi;
                        break;
                }

            }
            catch (Exception ex)
            {
                TempData["Error"] = "Login Failed";
            }
            return View(result);
        }
    }
}