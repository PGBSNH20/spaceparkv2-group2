using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using SpaceParkModel.Database;
using SpaceParkModel.SwApi;

namespace SpaceParkAPI.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class OccupanciesController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public OccupanciesController(SpaceParkContext context)
        {
            _context = context;
        }

        // GET: api/Occupancies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccupancyDTO>>> GetOccupancies()
        {
            return await _context.Occupancies
                .Where(o => !o.DepartureTime.HasValue)
                .Select(o => OccupancyToDTO(o))
                .ToListAsync();
        }

        // GET: api/Occupancies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccupancyDTO>> GetOccupancy(int id)
        {
            var occupancy = await _context.Occupancies.FindAsync(id);

            if (occupancy == null)
            {
                return NotFound();
            }

            return OccupancyToDTO(occupancy);
        }

        [HttpGet, Route("search/{name}")]
        public async Task<ActionResult<OccupancyDTO>> Search(string name)
        {
            var person = await _context.Persons.FirstAsync(p => p.Name == name);
            var occupancy = await _context.Occupancies.FirstAsync(o => o.PersonID == person.ID && o.DepartureTime == null);

            if (occupancy == null)
            {
                return NotFound();
            }

            return OccupancyToDTO(occupancy);
        }

        [HttpGet, Route("register/{person}/{spaceship}")]
        public async Task<ActionResult<OccupancyDTO>> Register(string person, string spaceship)
        {
            SwApi swApi = new();
            if(!await swApi.ValidateSwName(person))
            {
                return NotFound();
            }
            var starships = await swApi.SearchResource<SwStarship>(SwApiResource.starships, spaceship);
            if (starships.Count == 0)
            {
                // TODO: Give the right errors.
                return NotFound();
            }
            int parkingSpotId = await DBQuery.GetAvailableParkingSpotID(starships[0]);
            if (parkingSpotId == 0)
            {
                return NotFound();
            }
            var occupancy = await DBQuery.FillOccupancy(person, spaceship, parkingSpotId);

            return OccupancyToDTO(occupancy);
        }

        [HttpGet, Route("unpark/{person}")]
        public async Task<ActionResult<InvoiceDTO>> Unpark(string person)
        {
            var occupancy = await DBQuery.GetOpenOccupancyByName(person);

            await DBQuery.AddPaymentAndDeparture(occupancy);

            return new InvoiceDTO
            {
                Name = person,
                Hours = DBQuery.CalculateBillingHours(occupancy),
                AmountPaid = await DBQuery.GetPaymentForOccupancy(occupancy)
            };
        }

        [HttpGet, Route("history")]
        public async Task<ActionResult<IEnumerable<HistoryDTO>>> History()
        {
            var history = await DBQuery.GetHistory();

            return history
                .Select(h => OccupancyToHistoryDTO(h))
                .ToList();
        }

        [HttpGet, Route("history/{person}")]
        public async Task<ActionResult<IEnumerable<OccupancyHistory>>> History(string person)
        {
            return await DBQuery.GetPersonalHistory(person);
        }

        private bool OccupancyExists(int id)
        {
            return _context.Occupancies.Any(e => e.ID == id);
        }

        private static OccupancyDTO OccupancyToDTO(Occupancy occupancy) =>
        new OccupancyDTO
        {
            ID = occupancy.ID,
            PersonName = DBQuery.GetPersonName(occupancy.PersonID).Result,
            SpaceshipName = DBQuery.GetSpaceshipName(occupancy.SpaceshipID).Result,
            ArrivalTime = occupancy.ArrivalTime,
            DepartureTime = occupancy.DepartureTime,
            ParkingSpotID = occupancy.ParkingSpotID
        };

        private static HistoryDTO OccupancyToHistoryDTO(OccupancyHistory occupancyHistory) =>
        new HistoryDTO
        {
            PersonName = occupancyHistory.PersonName,
            SpaceshipName = occupancyHistory.SpaceParkName,
            ArrivalTime = occupancyHistory.ArrivalTime,
            DepartureTime = occupancyHistory.DepartureTime,
            AmountPaid = occupancyHistory.AmountPaid,
            // TODO: Add SpaceParkName (for multi-tenant)
            SpaceParkName = ""
        };

        // PUT: api/Occupancies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOccupancy(int id, Occupancy occupancy)
        //{
        //    if (id != occupancy.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(occupancy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OccupancyExists(id))
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

        // POST: api/Occupancies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Occupancy>> PostOccupancy(Occupancy occupancy)
        //{
        //    _context.Occupancies.Add(occupancy);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOccupancy", new { id = occupancy.ID }, occupancy);
        //}

        //// DELETE: api/Occupancies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOccupancy(int id)
        //{
        //    var occupancy = await _context.Occupancies.FindAsync(id);
        //    if (occupancy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Occupancies.Remove(occupancy);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
