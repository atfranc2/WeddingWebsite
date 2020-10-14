using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Data;
using WeddingWebsite.Dtos;

namespace WeddingWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouplesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CouplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Couples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoupleDto>>> GetCouple()
        {
            return await _context.CoupleDto.ToListAsync();
        }

        // GET: api/Couples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoupleDto>> GetCouple(int id)
        {
            var coupleDto = await _context.CoupleDto.FindAsync(id);

            if (coupleDto == null)
            {
                return NotFound();
            }

            return coupleDto;
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
            _context.CoupleDto.Add(coupleDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupleDto", new { id = coupleDto.Id }, coupleDto);
        }

        // DELETE: api/Couples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoupleDto>> DeleteCouple(int id)
        {
            var coupleDto = await _context.CoupleDto.FindAsync(id);
            if (coupleDto == null)
            {
                return NotFound();
            }

            _context.CoupleDto.Remove(coupleDto);
            await _context.SaveChangesAsync();

            return coupleDto;
        }

        private bool CoupleExists(int id)
        {
            return _context.CoupleDto.Any(e => e.Id == id);
        }
    }
}
