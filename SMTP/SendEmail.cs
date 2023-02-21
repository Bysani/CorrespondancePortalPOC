using EfDBContext;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace SMTP
{
    public static class SendEmail
    {

        public static bool SendEmailToProvider(Template template, string userName, string password, string hostName)
        {

            string from = userName;
            using (MailMessage mail = new MailMessage(from, userName))
            {
                mail.Subject = "Test Email";
                mail.IsBodyHtml = true;
                mail.Body = ReplacePlaceHoldersInTemplateContent(template.Body, null);
                mail.Body = mail.Body.Replace("figure", "div");
                mail.Body = ReplaceClasswithInlineStyle(mail.Body);
               // mail.Body = htmlBody;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = hostName;
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(userName, password);   // username and password
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            return true;


        }

        public static string ReplacePlaceHoldersInTemplateContent(string templateBody, List<Dictionary<string, string>> replacements)
        {
            replacements = new List<Dictionary<string, string>>();
            replacements.Add(GetPlaceHolderValues());
            foreach (var replacement in replacements)
            {
                var pattern = $"#(?<placeholder>{string.Join("|", replacement.Keys)})#";
                templateBody = Regex.Replace(templateBody, pattern, m => replacement[m.Groups["placeholder"].Value], RegexOptions.ExplicitCapture);
            }
            return templateBody;
        }

        public static Dictionary<string, string> GetPlaceHolderValues()
        {
            var replacementDetails = new Dictionary<string, string>
                                            {
                                                {"ProviderName", "Test"},
                                                { "ProjectName", "Opteamix" }
                                            };
            return replacementDetails;
        }
        public static string ReplaceClasswithInlineStyle(string htmlString)
        {
            string[] htmlParts = htmlString.Split("image image-style-align-right");
            string firstPart = htmlParts[0].Replace("\"", "");
            firstPart = firstPart.Replace("class", "");
            firstPart = firstPart.Replace("<div =", "<div style=float:right;");
            string finalHtmlBody = firstPart + htmlParts[1];
            return finalHtmlBody;
        }
    }
}
