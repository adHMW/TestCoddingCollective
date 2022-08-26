using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOS_V1.Models;

namespace VOS_V1.Services
{
    public interface IMailTemplateServices
    {
        MailTemplateModel getOneMailTamplateByName(string process);
        void sendEmail(string subject, string body, string userTo);
        string PopulateBody(string Template, string subject, string userTo, string description);
        string SendMailToRole(string Template, string subject, string role, string description);
        string SendMailToUser(string Template, string subject, string userTo, string description);
        string SendMailToRolePDF(string Template, string subject, string role, string description);
        void sendEmailWithlAttachment(string subject, string body, string userTo);
    }
}
