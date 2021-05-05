using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceParkAPI;
//using SpaceParkAPI.API;
using SpaceParkAPI.Dtos;

namespace SpaceParkAPI
{
    [ApiController]
    [Route("/validate/")]
    public class SpaceParkController : ControllerBase
    {
        private readonly ISpaceParkRepo _repository;
        private readonly IMapper _mapper;

        public SpaceParkController(ISpaceParkRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet("{name}/{shipname}/history")]
        public ActionResult<List<SpaceParkReadDto>> ShowHistory(string name,string shipname)
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
                CharacterData characterData = new CharacterData() { Name = p.Name, Starships = p.Starships };
                var x = _repository.PersonHistory(characterData);
                if (x.Count != 0)
                {
                    return Ok(_mapper.Map<List<SpaceParkReadDto>>(x));
                }
            }
                return NotFound();

        }

        
            [HttpPost("{name}/{shipname}/park")]
            public ActionResult<string> Park(string name, string shipname)
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
                    CharacterData characterData = new CharacterData() { Name = p.Name, Starships = p.Starships };
                    _repository.Park(characterData, s);

                    
                    return Ok("Parked!");
                }
                else
                {
                    return BadRequest(commanditem);
                }
            }


        [HttpPut("{name}/{shipname}/unpark")]
        public ActionResult<SpaceParkReadDto> Unpark(string name, string shipname)
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
                CharacterData characterData = new CharacterData() { Name = p.Name, Starships = p.Starships };
                var receipt = _repository.UnPark(characterData, s);


                return Ok(_mapper.Map<SpaceParkReadDto>(receipt));

            }
            else
            {
                return BadRequest();
            }

        }

    }
}
        
    

