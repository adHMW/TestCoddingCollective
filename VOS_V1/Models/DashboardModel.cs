using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class DashboardModel
    {
        [Key]
        public string UPLOADID { get; set; }
        public string TRANSACTIONID { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string STATUS { get; set; }
        public string INVOICENO { get; set; }
        public string JKPTYPE { get; set; }
        public Double HARGAJUAL { get; set; }
        public Double PPN { get; set; }
    }
}
