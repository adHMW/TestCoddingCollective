using VOS_V1.Models;
using VOS_V1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace VOS_V1.Contexts
{
    public class VOSDBContext : DbContext
    {
        public VOSDBContext(DbContextOptions<VOSDBContext> options) : base(options)
        {
        }

        public DbSet<Users> USER_VOS { get; set; }
        public DbSet<Role> ROLE_VOS { get; set; }
        public DbSet<SequenceTransaksiModel> SEQUENCE_TRANSAKSI { get; set; }
        public DbSet<WorkflowModel> WORKFLOW_VOS { get; set; }
        public DbSet<ViewValidasiDataViewModel> VIEW_VALIDASI_DATA { get; set; }
        public DbSet<MailTemplateModel> MAIL_TEMPLATE { get; set; }
        public DbSet<ParamModel> T_PARAM { get; set; }
        public DbSet<DashboardModel> DASHBOARD_VOS { get; set; }
        public DbSet<DelegateMultiTransaksiViewModel> DELEGATE_MULTI_VIEW_VOS { get; set; }
        public DbSet<AuditLog> AUDIT_LOG { get; set; }
        public DbSet<ErrorLog> ERROR_LOG { get; set; }
    }
}
