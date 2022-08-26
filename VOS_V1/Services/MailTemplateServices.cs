using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using VOS_V1.Contexts;
using VOS_V1.Models;
using VOS_V1.Utility;

namespace VOS_V1.Services
{
    public class MailTemplateServices : IMailTemplateServices
    {
        public IConfiguration Configuration { get; }

        private readonly VOSDBContext _context;

        public MailTemplateServices(VOSDBContext context)
        {
            _context = context;
        }

        public MailTemplateModel getOneMailTamplateByName(string process)
        {
            MailTemplateModel MailTemplate = _context.MAIL_TEMPLATE.Where(x => x.NAME.ToUpper().Equals(process) || x.STATUS_WORKFLOW.ToUpper().Equals(process)).FirstOrDefault();

            return MailTemplate;
        }

        public string GetSMTPIPValue()
        {
            return _context.T_PARAM.Where(x => x.NAME.ToUpper().Equals("SMTPURL")).FirstOrDefault().VALUE;
        }

        public string GetMailFormValue()
        {
            return _context.T_PARAM.Where(x => x.NAME.ToUpper().Equals("MAILFROM")).FirstOrDefault().VALUE;
        }

        public List<string> GetAllMailActiveRole_LS(string roleID)
        {
            var userAssign =
                 from npk in _context.USER_VOS
                 join role in _context.ROLE_VOS on npk.ROLEID equals role.ROLEID
                 where role.ROLENAME.ToUpper().Equals(roleID) && npk.STATUS.ToUpper().Equals(StaticValue.activeCOA.ToUpper())
                 select npk.ADEMAIL;
            return userAssign.ToList();
        }

        public string GetMailActiveUserId_LS(string userId)
        {

            var userAssign =
                  from  npk in _context.USER_VOS 
                  where npk.USERID.ToUpper().Equals(userId.ToUpper()) && npk.STATUS.ToUpper().Equals(StaticValue.activeCOA.ToUpper())
                  select npk.ADEMAIL;
            return userAssign.FirstOrDefault();

          
        }

        public void sendEmail(string subject, string body, string userTo)
        {
            try
            {
                Console.WriteLine("Send Email " + subject);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(GetMailFormValue())
                };


                if (!string.IsNullOrEmpty(userTo))
                {
                    message.To.Add(new MailAddress(userTo));
                }

                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;
                SmtpClient client = new SmtpClient(GetSMTPIPValue(), 0x19);
                client.Timeout = 600000; //10
                client.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void sendEmailWithlAttachment(string subject, string body, string userTo)
        {
            try
            {
                Console.WriteLine("Send Email " + subject);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(GetMailFormValue())
                };


                if (!string.IsNullOrEmpty(userTo))
                {
                    message.To.Add(new MailAddress(userTo));
                }
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("D:\\Memo pembayaran\\Memo Pembayaran.pdf");
                message.Attachments.Add(attachment);

                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;
                SmtpClient client = new SmtpClient(GetSMTPIPValue(), 0x19);
                client.Timeout = 600000; //10
                client.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private string PopulateBody(string description)
        //{

        //    SFTPModel sftpModel = new SFTPModel();

        //    string AppPath = sftpModel.getParameter("APP_PATH_BAT");
        //    string body = string.Empty;
        //    using (StreamReader reader = new StreamReader(AppPath + @"\" + "MailTemplate.html"))
        //    {
        //        body = reader.ReadToEnd();
        //    }

        //    body = body.Replace("{Description}", description);
        //    return body;
        //}

        public string PopulateBody(string Template, string subject, string userTo, string description)
        {

            var template = getOneMailTamplateByName(Template);

            string body = template.VALUE;
            body= body.Replace("{Description}", description);
            sendEmail(subject, body, userTo);

            return body;
        }

        public string SendMailToRole(string Template, string subject,  string role, string description)
        {

            var template = getOneMailTamplateByName(Template);

            string body = template.VALUE;
            body = body.Replace("{Description}", description);
            List<string> EmailLists = this.GetAllMailActiveRole_LS(role);

            foreach(string email in EmailLists)
            {
                sendEmail(subject, body, email);
            }
           

            return body;
        }
        public string SendMailToRolePDF(string Template, string subject, string role, string description)
        {

            var template = getOneMailTamplateByName(Template);

            string body = template.VALUE;
            body = body.Replace("{Description}", description);
            List<string> EmailLists = this.GetAllMailActiveRole_LS(role);

            foreach (string email in EmailLists)
            {
                sendEmailWithlAttachment(subject, body, email);
            }


            return body;
        }

        //1 specifiec user
        public string SendMailToUser(string Template, string subject, string userTo, string description)
        {

            var template = getOneMailTamplateByName(Template);

            string body = template.VALUE;
            body = body.Replace("{Description}", description);
            string email = this.GetMailActiveUserId_LS(userTo);
            sendEmail(subject, body, email);

            return body;
        }


    }
}
