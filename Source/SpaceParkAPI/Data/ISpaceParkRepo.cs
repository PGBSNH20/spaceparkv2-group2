using System.Collections.Generic;

namespace SpaceParkAPI
{
    public interface ISpaceParkRepo
    {
       // IEnumerable<Character> GetCharacter();
        PersonData GetCharacterByName(string name);
        StarShip GetShip(int num);

        bool ValidateInput(string name,string shipName);
        List<Receipt> GetHistory(string personData);


    }
}