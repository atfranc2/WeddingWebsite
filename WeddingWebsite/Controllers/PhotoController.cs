using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }
    }
}
