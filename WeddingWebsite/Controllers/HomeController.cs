using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingWebsite.Models;

namespace WeddingWebsite.Controllers
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
            var photoFileList = Directory.GetFiles("wwwroot/Images/HomePagePictures/");
            var fileList = new List<string>();

            foreach (var file in photoFileList)
            {
                var fileParts = file.Split("/");
                var filePath = "/" + fileParts[1] + "/" + fileParts[2] + "/" + fileParts[3];

                fileList.Add(filePath);
            }

            return View(fileList);
        }

        public IActionResult OurStory()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
