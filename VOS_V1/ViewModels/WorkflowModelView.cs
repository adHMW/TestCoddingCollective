using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.ViewModels
{
    public class WorkflowModelView
    {
        public string ID { get; set; }
        public string WFID { get; set; }
        public string FROM_ROLE { get; set; }
        public string FROM_USER { get; set; }
        public string TO_ROLE { get; set; }
        public string TO_USER { get; set; }
        public string CURRENT_PROCESS { get; set; }
        public string STATUS { get; set; }
        public string NEXT_PROCESS { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public DateTime? UPDATEDATE { get; set; }
        public string WORKFLOW_MSG { get; set; }
    }
}
