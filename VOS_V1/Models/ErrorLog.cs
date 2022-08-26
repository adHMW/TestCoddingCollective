using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class ErrorLog
    {
        [Key]
        public string GUID { get; set; }
        public string USERID { get; set; }
        public DateTime EXCEPTIONDATE { get; set; }
        public string EXCEPTIONMSG { get; set; }
    }
}
