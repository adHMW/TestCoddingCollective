using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Models
{
    public class Users
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter UserID")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 25")]
        [Key]
        public string USERID { get; set; }

        public string ADDISPLAYNAME { get; set; }

        public string ADEMAIL { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        //[StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 25")]
        //public string Password { get; set; }

        [Required(ErrorMessage = "Please select Role")]
        public int ROLEID { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter NPK")]
        //[StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Length must be 10 digits")]
        //public string NPK { get; set; }

        public string BRANCHID { get; set; }
        public string NPK { get; set; }
        public string STATUS { get; set; }

        public DateTime? LASTSIGNON { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string CREATEBY { get; set; }
        public string STATUS_CUTI { get; set; }
    }
}
