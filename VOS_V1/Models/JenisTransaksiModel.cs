using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class JenisTransaksiModel
    {
        [Key]
        public string JENISTRANSID { get; set; }

        public string JENISTRANSNAME { get; set; }

        public string STATUS { get; set; }

        public DateTime? CREATEDDATE { get; set; }

        public string CREATEBY { get; set; }
    }
}
