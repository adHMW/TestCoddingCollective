using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOS_V1.Models;
using VOS_V1.ViewModels;

namespace VOS_V1.Services
{
    public interface IDashboardService
    {
        Task<PaginatedList<DashboardModel>> GetDashboardData(int page, int rowPerPage);
        Task<int> GetPerubahanTransaksi(string roleName, string userID);
    }
}
