using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Data;
using WeddingWebsite.Models;
using AutoMapper;
using WeddingWebsite.Dtos;

namespace WeddingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GuestsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        // GET: api/Guests1
        [HttpGet]
        public ActionResult<IEnumerable<GuestDto>> GetGuests(string query = null)
        {
            var guestsQuery = _context.Guests.AsEnumerable();

            if (!String.IsNullOrWhiteSpace(query))
                guestsQuery = guestsQuery.Where(g => g.FullName.Contains(query));


            var guestDtos = guestsQuery.ToList().Select(_mapper.Map<Guest,GuestDto>);

            return Ok(guestDtos);
        }

        // GET: api/Guests1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return _mapper.Map<GuestDto>(guest);
        }

        // PUT: api/Guests1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutGuest(int id, GuestDto guestDto)
        {
            if (id != guestDto.Id)
            {
                return BadRequest();
            }

            var guest = _mapper.Map<GuestDto, Guest>(guestDto);
            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Guests1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GuestDto>> PostGuest(GuestDto guestDto)
        {
            var guest = _mapper.Map<GuestDto, Guest>(guestDto);
            guest.FullName = getFullName(guest.FirstName, guest.MiddleName, guest.LastName); 
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            guestDto.Id = guest.Id;
            guestDto.FullName = guest.FullName; 

            return CreatedAtAction("GetGuest", new { id = guest.Id }, guestDto);
        }

        // DELETE: api/Guests1/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GuestDto>> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            var couple = _context.Couples.Where(c => c.CoupleTag.Contains(guest.FullName)).SingleOrDefault(); 
            if (couple != null)
            {
                _context.Couples.Remove(couple);
                await _context.SaveChangesAsync();
            }

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return _mapper.Map<Guest, GuestDto>(guest);
        }

        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.Id == id);
        }

        private string getFullName(string firstName, string middleName, string lastName)
        {
            return (middleName == "") ? firstName + " " + lastName : firstName + " " + middleName + " " + lastName;
        }
    }
}
