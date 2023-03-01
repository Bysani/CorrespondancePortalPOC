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

        [Route("Template/CreateTemplate")]
        public IActionResult CreateTemplate()
        {
            Template template = new Template();
            return View(template);
        }

        [Route("Template/TemplateList")]
        public IActionResult TemplateList()
        {
            string name = string.Empty;
            var templateList = _templateDAL.GetTemplateList(name).ToList();
            templateList = GetTemplateListStatusName(templateList);
            return View("TemplateList", templateList);
        }

        [HttpPost]
        public JsonResult SaveTemplate(Template template)
        {
            if(template.Id == 0)
            {
                string dummyImageURL = _configuration.GetValue<string>("Host:URL") + "Images//DummyBarCode.jpg";
                template.Body = @"<p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><figure class=image image-style-align-right><img id=imgDummyBarCode src=" + dummyImageURL + " onclick=openPreferences()></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>";
            }
            return Json(_templateDAL.SaveTemplate(template));
        }

        [HttpPost]
        public JsonResult DeleteTemplate(Template template)
        {
            return Json(_templateDAL.DeleteTemplate(template));
        }

        [Route("Template/TemplateDetails")]
        public IActionResult TemplateDetails(long templateId)
        {
            var templateDetails = _templateDAL.GetTemplate(templateId);
            return View("TemplateDetails", templateDetails);
        }

        [Route("Template/SaveTemplateFields")]
        public JsonResult SaveTemplateFields(TemplateFields templateFields)
        {
            return Json(_templateDAL.SaveTemplateFields(templateFields));
        }

        [HttpPost]
        [Route("Template/SendTemplate")]
        public bool SendTemplate(Template template, string barCodeSelection)
        {
            var templateDetails = _templateDAL.GetTemplate(template.Id);
            template.templateFields = templateDetails.templateFields;
            string userName = _configuration.GetValue<string>("MailCredentialsSettings:Username");
            string password = _configuration.GetValue<string>("MailCredentialsSettings:Password");
            string hostName = _configuration.GetValue<string>("MailCredentialsSettings:Hostname");
            string base64string = "";

            switch (barCodeSelection)
            {
                case "UPC A barcode":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        base64string = GenerateBarCode("038000356216", BarcodeLib.TYPE.UPCA, fileName);
                        break;
                    }
                case "UPC E barcode":
                    {
                        string fileName = barCodeSelection + template.Name + ".png";
                        base64string = GenerateBarCode("02345673", BarcodeLib.TYPE.UPCE, fileName);
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
                        base64string = GenerateQRCode("www.opteamix.com", fileName);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return SendEmail.SendEmailToProvider(template, userName, password, hostName,base64string);
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

        public string GenerateQRCode(string text, string fileName)
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
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
        }

        public string GenerateBarCode(string text, BarcodeLib.TYPE type, string fileName)
        {
            string folder = _configuration.GetValue<string>("Image:Path");
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image img = b.Encode(type, text, Color.Black, Color.White, 290, 120);
            string path = folder + fileName;
            img.Save(path);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                img.Save(memoryStream, ImageFormat.Png);
                Byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                base64String  = "data:image/png;base64," + base64String;
                return base64String;
            }
        }

        

        public class FileModel
        {
            public string FileName { get; set; }
            public IFormFile FormFile { get; set; }
        }

        private List<Template> GetTemplateListStatusName(List<Template> templates)
        {
            foreach (var template in templates)
            {
                switch (template.StatusId)
                {
                    case 1:
                        {
                            template.StatusName = "Document Submission";
                            break;

                        }
                    case 2:
                        {
                            template.StatusName = "Awaiting Approval";
                            break;
                        }
                    case 3:
                        {
                            template.StatusName = "Closed";
                            break;
                        }
                    default:
                        {
                            template.StatusName = "";
                            break;
                        }
                }
            }
            return templates;
        }
    }
}
