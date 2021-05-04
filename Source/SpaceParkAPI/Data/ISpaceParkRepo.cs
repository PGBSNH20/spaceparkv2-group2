using System.Collections.Generic;

namespace SpaceParkAPI
{
    public interface ISpaceParkRepo
    {
        bool SaveChanges();
        PersonData GetCharacterByName(string name);
        StarShip GetShip(int num);

        bool ValidateInput(string name,string shipName);
        Receipt GetReceipt(string personData);
         void  Park(CharacterData personData , StarShip starShip);
         void UnPark(CharacterData personData, StarShip starShip);


    }
}