using DAL;
using EfDBContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text.RegularExpressions;
using SMTP;
using QRCoder;

namespace TemplatePortal.Controllers
{
    public class TemplateController : Controller
    {

        ITemplateDAL _templateDAL;

        IConfiguration _configuration;
        public TemplateController(ITemplateDAL templateDAL, IConfiguration config)
        {
            _templateDAL = templateDAL;
            _configuration = config;
        }


        [Route("Template/TemplateList")]
        public IActionResult TemplateList()
        {
            string name = string.Empty;
            var templateList = _templateDAL.GetTemplateList(name).ToList();
            return View("TemplateList",templateList);
        }

        [HttpPost]
        public JsonResult SaveTemplate(Template template)
        {
            return Json(_templateDAL.SaveTemplate(template));
        }


        [Route("Template/TemplateDetails")]
        public IActionResult TemplateDetails(long templateId)
        {
            var templateDetails = _templateDAL.GetTemplateList(string.Empty).FirstOrDefault(x => x.Id == templateId);
            if(string.IsNullOrWhiteSpace(templateDetails.Body))
            {
                templateDetails.Body = @"<p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><figure class=image><img id=imgDummyBarCode src=http://192.168.1.6:90/Images//DummyBarCode.jpg onclick=openPreferences()></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>";
            }
            return View("TemplateDetails", templateDetails);
        }

        [HttpPost]
        [Route("Template/SendTemplate")]
        public bool SendTemplate(Template template, string barCodeSelection)
        {
            string userName = _configuration.GetValue<string>("MailCredentialsSettings:Username");
            string password = _configuration.GetValue<string>("MailCredentialsSettings:Password");
            string hostName = _configuration.GetValue<string>("MailCredentialsSettings:Hostname");

            switch (barCodeSelection)
            {
                case "UPC A barcode":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        GenerateBarCode("038000356216", BarcodeLib.TYPE.UPCA, fileName);
                        break;
                    }
                case "UPC E barcode":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        GenerateBarCode("02345673", BarcodeLib.TYPE.UPCE, fileName);
                        break;
                    }
                case "OMR barcode":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        //GenerateBarCode("Test", BarcodeLib.TYPE.UNSPECIFIED, fileName);
                        break;
                    }
                case "QR Code":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        GenerateQRCode("www.opteamix.com", fileName);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return SendEmail.SendEmailToProvider(template, userName, password, hostName);
        }

        //[HttpPost("[action]")]
        //[Route("api/Template/UploadFile")]
        //public IActionResult UploadFile([FromForm] FileModel file)
        //{

        //    string folder = _configuration.GetValue<string>("Image:Path");


        //    string iName = file.FormFile.FileName;
        //    //string folder = System.IO.Directory.GetCurrentDirectory() + "\\Images\\";
        //    //var path = Path.Combine(folder, Path.GetFileName(iName));


        //    //path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
        //    if (!Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);
        //    }
        //    using (var fileStream = new FileStream(Path.Combine(folder, file.FormFile.FileName), FileMode.Create))
        //    {
        //        file.FormFile.CopyTo(fileStream);
        //    }
        //    return Ok();
        //}

        public void GenerateQRCode(string text, string fileName)
        {
            string folder = _configuration.GetValue<string>("Image:Path");
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            MemoryStream ms = new MemoryStream();
            QrBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] BitmapArray = ms.ToArray();
            //byte[] BitmapArray = QrBitmap.ToByteArray();
            string path = folder + fileName;
            System.IO.File.WriteAllBytes(path, BitmapArray);
            //string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            //ViewBag.QrCodeUri = QrUri;
        }

        public void GenerateBarCode(string text, BarcodeLib.TYPE type, string fileName)
        {
            string folder = _configuration.GetValue<string>("Image:Path");
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image img = b.Encode(type, text, Color.Black, Color.White, 290, 120);
            string path = folder + fileName;
            img.Save(path);


        }

        private List<string> GetImagesInHTMLString(string htmlString)
        {
            List<string> images = new List<string>();
            string pattern = @"<(img)\b[^>]*>";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                images.Add(matches[i].Value);
            }

            return images;
        }

        public class FileModel
        {
            public string FileName { get; set; }
            public IFormFile FormFile { get; set; }
        }
    }
}
