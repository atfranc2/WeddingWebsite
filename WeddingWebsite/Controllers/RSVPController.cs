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

        public IActionResult GuestConfirmation(string searchString)
        {
            var canidates = _context.Guests.Where(g => g.FullName.ToLower().Contains(searchString.ToLower())).ToList();

            if (canidates.Count() == 0)
            {
                return View("GuestNotFound"); 
            }

            var rsvps = new List<RSVP>(); 
            foreach(var canidate in canidates)
            {
                if (canidate.PartOfCouple)
                {
                    var couple = LookupCouple(canidate.Id);
                    rsvps.Add(new RSVP
                    {
                        GuestOneId = couple.GuestOneId,
                        GuestOne = couple.GuestOne,
                        GuestTwoId = couple.GuestTwoId,
                        GuestTwo = couple.GuestTwo
                    });
                }
                else
                {
                    rsvps.Add(new RSVP
                    {
                        GuestOneId = canidate.Id,
                        GuestOne = canidate
                    });
                }
            };

            var distinctRSVPs = rsvps
                .Distinct(new RSVPComparer())
                .ToList();

            return View(distinctRSVPs);
        }

        public IActionResult Invitation(int guestId)
        {

            var guestOne = _context.Guests.FirstOrDefault(g => g.Id == guestId);

            Couple couple = new Couple();
            Guest guestTwo = new Guest();
            if (guestOne.PartOfCouple)
            {
                couple = LookupCouple(guestId); 
                guestTwo = (couple.GuestOneId == guestId) ? couple.GuestTwo : couple.GuestOne;
            }

            var rsvp = new RSVP
            {
                GuestOneId = guestOne.Id,
                GuestOne = guestOne,
                GuestTwoId = guestTwo.Id,
                GuestTwo = guestTwo
            };

            return View(rsvp);
        }

        public IActionResult Invitation(RSVP rsvp)
        {
            return View(rsvp);
        }

        public IActionResult ContactInformation()
        {
            return View();
        }

        public IActionResult DateTimeInformation()
        {
            return View();
        }

        public IActionResult SongRequests()
        {
            return View();
        }

        public IActionResult MarriageAdvice()
        {
            return View();
        }

        public IActionResult RSVPForm(int guestId)
        {
            var guestOne = _context.Guests.FirstOrDefault(g => g.Id == guestId);

            Couple couple = new Couple();
            Guest guestTwo = new Guest();
            if (guestOne.PartOfCouple)
            {
                couple = LookupCouple(guestId); 
                guestTwo = (couple.GuestOneId == guestId) ? couple.GuestTwo : couple.GuestOne;
            }

            var rsvpViewModel = new RSVPFormViewModel
            {
                GuestOneId = guestOne.Id,
                GuestOneName = guestOne.FullName,
                GuestTwoId = guestTwo.Id,
                GuestTwoName = guestTwo.FullName,
                CoupleTag = couple.CoupleTag
            };
            
            return View(rsvpViewModel); 
        }

        private Couple LookupCouple(int guestId)
        {
            var couple = _context.Couples
                    .Include(c => c.GuestOne)
                    .Include(c => c.GuestTwo)
                    .SingleOrDefault(c => c.GuestOneId == guestId || c.GuestTwoId == guestId);

            return couple; 
        }
    }
}

class RSVPComparer : IEqualityComparer<RSVP>
{
    public bool Equals(RSVP rsvpOne, RSVP rsvpTwo)
    {
        var guestOneEqual = rsvpOne.GuestOne.FullName == rsvpTwo.GuestOne.FullName;
        var guestTwoEqual = rsvpOne.GuestTwo.FullName == rsvpTwo.GuestTwo.FullName;

        return guestOneEqual && guestTwoEqual; 
    }
    public int GetHashCode(RSVP rsvp)
    {
        if (Object.ReferenceEquals(rsvp, null)) return 0;
        int hashGuestOneName = rsvp.GuestOne.FullName == null ? 0 : rsvp.GuestOne.FullName.GetHashCode();
        int hashGuestTwoCode = rsvp.GuestTwo == null ? 0 : rsvp.GuestTwo.FullName.GetHashCode();
        return hashGuestOneName ^ hashGuestTwoCode;
    }
}
