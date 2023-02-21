using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TemplatePortal.Models;

namespace TemplatePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public ActionResult GetHtmlPage()
        {
            var encoding = new System.Text.UTF8Encoding();
            var htmlFilePath = System.IO.Directory.GetCurrentDirectory() + "\\Home\\Editor.html";
            var htm = System.IO.File.ReadAllText( htmlFilePath, encoding);
            byte[] data = encoding.GetBytes(htm);
            return new FileContentResult(data,"text/html");
            //Response.OutputStream.Write(data, 0, data.Length);
           // Response.OutputStream.Flush();
            //return new FilePathResult(path, "text/html");
        }

        //[ChildActionOnly]
        //public ActionResult GetHtmlPage(string path)
        //{
        //    return new FilePathResult(path, "text/html");
        //}
    }
}
