using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class SequenceTransaksiModel
    {
        public string SEQUENCE { get; set; }
        public string YEAR { get; set; }
        public string MONTH { get; set; }
        public string DAY { get; set; }

        [Key]
        public string TYPE { get; set; }
    }
}
