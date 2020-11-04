using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                        GuestOneName = couple.GuestOne.FullName,
                        GuestTwoId = couple.GuestTwoId,
                        GuestTwoName = couple.GuestTwo.FullName,
                        GuestTag = couple.CoupleTag
                    });
                }
                else
                {
                    rsvps.Add(new RSVP
                    {
                        GuestOneId = canidate.Id,
                        GuestOneName = canidate.FullName,
                        GuestTag = canidate.FullName
                    });
                }
            };

            var distinctRSVPs = rsvps
                .Distinct(new RSVPComparer())
                .ToList();

            var guestTags = distinctRSVPs.Select(r => r.GuestTag).ToList();

            var viewModel = new GuestConfirmationViewModel
            {
                RSVPs = distinctRSVPs,
                GuestTags = guestTags
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Invitation(int guestId)
        {

            var guestOne = _context.Guests.FirstOrDefault(g => g.Id == guestId);

            Guest guestTwo = new Guest();
            if (guestOne.PartOfCouple)
            {
                Couple couple = LookupCouple(guestId); 
                guestTwo = (couple.GuestOneId == guestId) ? couple.GuestTwo : couple.GuestOne;
            }

            var rsvp = new RSVP
            {
                GuestOneId = guestOne.Id,
                GuestOneName = guestOne.FullName,
                GuestTwoId = guestTwo.Id,
                GuestTwoName = guestTwo.FullName
            };

            var invitationViewModel = new InvitationViewModel
            {
                RSVP = rsvp,
                DrinkItems = getSpecialtyDrinks().ToList()
            };

            return View(invitationViewModel);
        }

        [HttpPost]
        public IActionResult Invitation(GuestConfirmationViewModel viewModel)
        {
            var rsvp = viewModel.RSVPs.Where(r => r.GuestTag == viewModel.GuestTag).SingleOrDefault();

            var invitationViewModel = new InvitationViewModel
            {
                RSVP = rsvp,
                DrinkItems = getSpecialtyDrinks().ToList()
            };

            return View(invitationViewModel);
        }

        public IActionResult Create(RSVP rsvp)
        {
            return View(rsvp);
        }

        private Couple LookupCouple(int guestId)
        {
            var couple = _context.Couples
                    .Include(c => c.GuestOne)
                    .Include(c => c.GuestTwo)
                    .SingleOrDefault(c => c.GuestOneId == guestId || c.GuestTwoId == guestId);

            return couple; 
        }

        private List<SpecialtyDrinkModel> getSpecialtyDrinks()
        {
            var specialtyDrinks = new List<SpecialtyDrinkModel>
            {
                new SpecialtyDrinkModel { DrinkName = "Super Yum", DrinkDescription = "It's super yummy" },
                new SpecialtyDrinkModel { DrinkName = "Chocholate Bomb", DrinkDescription = "SOOOOOOOOOO much Chocholate" },
                new SpecialtyDrinkModel { DrinkName = "Big Buzz", DrinkDescription = "Many Alcohols" },
                new SpecialtyDrinkModel { DrinkName = "Pucker Up", DrinkDescription = "There's pickle juice yo" },
                new SpecialtyDrinkModel { DrinkName = "Wait... I'm a hobbit?", DrinkDescription = "This one may be laced with drugs" }
            };

            return specialtyDrinks; 
        }
    }

}


class RSVPComparer : IEqualityComparer<RSVP>
{
    public bool Equals(RSVP rsvpOne, RSVP rsvpTwo)
    {
        var guestOneEqual = rsvpOne.GuestOneName == rsvpTwo.GuestOneName;
        var guestTwoEqual = rsvpOne.GuestTwoName == rsvpTwo.GuestTwoName;

        return guestOneEqual && guestTwoEqual; 
    }
    public int GetHashCode(RSVP rsvp)
    {
        if (Object.ReferenceEquals(rsvp, null)) return 0;
        int hashGuestOneName = rsvp.GuestOneName == null ? 0 : rsvp.GuestOneName.GetHashCode();
        int hashGuestTwoCode = rsvp.GuestTwoName == null ? 0 : rsvp.GuestTwoName.GetHashCode();
        return hashGuestOneName ^ hashGuestTwoCode;
    }
}
