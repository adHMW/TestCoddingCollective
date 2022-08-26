using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.ViewModels
{
    public class ListTransaksiViewModel
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItem { get; private set; }
        //
        public string TRANSID { get; set; }
        public string JENISTRANSID { get; set; }
        public string CABANG { get; set; }
        public string CREATEBY { get; set; }
        public string SOURCE { get; set; }
        public string UPLOAD_ID { get; set; }
        public string TO_USER { get; set; }
        public string TO_ROLE { get; set; }
        public string STATUS { get; set; }
        public string STATUS_REJECT { get; set; }
        //
        public string FAKTUR_ID { get; set; }
        public string STATUS_FAKTUR { get; set; }
        public string INVOICE_NO{ get; set; }

        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }


        //

        public PaginatedList<VOS_V1.ViewModels.TransaksiViewModel> Transaksis { get; set; }
        public ListTransaksiViewModel() {
            this.Transaksis = new PaginatedList<TransaksiViewModel>();
               
        }

        public string WORKFLOW_MSG { get; set; }

        public IEnumerable<string> getSelectedIds()
        {
            return (from t in this.Transaksis where t.SELECTED select t.TRANSID).ToList();
        }
    }
}
