using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI
{
    public class SpaceParkRepo : ISpaceParkRepo
    {
        public PersonData GetCharacterByName(string name)
        {
            var character= API.GetPerson(name);
            return character;
        }

        public Receipt GetReceipt(string personData)
        {
            throw new NotImplementedException();
        }

        public StarShip GetShip(int num)
        {
            var charactership =  API.GetSpaceShip(num);
            return charactership;
        }

        public void Park(PersonData personData, StarShip starShip)
        {
            throw new NotImplementedException();
        }

        public void Park(CharacterData personData, StarShip starShip)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UnPark(CharacterData personData, StarShip starShip)
        {
            throw new NotImplementedException();
        }

        public bool ValidateInput(string name, string shipName)
        {
            bool passed = false;
            List<StarShip> ships = new List<StarShip>();
            Logic a = new Logic();

            var character = API.GetPerson(name);

            if (Logic.ValidateName(name)==true)
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
    }
}
