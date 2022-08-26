using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class ParamModel
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string VALUE { get; set; }
        public string STATUS { get; set; }
    }
}
