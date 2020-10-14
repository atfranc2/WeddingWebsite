using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Data;
using WeddingWebsite.Dtos;
using AutoMapper;
using WeddingWebsite.Models;

namespace WeddingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouplesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 

        public CouplesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Couples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoupleDto>>> GetCouple()
        {
            
            var couples = await _context.Couples
                .Include(c => c.GuestOne)
                .Include(c => c.GuestTwo)
                .ToListAsync();
            var couplesDto = _mapper.Map<List<Couple>, List<CoupleDto>>(couples); 

            return Ok(couplesDto); 
        }

        // GET: api/Couples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoupleDto>> GetCouple(int id)
        {
            var couple = await _context.Couples
                .Include(c => c.GuestOne)
                .Include(c => c.GuestTwo)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (couple == null)
            {
                return NotFound();
            }

            var coupleDto = _mapper.Map<Couple, CoupleDto>(couple); 

            return Ok(coupleDto);
        }

        // PUT: api/Couples/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCouple(int id, CoupleDto coupleDto)
        {
            if (id != coupleDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(coupleDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoupleExists(id))
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

        // POST: api/Couples
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CoupleDto>> PostCouple(CoupleDto coupleDto)
        {
            var guestOneDto = coupleDto.GuestOne;
            var guestOneFullName = getFullName(guestOneDto.FirstName, guestOneDto.MiddleName, guestOneDto.LastName);
            var guestOne = await _context.Guests.FirstOrDefaultAsync(c => c.FullName == guestOneFullName); 

            var guestTwoDto = coupleDto.GuestTwo;
            var guestTwoFullName = getFullName(guestTwoDto.FirstName, guestTwoDto.MiddleName, guestTwoDto.LastName);
            var guestTwo = await _context.Guests.FirstOrDefaultAsync(c => c.FullName == guestTwoFullName);

            var couple = new Couple
            {
                GuestOneId = guestOne.Id,
                GuestTwoId = guestTwo.Id,
                CoupleTag = guestOneFullName + " & " + guestTwoFullName
            };

            _context.Couples.Add(couple);
            await _context.SaveChangesAsync();

            coupleDto = _mapper.Map<Couple, CoupleDto>(couple); 

            return CreatedAtAction("GetCouple", new { id = couple.Id }, coupleDto);
        }

        // DELETE: api/Couples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoupleDto>> DeleteCouple(int id)
        {
            var couple = await _context.Couples.FindAsync(id);
            if (couple == null)
            {
                return NotFound();
            }

            _context.Couples.Remove(couple);
            await _context.SaveChangesAsync();

            var coupleDto = _mapper.Map<Couple, CoupleDto>(couple); 

            return coupleDto;
        }

        private bool CoupleExists(int id)
        {
            return _context.Couples.Any(e => e.Id == id);
        }

        private string getFullName(string firstName, string middleName, string lastName)
        {
            return (middleName == "") ? firstName + " " + lastName : firstName + " " + middleName + " " + lastName;
        }
    }
}
