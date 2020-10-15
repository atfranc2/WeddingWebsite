using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeddingWebsite.Controllers.Api;
using WeddingWebsite.Data;

namespace WeddingWebsite.Controllers
{
    public class RSVPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RSVPController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IdentityConfirmation(int guestId)
        {
            var couples = new CouplesController(_context, _mapper); 
            
            return View(); 
        }

        public IActionResult RSVPForm()
        {
            return View(); 
        }
    }
}
