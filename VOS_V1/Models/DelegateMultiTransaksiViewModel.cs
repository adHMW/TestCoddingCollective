using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.ViewModels
{
    public class DelegateMultiTransaksiViewModel
    {
        [Key]
        public string TRANSID { get; set; }
        public string JENISTRANSID { get; set; }
        public string KRITERIA_USAHA { get; set; }
        public string WAJIB_PAJAK_LN { get; set; }
        public string NIK { get; set; }
        public string NPWP { get; set; }
        public string NAMA { get; set; }
        public string ALAMAT { get; set; }
        public DateTime? INVOICE_DATE { get; set; }
        public string CURRENCY { get; set; }
        public string KURS_PAJAK { get; set; }
        public string INVOICE_NO { get; set; }
        public decimal HARGA_JUAL_DOC { get; set; }
        public string JENIS_JASA_KENA_PAJAK { get; set; }
        public decimal HARGA_JUAL { get; set; }
        public string KETERANGAN_JASA { get; set; }
        public string TARIFF_PPN { get; set; }
        public string COA { get; set; }
        public decimal PPN_DOC { get; set; }
        public string CABANG { get; set; }
        public decimal PPN_IDR { get; set; }
        public string VOUCHER_PEMBUKUAN_FILEID { get; set; }
        public string MEMO_PENY_FILEID { get; set; }
        public string INVOICE_FILEID { get; set; }
        public string DOC_WAPU_FILEID { get; set; }
        public string DOC_PEMBATALAN_FILEID { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public string CREATEBY { get; set; }
        public DateTime? UPDATEDDATE { get; set; }
        public string UPDATEBY { get; set; }
        public string SOURCE { get; set; }
        public string PROCESS_ID { get; set; }
        public string UPLOAD_TRANSID { get; set; }
        public string TO_USER { get; set; }
        public string STATUS { get; set; }
        public string ID { get; set; }
        public string WORKFLOW_MSG { get; set; }
        public string TO_ROLE { get; set; }
        public string COAPPN { get; set; }
        public string STATUS_REJECT { get; set; }

    }
}
