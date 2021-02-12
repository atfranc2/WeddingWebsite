using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingWebsite.Models;

namespace WeddingWebsite.Controllers
{
    [Authorize(Roles = RoleNames.Administrator + ", " + RoleNames.GuestUser)]
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            var photoFileList = Directory.GetFiles("wwwroot/Images/PhotosPagePictures/");
            var fileList = new List<string>(); 

            foreach (var file in photoFileList)
            {
                var fileParts = file.Split("/");
                var filePath = "/" + fileParts[1] + "/" + fileParts[2] + "/" + fileParts[3];

                fileList.Add(filePath); 
            }

            return View(fileList);
        }
    }
}
