using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Data;
using WeddingWebsite.Dtos;
using WeddingWebsite.Models;

namespace WeddingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RSVPsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        // GET: api/RSVPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RSVP>>> GetRSVPs()
        {
            return await _context.RSVPs.ToListAsync();
        }

        // GET: api/RSVPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RSVP>> GetRSVP(int id)
        {
            var rSVP = await _context.RSVPs.FindAsync(id);

            if (rSVP == null)
            {
                return NotFound();
            }

            return rSVP;
        }

        // PUT: api/RSVPs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRSVP(int id, RSVP rSVP)
        {
            if (id != rSVP.Id)
            {
                return BadRequest();
            }

            _context.Entry(rSVP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RSVPExists(id))
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

        // POST: api/RSVPs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RSVP>> PostRSVP(RSVPDto RSVPDto)
        {
            var dateTime = (RSVPDto.DayOfArrival != "" && RSVPDto.TimeOfArrival != "") ? GetDateTime(RSVPDto.DayOfArrival, RSVPDto.TimeOfArrival) : DateTime.Now; 
            RSVP RSVP = _mapper.Map<RSVPDto, RSVP>(RSVPDto);
            RSVP.TimeOfArrival = dateTime;
            RSVP.DayOfArrival = dateTime; 

            if (!ModelState.IsValid)
                return BadRequest("Invalid data was submitted"); 

            _context.RSVPs.Add(RSVP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostRSVP", new { id = RSVPDto.Id }, RSVPDto);
        }

        // DELETE: api/RSVPs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RSVP>> DeleteRSVP(int id)
        {
            var rSVP = await _context.RSVPs.FindAsync(id);
            if (rSVP == null)
            {
                return NotFound();
            }

            _context.RSVPs.Remove(rSVP);
            await _context.SaveChangesAsync();

            return rSVP;
        }

        private bool RSVPExists(int id)
        {
            return _context.RSVPs.Any(e => e.Id == id);
        }

        private DateTime GetDateTime(string dateString, string timeString)
        {
            var timeParts = timeString
                .Split(":")
                .Select(m => int.Parse(m))
                .ToList();

            var dateParts = dateString
                .Split("-")
                .Select(m => int.Parse(m))
                .ToList();

            var dateTime = new DateTime(dateParts[0], dateParts[1], dateParts[2], timeParts[0], timeParts[1], 0);

            return dateTime; 
        }
    }
}
