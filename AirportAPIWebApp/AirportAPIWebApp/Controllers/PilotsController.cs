using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirportAPIWebApp.Models;

namespace AirportAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        private readonly AirportAPIContext _context;

        public PilotsController(AirportAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pilots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pilot>>> GetPilots()
        {
          if (_context.Pilots == null)
          {
              return NotFound();
          }
            return await _context.Pilots.ToListAsync();
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pilot>> GetPilot(int id)
        {
          if (_context.Pilots == null)
          {
              return NotFound();
          }
            var pilot = await _context.Pilots.FindAsync(id);

            if (pilot == null)
            {
                return NotFound();
            }

            return pilot;
        }

        // PUT: api/Pilots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPilot(int id, Pilot pilot)
        {
            if (id != pilot.Id)
            {
                return BadRequest();
            }

            _context.Entry(pilot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotExists(id))
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

        // POST: api/Pilots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pilot>> PostPilot(Pilot pilot)
        {
            if (!IsDuplicate(pilot))
            {
                if (_context.Pilots == null)
                {
                    return Problem("Entity set 'AirportAPIContext.Pilots'  is null.");
                }
                _context.Pilots.Add(pilot);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPilot", new { id = pilot.Id }, pilot);
            }
            return Problem("This name already exists");
        }

        // DELETE: api/Pilots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePilot(int id)
        {
            if (_context.Pilots == null)
            {
                return NotFound();
            }
            var pilot = await _context.Pilots.FindAsync(id);
            if (pilot == null)
            {
                return NotFound();
            }

            _context.Pilots.Remove(pilot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PilotExists(int id)
        {
            return (_context.Pilots?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool IsDuplicate(Pilot pilot)
        {
            var cat1 = _context.Pilots.FirstOrDefault(e => e.Name.Equals(pilot.Name));

            return(cat1 == null) ? false : true;
        }
    }
}
