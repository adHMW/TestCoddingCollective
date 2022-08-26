using VOS_V1.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Services
{
    public interface IAuditLogService
    {
        void Log(string userID, string actionType, string actionDesc);
        //void LogMaster(string userID, string actionType, string actionDesc);
    }
}
