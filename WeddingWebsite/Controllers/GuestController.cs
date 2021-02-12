using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingWebsite.Data;
using WeddingWebsite.Models;
using WeddingWebsite.ViewModels;

namespace WeddingWebsite.Controllers
{
    [Authorize(Roles = RoleNames.Administrator + ", " + RoleNames.GuestUser)]
    public class GuestController : Controller
    {
        private readonly ApplicationDbContext _context;


        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleNames.Administrator)]
        public IActionResult New()
        {
            return View("AddGuestForm"); 
        }

        public IActionResult EditGuest(int id)
        {
            var guestOne = GetGuest(id);
            var viewModel = new GuestViewModel()
            {
                GuestOne = guestOne,
                GuestTwo = (guestOne.PartOfCouple) ? GetPartner(id) : null
            };

            return View("EditGuestForm", viewModel); 
            
        }

        private Guest GetGuest(int id)
        {
            return _context.Guests.FirstOrDefault(g => g.Id == id);
        }

        private Guest GetPartner(int id)
        {
            var couple = _context.Couples.FirstOrDefault(c => c.GuestOneId == id || c.GuestTwoId == id);
            var partnerId = (couple.GuestOneId == id) ? couple.GuestTwoId : couple.GuestOneId;

            return GetGuest(partnerId); 
        }
    }
}
