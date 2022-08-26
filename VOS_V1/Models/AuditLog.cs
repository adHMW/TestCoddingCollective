using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class AuditLog
    {
        [Key]
        public string GUID { get; set; }
        public string USERID { get; set; }
        public DateTime ACTIONDATE { get; set; }
        public string ACTIONTYPE { get; set; }
        public string ACTIONDESC { get; set; }
        public string ROWSID { get; set; }
    }
}
