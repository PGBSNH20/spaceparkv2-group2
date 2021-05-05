using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using SpaceParkModel.Database;

namespace SpaceParkAPI.Controllers
{
    [Route("api/spacepark")]
    [ApiController]
    public class SpaceParksController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public SpaceParksController(SpaceParkContext context)
        {
            _context = context;
        }

        // GET: api/SpaceParks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceParkDTO>>> GetSpaceParks()
        {
            return await _context.SpaceParks
                .Select(sp => SpaceParkToDTO(sp))
                .ToListAsync();
        }

        // GET: api/SpaceParks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceParkDTO>> GetSpacePark(int id)
        {
            var spacePark = await _context.SpaceParks.FindAsync(id);

            if (spacePark == null)
            {
                return NotFound();
            }

            return SpaceParkToDTO(spacePark);
        }

        [HttpGet, Route("register/{name}")]
        public async Task<ActionResult<SpaceParkDTO>> Register(string name)
        {
            var spacePark = await DBQuery.AddSpacePark(name);

            return SpaceParkToDTO(spacePark);
        }

        // PUT: api/SpaceParks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSpacePark(int id, SpacePark spacePark)
        //{
        //    if (id != spacePark.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(spacePark).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SpaceParkExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/SpaceParks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpacePark>> PostSpacePark(SpacePark spacePark)
        {
            _context.SpaceParks.Add(spacePark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpacePark", new { id = spacePark.ID }, spacePark);
        }

        // DELETE: api/SpaceParks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpacePark(int id)
        {
            var spacePark = await _context.SpaceParks.FindAsync(id);
            if (spacePark == null)
            {
                return NotFound();
            }

            _context.SpaceParks.Remove(spacePark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpaceParkExists(int id)
        {
            return _context.SpaceParks.Any(e => e.ID == id);
        }

        private static SpaceParkDTO SpaceParkToDTO(SpacePark park) =>
        new SpaceParkDTO
        {
            ID = park.ID,
            Name = park.Name
        };
    }
}
