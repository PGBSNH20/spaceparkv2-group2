﻿using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Data
{
    public class SqlSpaceParkRepo : ISpaceParkRepo
    {
        private readonly SpaceParkContext _context;

        public SqlSpaceParkRepo(SpaceParkContext context)
        {
            _context = context;
        }
        

        public List<Receipt> PersonHistory(CharacterData personData)
        {

            // Gets all the users receipts based on character name.
            var characterReceipts = _context.Receipts.Where(p => p.Name == personData.Name).ToList(); ;
            Console.WriteLine($"\n{personData.Name}'s parking history");
            Console.WriteLine();
            //for (int i = 0; i < characterReceipts.Count; i++)
            //{
            //    Print.PrintReceipt(characterReceipts[i], i);
            //}
            return characterReceipts;
        }

        public PersonData GetCharacterByName(string name)
        {
            var character = API.GetPerson(name);
            return character;
        }

        

        public StarShip GetShip(int num)
        {
            var charactership = API.GetSpaceShip(num);
            return charactership;
        }

        public bool ValidateInput(string name, string shipName)
        {
            bool passed = false;
            List<StarShip> ships = new List<StarShip>();
            Logic a = new Logic();

            var character = API.GetPerson(name);

            if (Logic.ValidateName(name) == true)
            {
                a.GetShipListByName(character.Name);
                ships = a.starshipsAvailable;

                for (int i = 0; i < ships.Count; i++)
                {
                    if (shipName.ToLower() == ships[i].Name.ToLower())
                    {
                        passed = true;
                    }

                }
            }
            return passed;

        }

        public bool SaveChanges()
        {
           return( _context.SaveChanges()>=0);
        }

        public void Park(CharacterData personData, StarShip starShip)
        {
            if (personData == null|| starShip==null)
            {
                throw new ArgumentNullException(nameof(personData));
            }
            Parkingspot.Park(personData, starShip);    
            
        }

        

        public Receipt UnPark(CharacterData personData, StarShip starShip)
        {
            if (personData == null || starShip == null)
            {
                throw new ArgumentNullException(nameof(personData));
            }
            var x= Parkingspot.Unpark(starShip, personData);
            return x;
        }

        
    }
}