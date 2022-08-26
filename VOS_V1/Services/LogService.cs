using VOS_V1.Contexts;
using VOS_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VOS_V1.Utility;
//using System.DirectoryServices;
//using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace VOS_V1.Services
{
    public class LogService : ILogService
    {
        private readonly VOSDBContext _context;

        public LogService(VOSDBContext context)
        {
            _context = context;
        }

        public void Log(string userID, string strExceptionMsg)
        {
            try
            {
                ErrorLog newLog = new ErrorLog();
                newLog.USERID = userID;
                newLog.EXCEPTIONMSG = strExceptionMsg;
                newLog.EXCEPTIONDATE = DateTime.Now;
                newLog.GUID = Guid.NewGuid().ToString();
                _context.ERROR_LOG.Add(newLog);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
