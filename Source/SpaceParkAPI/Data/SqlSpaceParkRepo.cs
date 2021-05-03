using Microsoft.EntityFrameworkCore;
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
        public PersonData GetCharacterByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Receipt> GetHistory(string personData)
        {
            
            // Gets all the users receipts based on character name.
            var characterReceipts = _context.Receipts.Where(p => p.Name == personData).Include("Parkingspot").ToList();
            //Console.WriteLine($"\n{personData.Name}'s parking history");
            //Console.WriteLine();
            //for (int i = 0; i < characterReceipts.Count; i++)
            //{
            //    Print.PrintReceipt(characterReceipts[i], i);
            //}
            return characterReceipts;
        }

        public StarShip GetShip(int num)
        {
            throw new NotImplementedException();
        }

        public bool ValidateInput(string name, string shipName)
        {
            throw new NotImplementedException();
            
        }
    }
}
