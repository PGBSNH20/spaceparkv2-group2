using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceParkAPI;
using SpaceParkAPI.Dtos;

namespace SpaceParkAPI
{
    [ApiController]
    [Route("/validate/")]
    public class SpaceParkController : ControllerBase
    {
        private readonly ISpaceParkRepo _repository;
        private readonly IMapper _mapper;

        public SpaceParkController(ISpaceParkRepo repo,IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }



        // private readonly SpaceParkRepo _repository = new SpaceParkRepo();

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("{name}/{shipname}")]
        public ActionResult<PersonData> ValidateInput(string name, string shipname)
        {
            var commanditem = _repository.ValidateInput(name, shipname);
            List<StarShip> ships = new List<StarShip>();
            StarShip s = new StarShip();
            Logic a = new Logic();
            PersonData p = new PersonData();
            if (commanditem == true)
            {
                var commanditem1 = _repository.GetCharacterByName(name);
                a.GetShipListByName(name);
                ships = a.starshipsAvailable;
                for (int i = 0; i < ships.Count; i++)
                {
                    if (shipname.ToLower() == ships[i].Name.ToLower())
                    {

                        s = ships[i];
                    }

                }
                p = commanditem1;
                p.Starships[0] = s.Name;
                return Ok(p);
            }
            else
            {
                return BadRequest(commanditem);
            }
        }



        [HttpGet("{name}")]
        public ActionResult<SpaceParkReadDto> ShowHistory(string name)
        {
            var commanditem = _repository.GetHistory(name);
            if (commanditem!=null)
            {
                return Ok(_mapper.Map<SpaceParkReadDto>(commanditem));
            }
            return NotFound();
            
        }
        //[HttpGet("{shipid}")]
        //public ActionResult<StarShip> GetStarShip(int name)
        //{
        //    var commanditem = _repository.GetShip(name);
        //    return Ok(commanditem);
        //}

        //[HttpGet("/people/name/ship")]
        //public ActionResult<StarShip> GetStarShip(int name)
        //{
        //    var commanditem = _repository.GetShip(name);
        //    return Ok(commanditem);
        //}


    }
    //[ApiController]
    //[Route("/validate1/")]
    //public class SpaceParkController1 : ControllerBase
    //{
    //    public SpaceParkController1(ISpaceParkRepo repo)
    //    {
    //        _repository = repo;
    //    }
    //    private readonly ISpaceParkRepo _repository;

    //    [HttpGet("{name}")]
    //    public ActionResult<List<Receipt>> ShowHistory(string name)
    //    {
    //        var commanditem = _repository.GetHistory(name);
    //        return Ok(commanditem);
    //    }
    //}
}
