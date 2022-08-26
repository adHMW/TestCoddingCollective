using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VOS_V1.ViewModels;

namespace VOS_V1.Utility
{
    public static class StaticValue
    {
        public const string AttachmentRemoved = "Attachment Removed Successfully";
        public const string NoDataFound = "No Data Found";
        
        public const string Menu_User = "VOS_USRREG_01";
        
        public const string Role_Admin = "ADMIN";
        public const string Role_IDM = "ID MANAGEMENT";
        public const string Role_SL = "SalesLeader";
        public const string Role_HO = "HeadOffice";
        public const string Role_checker = "CHECKER";
        public const string Role_validator = "VALIDATOR";
        public const string Role_approver = "APPROVER";
        public const string Role_acc_op = "ACCOUNTING OPERATION";
        public const string Role_acc_spv = "ACCOUNTING SUPERVISOR";
        public const string Role_operator = "OPERATOR";
        public const string Role_system = "SYSTEM";
        public const string Role_PUK = "PUK";
        public const string Role_Viewer = "VIEWER";


        //Audit Type
        public const string Audit_LogIn = "Log In";
        public const string Audit_LogOut = "Log Out";
        public const string Audit_CreateUser = "Create User";
        public const string Audit_EditUserRole = "Edit User Role";
        public const string Audit_EditUserBranch = "Edit User Branch";
        public const string Audit_ChangeStatusUserBranch = "Change Status User Branch";
        public const string Audit_DeleteUser = "Delete User";
        public const string Audit_DownloadUser = "Download User";
        public const string Audit_UploadSales = "Upload Sales";
        public const string Audit_DlRptClaim = "Download Report Claimed";
        public const string Audit_DlRptUnclaim = "Download Report Unclaimed";
        public const string Audit_DlRptGrowth = "Download Report Growth";
        //NPWP Faktur Pajak Khusus
        public const string Audit_Master_Create_NPWPFakturPajakKhusus = "Create NPWP Faktur Pajak Khusus";
        public const string Audit_Master_Edit_NPWPFakturPajakKhusus = "Edit NPWP Faktur Pajak Khusus";
        public const string Audit_Master_Download_NPWPFakturPajakKhusus = "Dobwload NPWP Faktur Pajak Khusus";
        public const string Audit_Master_Edit_Status_NPWPFakturPajakKhusus = "Edit Status NPWP Faktur Pajak Khusus";
        //NPWP Faktur Pajak Khusus
        public const string Audit_Master_Create_NPWP_Nasabah = "Create NPWP_Nasabahs";
        public const string Audit_Master_Edit_NPWP_Nasabah  = "Edit NPWP_Nasabahs";
        public const string Audit_Master_Download_NPWP_Nasabah = "Dobwload NPWP_Nasabah";
        public const string Audit_Master_Edit_Status_NPWP_Nasabah = "Edit Status NPWP_Nasabah";
        //Audit Tarif PPN
        public const string Audit_Master_Create_TarifPPN = "Create Tarif PPN";
        public const string Audit_Master_Edit_TarifPPN = "Edit Tarif PPN";
        public const string Audit_Master_Download_TarifPPN = "Dobwload Tarif PPN";
        public const string Audit_Master_Edit_Status_TarifPPN = "Edit Status Tarif PPN";
        //Audit UserAssign
        public const string Audit_Master_Create_UserAssign = "Create User Assign";
        public const string Audit_Master_Edit_UserAssign = "Edit User Assign";
        public const string Audit_Master_Download_UserAssign = "Dobwload User Assign";
        public const string Audit_Master_Edit_Status_UserAssign = "Edit Status User Assign";
        //Audit Jenis Transaksi
        public const string Audit_Master_Create_JenisTransaksi = "Create Jenis Transaksi";
        public const string Audit_Master_Edit_JenisTransaksi = "Edit Jenis Transaksi";
        public const string Audit_Master_Download_JenisTransaksi = "Dobwload Jenis Transaksi";
        public const string Audit_Master_Edit_Status_JenisTransaksi = "Edit Status Jenis Transaksi";
        public const string Audit_Master_Delete_Status_JenisTransaksi = "Delete Status Jenis Transaksi";
        //Audit UploadFileName
        public const string Audit_Master_Create_Upload_FileName = "Create Upload File Name";
        public const string Audit_Master_EditUpload_FileNamei = "Edit Upload File Name";
        public const string Audit_Master_Download_Upload_FileName = "Dobwload Upload File Namei";
        public const string Audit_Master_Edit_Status_Upload_FileName = "Edit Upload File Name";
        //Audit UploadFileName
        public const string Audit_Master_Create_Branch = "Create Upload File Name";
        public const string Audit_Master_Edit_Branch = "Edit Upload File Name";
        public const string Audit_Master_Download_Branch = "Dobwload Upload File Namei";
        public const string Audit_Master_Edit_Status_Branch = "Edit Upload File Name";
        public const string Audit_Master_Delete_Status_Branch = "Delete Upload File Name";


        //EndAudit Type
        public const string JDKLPPNT = "JT003";//jenis dengan klppn tertunda
        public const string JDKLPPN = "JT002";//jenis dengan klppn
        public const string JTKLPPN = "JT001";//jenis tanpa klppn
        public const string TARIF_PPN = "10%";

        public const string JenisCoaPPN = "1";
        public const string JenisCoaPendapatan = "2";

        //jurnal code
        public const string COAPPNkredit = "0245813020";
        public const string COAPPN999 =    "2999999990";
        public const string COAPPN927 =    "2999999270";
        public const string COAPPNTemplate =    "299999";
        public const string CodeKreditJurnal = "62";
        public const string CodeDebitJurnal = "61";
        public const string Branch927 = "927";
        public const string Branch999 = "999";

        //recon Code
        public const string CodeKreditRecon = "CR";
        public const string CodeDebitRecon = "DR";

        public const string appCodekepala0 = "VOSFM";
        public const string appCodekepala1 = "VOSIM";


        //Operator
        public const string newInputOperator = "NEW TRANSAKSI";
        //
        public const string editInputOperator = "TRANSAKSI EDITED";
        public const string editInputOperatorBATAL = "BATAL TRANSAKSI";
        //
        public const string submitInputOperator = "INPUT TRANSAKSI";
        public const string submitUploadOperator = "UPLOAD TRANSAKSI";
        public const string submitSFTPOperator = "SFTP TRANSAKSI";
        //Checker
        public const string statusWaitingChecker = "WAITING TO CHECK";
        public const string approveChecker = "CHECKED";
        //reject
        public const string rejectChecker = "REJECT CHECKED";
        //jurnal
        public const string JURNAL_RECLASS = "JURNAL RECLASS";
        //
        //ACC OPS
        public const string statusWaitingAccOps = "WAITING TO POST";
        public const string approveAccOps = "POSTED DRAFT";
        //reject
        public const string rejectAccOps = "REJECT POSTED DRAFT";
        //ACC OPS SPV
        public const string jurnalDraft = "JURNAL DRAFT";
        public const string statusWaitingAccOpsValidator = "WAITING TO APPV POST";
        public const string approveAccOpsValidator = "APPROVE POSTED DRAFT SPV";
        //
        public const string rejectAccOpsValidator = "REJECT POSTED DRAFT SPV";
        //
        //Validator
        public const string statusWaitingValidator = "WAITING TO VALIDATE";
        public const string statusWaitingPostJurnal = "WAITING TO POST JURNAL";
        public const string statusWaitingPostJurnalPembayaran = "WAITING TO POST JURNAL PAYMENT";
        public const string statusWaitingPostRecon = "WAITING TO POST RECON";
        public const string approveValidator = "VALIDATED";
        //reject
        public const string rejectValidator = "REJECT VALIDATED";
        public const string rejectNonNPWP = "REJECT NON NPWP";
        public const string rejectUnRecon = "REJECT UN RECON";
        //NPWP Khusus
        public const string statusIsNPWPFakturPajakKhusus = "NPWP KHUSUS";
        public const string statusNonNPWPFakturPajakKhusus = "BUKAN NPWP KHUSUS";

        //Approver
        public const string jurnalPosted = "JURNAL POSTED";
        public const string statusWaitingRecon = "WAITING TO RECON";
        public const string statusWaitingApprover = "WAITING TO GENERATE NO FAKTUR";
        public const string generateNoFakturPajak = "FAKTUR PAJAK GENERATED";
        //approve
        public const string approveApprover = "APPROVED";
        //reject
        public const string rejectApprover = "REJECT APPROVER";
        //

        //report Efaktur (A170)
        public const string statusWaitingEfakturReported = "WAITING TO REPORT EFAKTUR";
        public const string EfakturReported = "EFAKTUR REPORTED";
        //pesan excel Efaktur berhasil
        public const string EfakturReportedExcel= "Approval Sukses";
        //report Efaktur rejected
        public const string EfakturRejected = "EFAKTUR REJECTED";
        //pesan excel Efaktur reject
        public const string EfakturRejectedExcel = "Reject";
        //

        ////reject Efaktur A190
        //public const string StatusWaitingEditEfakturIdentity = "WAITING TO EDIT EFAKTUR IDENTITY";
        //public const string EfakturIdentityEdited = "EFAKTUR IDENTITY EDITED";

        ////reject Efaktur A191
        //public const string StatusWaitingApproveEditEfakturIdentity = "WAITING TO APPROVE EDIT EFAKTUR IDENTITY";
        //public const string EfakturIdentityEditAproved = "EFAKTUR IDENTITY EDIT APPROVED";


        //Ekualisasi Pendapatan (A200)_Validator
        public const string statusWaitingEkualisasiPendapatan_Validator = "WAITING TO EKUALISASI PENDAPATAN VALIDATOR";
        public const string EkualisasiPendapatanPosted_Validator = "EKUALISASI PENDAPATAN DRAFTED VALIDATOR";
        //report Efaktur rejected
        public const string EkualisasiPendapatanRejected_Validator = "VALIDATOR REJECTED EKUALISASI PENDAPATAN";
        //

        //Ekualisasi Pendapatan (A200)_Approver
        public const string statusWaitingEkualisasiPendapatan_Approver = "WAITING TO EKUALISASI PENDAPATAN APPROVER";
        public const string EkualisasiPendapatanPosted_Approver = "EKUALISASI PENDAPATAN POSTED APPROVER";
        //report Efaktur rejected
        public const string EkualisasiPendapatanRejected_Approver = "EKUALISASI PENDAPATAN REJECTED APPROVER";

        ////Ekualisasi Pendapatan (A200) Approver
        //public const string statusWaitingEkualisasiPendapatan = "WAITING TO EKUALISASI PENDAPATAN";
        //public const string EkualisasiPendapatanPosted = "EKUALISASI PENDAPATAN POSTED";
        ////report Efaktur rejected
        //public const string EkualisasiPendapatanRejected = "EKUALISASI PENDAPATAN REJECTED";


        //Pembayaran PPN (A210) Validator
        public const string rejectPembayaran = "REJECT PEMBAYARAN";
        public const string statusPembayaran_Validator = "WAITING TO DRAFT PEMBAYARAN VALIDATOR";
        public const string Pembayaran_Validator = "DRAFT PEMBAYARAN POSTED VALIDATOR";
        //report Efaktur rejected
        public const string RejectPembayaran_Validator = "DRAFT PEMBAYARAN REJECTED VALIDATOR";

        //Pembayaran PPN (A210) aprover
        public const string statusPembayaran_Approver = "WAITING TO APPROVE PEMBAYARAN APPROVER";
        public const string Pembayaran_Approver = "DRAFT PEMBAYARAN APPROVED APPROVER";
        //report Efaktur rejected
        public const string RejectPembayaran_Approver = "DRAFT PEMBAYARAN REJECTED APPROVER";

        //Pembayaran PPN (A210) AccOps
        public const string statusPembayaran_AccOps = "WAITING TO APPROVE PEMBAYARAN ACCOPS";
        public const string Pembayaran_AccOps = "DRAFT PEMBAYARAN APPROVED ACC OPS";
        //report Efaktur rejected
        public const string RejectPembayaran_AccOps = "DRAFT PEMBAYARAN REJECTED ACCOPS";

        //Pembayaran PPN (A210) Acc SPV
        public const string statusPembayaran_AccSPV = "WAITING TO APPROVE PEMBAYARAN ACC SPV";
        public const string Pembayaran_AccSPV = "DRAFT PEMBAYARAN APPROVED ACC SPV";
        //report Efaktur rejected
        public const string RejectPembayaran_AccSPV = "DRAFT PEMBAYARAN REJECTED ACC SPV";

        //Pembayaran PPN (A210) PUK
        public const string statusPembayaran_PUK = "WAITING TO APPROVE PEMBAYARAN PUK";
        public const string Pembayaran_PUK = "DRAFT PEMBAYARAN POSTED PUK";
        public const string tanggal_approval_PUK = "WAITING TO APPROVAL PUK";
        public const string pembayaran_selesai = "PEMBAYARAN SELESAI";
        //report Efaktur rejected
        public const string RejectPembayaran_PUK = "DRAFT PEMBAYARAN REJECTED PUK";
        public const string reffPembayaranPPN = "999003VOS";
        public const string ApproveValidator = "WAITING TO APPROVAL APPROVER";


        //JurnalPUK
        public const string COAPPN999_PPN = "2999998880";
        public const string COAPPN927_PPN = "0245813020";
        public const string COAPPN999_PPN_2 = "2999999270";



        //FLOW B Opertor
        public const string flowB_Checker = "WAITING TO CHECK PENYELESAIAN DENGAN KL";
        public const string flowB_validator = "WAITING TO VALIDATE PENYELESAIAN DENGAN KL";
        public const string flowB_acc_op = "WAITING TO POST PENYELESAIAN DENGAN KL";
        public const string flowB_acc_spv = "WAITING TO APP POST PENYELESAIAN DENGAN KL";
        public const string flowB_approver = "WAITING TO APPROVER PENYELESAIAN DENGAN KL";

        public const string flowB_Checker_memo = "WAITING TO CHECK PENYELESAIAN DENGAN MEMO";
        public const string flowB_validator_memo = "WAITING TO VALIDATE PENYELESAIAN DENGAN MEMO";
        public const string flowB_acc_op_memo = "WAITING TO POST PENYELESAIAN DENGAN MEMO";
        public const string flowB_acc_spv_memo = "WAITING TO APP POST PENYELESAIAN DENGAN MEMO";
        public const string flowB_approver_memo = "WAITING TO APPROVER PENYELESAIAN DENGAN MEMO";

        public const string Penyelesaian_KL_Tertunda_Submit = "SUBMIT PENYELESAIAN KL TERTUNDA";
        public const string Penyelesaian_data_transaksi = "WAITING TO PENYELESAIAN TRANSAKSI";
        public const string pernahBayar = "PERNAH BAYAR";

        //dengan KL
        public const string statusPenyelesaian_KL_Tertunda = "WAITING PENYELESAIAN DENGAN KL";
        public const string Waiting_to_check_FlowB_denganKL = "WAITING TO CHECK PENYELESAIAN TRANSAKSI DENGAN KL";
        public const string Waiting_to_check_FlowB_denganMemo = "WAITING TO CHECK PENYELESAIAN TRANSAKSI DENGAN MEMO";
        //dengan Memo
        public const string statusPenyelesaian_memo = "WAITING PENYELESAIAN DENGAN MEMO";

        public const string statusFlowBApproval = "WAITING TO APPROVE APPROVER";
        public const string staturFlowBselesaiMemo = "TRANSAKSI FLOW B MEMO DONE";
        public const string staturFlowBselesaiKL = "TRANSAKSI FLOW B KL DONE";

        public const string statusA25 = "WAITING TO EDIT OPERATOR";


        //public const string statusWaitingApprovalPUK_PPN = "PUK APPROVED";
        //public const string status_PPN = "WAITING TO APPROVAL PUK ";
        //public const string statusCurrent_PPN = "EFAKTUR REPORTED";
        //public const string statusReject_PPN = "EFAKTUR REJECT";



        public const string reconPosted = "RECON POSTED";
        public const string reconed = "RECONED";
        public const string reconReverse = "REVERSE";
        ////


        //workflow approval status jurnal batal
        public const string JournalBatal = "CANCEL";
        public const string JournalBatalRelass = "WAITING TO POST JURNAL RECLASS";
        //public const string JournalBatalPosted = jurnalPosted +" CANCEL";
        public const string JournalBatalPostedReversed = jurnalPosted +" REVERSED";
        public const int JurnalReverse = 1;
        public const int JurnalNormal = 0;
        //
        //workflow approval status Recon batal
        public const string ReconBatal = "CANCEL";
        public const string ReconBatalPosted = reconed + " CANCEL";
        public const string ReconBatalPostedReversed = reconed + " REVERSED";
        public const int ReconReverse = 1;
        public const int ReconNormal = 0;


        //workflow next approval status
        //
        public const string statusWaitingToGenerateNoFaktur = "WAITING TO GENERATE NO FAKTUR";
        //
        //WORKFLOW EDIT NPWP
        //operator
        public const string StatusWaitingEditInputOperator = "WAITING TO EDIT OPERATOR";
        public const string editInputOperatorNPWP = "EDIT NPWP";
        //checker

        //approval status
        public const string approve = "DONE";
        public const string reject = "REJECTED";
        public const string cancel = "CANCEL";
        public const string batal = "BATAL";
        public const string TransaksiSelesai = "TRANSAKSI SELESAI";
        public const string TransaksiKLSelesai = "TRANSAKSI KL DONE";
        public const string StatusWaitingToEditOperator = "WAITING TO EDIT OPERATOR";

        //approval COA
        public const string submitCOA = "ON VALIDATE";
        public const string rejectCOA = "REJECT";
        public const string validatedCOA = "VALIDATED";
        public const string activeCOA = "ACTIVE";
        public const string inactiveCOA = "IN ACTIVE";

        //FMTR Status
        public const string FMTRActive = "ACTIVE";
        public const string FMTRInActive = "INACTIVE";
        public const string FMTRInProcess = "INPROCESS";
        public const string FMTRUsed = "USED";
        public const string FMTRActiveApprove = "ACTIVE APPROVAL";
        public const string FMTRInActiveApprove = "INACTIVE APPROVAL";
        public const string FMTRApprove = "APPROVE";
        public const string FMTRReject = "REJECT";


        //NoFaktur Status
        //public const string FAKTURActive = "FAKTUR ACTIVE";
        //public const string FAKTURBelumLapor = "FAKTUR BELUM LAPOR";
        //public const string FAKTURLapor = "FAKTUR SUDAH LAPOR";
        //public const string FAKTURBatal = "FAKTUR BATAL";
        public const string FAKTURActive = "ACTIVE";
        public const string FAKTURBelumLapor = " BELUM LAPOR";
        public const string FAKTURLapor = "SUDAH LAPOR";
        public const string FAKTURBatal = "BATAL";
        //Generate parameter  No Faktur Status

        public const string ParameterFAKTURWaitingApprove = "ON VALIDATE";
        public const string ParameterFAKTURActive = "ACTIVE";
        public const string ParameterFAKTURiNActive = "INACTIVE";
        public const string ParameterFAKTURReject = "REJECT";
        public const string ParameterFAKTURAprove = "VALIDATED";


        //NPWP
        public const string NPWPNasabahActive = "ACTIVE";
        public const string NPWPNasabahInactive = "IN ACTIVE";
        public const string NPWPNasabahPindahAlamat = "PINDAH ALAMAT";

        //KODE_JENIS_FAKTUR_PAJAK
        public const string JENIS_DEVAULT = "010";
        public const string JANIS_BATAL = "011";
        public const string JENIS_WAPU_MT_10JT = "020";
        public const string JENIS_BUMN_MT_1JT = "030";
        public const string JENIS_PPN_MT_0 = "070";

        //Status Reject Transaksi
        public const string TRANSAKSI_BARU = "TRANSAKSI BARU";
        public const string TRANSAKSI_EDITED = "TRANSAKSI EDITED";
        public const string TRANSAKSI_BARU_CD = "NE";
        //
        public const string TRANSAKSI_BATAL = "BATAL TRANSAKSI";
        public const string TRANSAKSI_BATAL_CD = "BT";
        public const string TRANSAKSI_EDIT_AMOUNT = "TRANSAKSI EDIT AMOUNT";
        public const string TRANSAKSI_EDIT_AMOUNT_CD = "SA";
        public const string TRANSAKSI_EDIT_DATA = "TRANSAKSI EDIT DATA";
        public const string TRANSAKSI_EDIT_DATA_CD = "SD";
        public const string TRANSAKSI_EDIT_NPWP = "TRANSAKSI EDIT NPWP";
        public const string TRANSAKSI_EDIT_NPWP_CD = "SN";
        public const string TRANSAKSI_REJECT_RECON = "TRANSAKSI REJECT RECON";
        public const string TRANSAKSI_REJECT_RECOn_CD = "RC";
        public const string TRANSAKSI_EDIT_IDENTITY = "TRANSAKSI EDIT IDENTITY";
        public const string TRANSAKSI_EDIT_IDENTITY_CD = "SI";
        //PENYELESAIAN
        public const string TRANSAKSI_PENYELESAIAN_PPN_MEMO = "TRANSAKSI PENYELESAIAN PPN MEMO";
        public const string TRANSAKSI_PENYELESAIAN_PPN_MEMO_CD = "RC";
        public const string TRANSAKSI_PENYELESAIAN_PPN = "TRANSAKSI PENYELESAIAN PPN";
        public const string TRANSAKSI_PENYELESAIAN_PPN_CD = "RC";

        public const string TRANSAKSI_PENYELESAIAN = "010";

        //MailTemplate
        public const string DEFAULT_MAIL_TEMP = "DEFAULT";
        public const string ADD_USER_TEMP = "ADDUSER";
        public const string ADD_USER_ASSIGN_TEMP = "ADDASSIGN";
        public const string REVISI_MAIL_TEMP = "REVISI A25";
        public const string REJECT_TRANS_ID = "REJECT TRANS ID";
        public const string PEMBAYARAN = "PEMBAYARAN";
        public const string PEMBAYARAN_NONPUK = "PEMBAYARAN_NONPUK";
        public const string EDIT_AMOUNT = "EDIT AMOUNT";
        public const string EDIT_IDENTITY = "EDIT IDENTITY";
        public const string EDIT_NPWP = "EDIT NPWP";
        public const string BATAL_TRANSAKSI = "BATAL TRANSAKSI";



        //status Cuti User
        public const string CUTI = "CUTI";
        public const string MASUK = "MASUK";

        //Filter ekualisasi
        public const string Ekualisasi_YTD = "YTD";
        public const string Ekualisasi_MTD = "MTD";

        //Golongan WAPU npwp faktur pajak khusus
        public const string wapuBUMN = "WAPU BUMN";
        public const string wapuBP = "WAPU BP";
        public const string bukanWAPU = "BUKAN WAPU";

        public static string SubjectFormated(string TransID)
        {
           
            string value = "";

            value = "APPROVAL VOS " + TransID;

            return value;
        }

        public static string SubjectFormatedPembayaran(string TransID)
        {

            string value = "";

            value = "MEMO PEMBAYARAN VOS " + TransID;

            return value;
        }


        public static string SubjectFormatedAddUser(string userAD)
        {

            string value = "";

            value = "REGISTRASI VOS " + userAD;

            return value;
        }

        public static string SubjectFormatedAddUserAssign(string userAD)
        {

            string value = "";

            value = "Aktivasi User Assign " + userAD;

            return value;
        }
        public static string SubjectFormatedRevisiA25(string FileName)
        {

            string value = "";

            value = "Revisi File Upload A25 VOS " + FileName;

            return value;
        }

        public static string  NPWPFormatted(string NPWP)
        {
            //01 234 567 8   91011 121314
            //00 000 000 0   000   000
            //00.000.000.0 - 000.000

            string value= "";

            value = NPWP.Substring(0,2)+"."+ NPWP.Substring(2, 3) + "."+ NPWP.Substring(5, 3) + "."+ NPWP.Substring(8,1) + "-"+ NPWP.Substring(9, 3) + "."+ NPWP.Substring(12, 3);

            return value;
        }

        public static string NPWPFormattedRemove(string NPWP)
        {
            //01 234 567 8   91011 121314
            //00 000 000 0   000   000
            //00.000.000.0 - 000.000

            string value = "";

            //value = NPWP.Replace("[^0-9]", "");

            Regex rgx = new Regex("[^0-9]");
            value = rgx.Replace(NPWP, "");

           

            return value;
        }

        public static List<string> getListTahun()
        {
            List<string> value = new List<string>();
            int tahun = Int32.Parse(System.DateTime.Now.ToString("yyyy"));
            for (int i = tahun; i >= tahun - 10; i--)
            {
                value.Add(i.ToString());
            }

            return value;
        }

        public static List<string> getListTanggal()
        {
            List<string> value = new List<string>();

            value.Add("01");
            value.Add("02");
            value.Add("03");
            value.Add("04");
            value.Add("05");
            value.Add("06");
            value.Add("07");
            value.Add("08");
            value.Add("09");
            value.Add("10");
            value.Add("11");
            value.Add("12");
            value.Add("13");
            value.Add("14");
            value.Add("15");
            value.Add("16");
            value.Add("17");
            value.Add("18");
            value.Add("19");
            value.Add("20");
            value.Add("21");
            value.Add("22");
            value.Add("23");
            value.Add("24");
            value.Add("25");
            value.Add("26");
            value.Add("27");
            value.Add("28");
            value.Add("29");
            value.Add("30");
            value.Add("31");

            return value;
        }

        public static List<string> getListFilterEkualisasi()
        {
            List<string> value = new List<string>();
            value.Add(Ekualisasi_YTD);
            value.Add(Ekualisasi_MTD);
            return value;
        }

        public static List<string> getListFilterPPN()
        {
            List<string> value = new List<string>();
            return value;
        }

        public static List<string> getListBulan()
        {
            List<string> value = new List<string>();

            value.Add("Jan");
            value.Add("Feb");
            value.Add("Mar");
            value.Add("Apr");
            value.Add("Mei");
            value.Add("Jun");
            value.Add("Jul");
            value.Add("Agt");
            value.Add("Sep");
            value.Add("Okt");
            value.Add("Nov");
            value.Add("Des");

            return value;
        }

        public static List<string> getListBulan2()
        {
            List<string> value = new List<string>();

            value.Add("January");
            value.Add("February");
            value.Add("March");
            value.Add("April");
            value.Add("May");
            value.Add("June");
            value.Add("July");
            value.Add("August");
            value.Add("September");
            value.Add("October");
            value.Add("November");
            value.Add("December");

            return value;
        }

        public static List<string> getRoleList()
        {
            List<string> value = new List<string>();

            value.Add("OPERATOR");
            value.Add("CHECKER");
            value.Add("VALIDATOR");
            value.Add("ACCOUNTING OPERATION");
            value.Add("ACCOUNTING SUPERVISOR");
            value.Add("APPROVER");
            value.Add("PUK");

            return value;
        }
    }
}
