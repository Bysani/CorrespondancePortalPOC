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

        public static bool SendEmailToProvider(Template template, string userName, string password, string hostName,string base64String)
        {

            string from = userName;
            using (MailMessage mail = new MailMessage(from, userName))
            {
                mail.Subject = "Test Email";
                mail.IsBodyHtml = true;
                mail.Body = GetImagesInHTMLString(template.Body,base64String);
                mail.Body = ReplacePlaceHoldersInTemplateContent(mail.Body, template.templateFields);
                mail.Body = mail.Body.Replace("figure", "div");
                mail.Body = ReplaceClasswithInlineStyle(mail.Body);
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

        public static string ReplacePlaceHoldersInTemplateContent(string templateBody, ICollection<TemplateFields> templateFields)
        {
            var replacements = new List<Dictionary<string, string>>();
            replacements.Add(GetPlaceHolderValues(templateFields));
            foreach (var replacement in replacements)
            {
                var pattern = $"#(?<placeholder>{string.Join("|", replacement.Keys)})#";
                templateBody = Regex.Replace(templateBody, pattern, m => replacement[m.Groups["placeholder"].Value], RegexOptions.ExplicitCapture);
            }
            return templateBody;
        }

        public static Dictionary<string, string> GetPlaceHolderValues(ICollection<TemplateFields> templateFields)
        {
            var replacementDetails = new Dictionary<string, string>();
            if (templateFields != null && templateFields.Count > 0)
            {
                foreach(var templateField in templateFields)
                {
                    replacementDetails.Add(templateField.Title, templateField.Title);
                }
            }
            return replacementDetails;
        }
        public static string ReplaceClasswithInlineStyle(string htmlString)
        {
            var matches = Regex.Matches(htmlString, @"<div.*?</div>", RegexOptions.Singleline);
            if(matches != null && matches.Count > 0)
            {
                foreach(var mat in matches)
                {
                    string match = mat.ToString();
                    string updatedMatch = match;
                    if (updatedMatch.Contains("image-style-align-right") || updatedMatch.Contains("image-style-block-align-right"))
                    {
                        updatedMatch = updatedMatch.Replace("<div ", "<div style=float:right;");
                    }
                    if(updatedMatch.Contains("image-style-block-align-left") || updatedMatch.Contains("image-style-align-left"))
                    {
                        updatedMatch = updatedMatch.Replace("<div ", "<div style=float:left;");
                    }
                    htmlString = htmlString.Replace(match, updatedMatch);
                    
                }
            }
            
            return htmlString;
        }

        private static string GetImagesInHTMLString(string htmlString, string base64String)
        {
           
            string pattern = @"<(img)\b[^>]*>";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                if (matches[i].Value.Contains("imgDummyBarCode"))
                {
                   htmlString =  htmlString.Replace(matches[i].Value, "<img src="+base64String+" />");
                }
                
            }
            //htmlString =   htmlString.Replace("<img src=http://192.168.1.6:90/Images//DummyBarCode.jpg id=imgDummyBarCode onclick=openPreferences()>", base64String);

            return htmlString;
        }
    }
}
