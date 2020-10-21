using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Controllers.Api;
using WeddingWebsite.Data;
using WeddingWebsite.Dtos;
using WeddingWebsite.Models;
using WeddingWebsite.ViewModels;

namespace WeddingWebsite.Controllers
{
    public class RSVPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly CouplesController _couples;
        private readonly GuestsController _guests; 

        public RSVPController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _couples = new CouplesController(_context, _mapper);
            _guests = new GuestsController(_context, _mapper); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IdentityConfirmation(int guestId)
        {
            var couples = new CouplesController(_context, _mapper); 
            
            return View("Index"); 
        }

        public IActionResult RSVPForm(int guestId)
        {
            var guestOne = _context.Guests.FirstOrDefault(g => g.Id == guestId);

            Guest guestTwo = new Guest();
            if (guestOne.PartOfCouple)
            {
                var couple = _context.Couples
                    .Include(c => c.GuestOne)
                    .Include(c => c.GuestTwo)
                    .SingleOrDefault(c => c.GuestOneId == guestId || c.GuestTwoId == guestId);
                guestTwo = (couple.GuestOneId == guestId) ? couple.GuestTwo : couple.GuestOne;
            }

            var rsvpViewModel = new RSVPFormViewModel
            {
                GuestOneId = guestOne.Id,
                GuestOneName = guestOne.FullName,
                GuestTwoId = guestTwo.Id,
                GuestTwoName = guestTwo.FullName

            };
            
            return View(rsvpViewModel); 
        }
    }
}
