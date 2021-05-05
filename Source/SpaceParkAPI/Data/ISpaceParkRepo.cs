using System.Collections.Generic;

namespace SpaceParkAPI
{
    public interface ISpaceParkRepo
    {
        bool SaveChanges();
        PersonData GetCharacterByName(string name);
        StarShip GetShip(int num);

        bool ValidateInput(string name,string shipName);
        List<Receipt> PersonHistory(CharacterData personData);
         void  Park(CharacterData personData , StarShip starShip);
         Receipt UnPark(CharacterData personData, StarShip starShip);


    }
}