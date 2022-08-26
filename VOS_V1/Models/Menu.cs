using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class Menu
    {
        public string MENUID { get; set; }
        public string MENUNAME { get; set; }
        public string MENUCONTROLLER { get; set; }
        public string MENUPARENT { get; set; }
    }
}
