using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOS_V1.Contexts;
using VOS_V1.ViewModels;
using VOS_V1.Models;
using VOS_V1.Utility;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace VOS_V1.Services
{
    public class DashboardService : IDashboardService
    {
        public IConfiguration Configuration { get; }

        private readonly VOSDBContext _context;

        public DashboardService(VOSDBContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<DashboardModel>> GetDashboardData(int page, int rowPerPage)
        {
            try
            {
                var monthPeriod = DateTime.Now.AddMonths(1).Month;
                var yearPeriod = DateTime.Now.AddMonths(1).Year;

                var dashboard = _context.DASHBOARD_VOS.AsQueryable().OrderByDescending(a => a.CREATEDDATE);

                return await PaginatedList<DashboardModel>.CreateAsync(dashboard, page, rowPerPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public async Task<int> GetPerubahanTransaksi(string roleName, string userID)
        {
            try
            {
                var dashboard = (from tw in _context.DELEGATE_MULTI_VIEW_VOS
                                 where (tw.STATUS.ToUpper().Equals(StaticValue.StatusWaitingToEditOperator)
                                        && !tw.STATUS_REJECT.ToUpper().Equals(StaticValue.statusPenyelesaian_KL_Tertunda)
                                        && !tw.STATUS_REJECT.ToUpper().Equals(StaticValue.statusPenyelesaian_memo)
                                        && tw.TO_USER.ToUpper().Equals(userID))
                                 select tw);
                dashboard = dashboard.GroupBy(z => new { z.TRANSID, z.UPLOAD_TRANSID }).Select(group => group.First());

                return dashboard.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
