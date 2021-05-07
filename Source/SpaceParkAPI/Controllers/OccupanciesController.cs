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

        [HttpPost]
        public async Task<ActionResult<OccupancyDTO>> AddOccupancy(Occupancy occupancy)
        {
            _context.Add(occupancy);
            await _context.SaveChangesAsync();

            return OccupancyToDTO(occupancy);
        }

        [HttpPost, Route("register/{spaceParkId}/{person}/{spaceship}")]
        public async Task<ActionResult<OccupancyDTO>> Register(int spaceParkId, string person, string spaceship)
        {
            SwApi swApi = new();
            if (!await swApi.ValidateSwName(person))
            {
                return BadRequest("The force doesn't recognize you!");
            }
            var starships = await swApi.SearchResource<SwStarship>(SwApiResource.starships, spaceship);
            if (starships.Count == 0)
            {
                return BadRequest("No starship with that name was found!");
            }
            int parkingSpotId = await DBQuery.GetAvailableParkingSpotID(spaceParkId, starships[0]);
            if (parkingSpotId == 0)
            {
                return NotFound("Parking-lot is full, no available parking at the moment!");
            }
            var occupancy = await DBQuery.FillOccupancy(person, spaceship, parkingSpotId, spaceParkId);

            return OccupancyToDTO(occupancy);
        }

        // used to be search
        [HttpGet, Route("person/{name}")]
        public async Task<ActionResult<OccupancyDTO>> Search(string name)
        {
            var person = await _context.Persons.FirstAsync(p => p.Name == name);
            var occupancy = await _context.Occupancies.FirstAsync(o => o.PersonID == person.ID && o.DepartureTime == null);

            if (occupancy == null)
            {
                return NotFound("This person isn't parked here");
            }

            return OccupancyToDTO(occupancy);
        }

        [HttpPost, Route("unpark/{spaceParkId}/{person}")]
        public async Task<ActionResult<InvoiceDTO>> Unpark(int spaceParkId, string person)
        {
            var occupancy = await DBQuery.GetOpenOccupancyByName(spaceParkId, person);

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
            ParkingSpotID = occupancy.ParkingSpotID,
            SpaceParkName = DBQuery.GetSpaceParkName(occupancy.SpaceParkID).Result
        };

        private static HistoryDTO OccupancyToHistoryDTO(OccupancyHistory occupancyHistory) =>
        new HistoryDTO
        {
            PersonName = occupancyHistory.PersonName,
            SpaceshipName = occupancyHistory.SpaceParkName,
            ArrivalTime = occupancyHistory.ArrivalTime,
            DepartureTime = occupancyHistory.DepartureTime,
            AmountPaid = occupancyHistory.AmountPaid
        };
    }
}
