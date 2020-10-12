using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Data;
using WeddingWebsite.Dtos;
using WeddingWebsite.Models;
using AutoMapper;


namespace WeddingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Guests
        [HttpGet]
        public ActionResult<IEnumerable<GuestDto>> GetGuests()
        {
            var guestList = _context.Guests.ToList().Select(guest => Mapper.Map<Guest, GuestDto>);

            return Ok(guestList);
        }

        public ActionResult<GuestDto> GetGuest(int id)
        {
            var guest = _context.Guests.SingleOrDefault(g => g.Id == id);

            if (guest == null)
                return NotFound();

            return Ok(guest);
        }
    }
}
