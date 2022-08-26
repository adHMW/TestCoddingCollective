using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.ViewModels
{
    public class TransaksiViewModel
    {
        
        public string TRANSID { get; set; }
        public bool SELECTED { get; set; } = false;
        public string JENISTRANSID { get; set; }
        public string KRITERIA_USAHA { get; set; }
        public string WAJIB_PAJAK_LN { get; set; }
        public string NIKChecker { get; set; }
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
        public string COAPPN { get; set; }
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
        public string WORKFLOW_MSG { get; set; }
        public string ID { get; set; }
        public string UPLOAD_ID { get; set; }
        public string TO_USER { get; set; }
        public string TO_ROLE { get; set; }
        public string STATUS { get;set; }
        public string STATUS_REJECT { get; set; }
        public string ROLE { get; set; }
        public string PARAM_REJECT { get; set; }
        //
        public string FAKTUR_ID { get; set; }
        public string STATUS_FAKTUR { get; set; }
        public DateTime? periodeAwal { get; set; }
        public DateTime? periodeAkhir { get; set; }
        public string FROM_ROLE { get; set; }
        public string FROM_USER { get; set; }
        public string NO_FAKTUR { get; set; }
        public string TANGGAL_FAKTUR { get; set; }
        public string MASA { get; set; }
        public string TAHUN { get; set; }
        public decimal DPP { get; set; }
        public decimal PPN { get; set; }
        public decimal PPNBM { get; set; }
        public string STATUS_APPROVE { get; set; }
        public string TANGGAL_APPROVE { get; set; }
        public string KETERANGAN { get; set; }
        public string PENANDATANGANAN { get; set; }
        public string NO_INVOICE { get; set; }
        public string USER_PEREKAM { get; set; }
        public string TANGGAL_REKAM { get; set; }
        public string USER_PENGUBAH { get; set; }
        public string TANGGAL_UBAH { get; set; }

 

    }
}
