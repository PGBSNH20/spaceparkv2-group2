
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Data.DB;
using SpaceParkAPI;



namespace SpaceParkAPI
{
    public class Parkingspot
    {
        [Key]
        public int ID { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string CharacterName { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime Arrival { get; set; }

        public static void Park(CharacterData personData, StarShip starShip)
        {

            using var context = new SpaceParkContext();
            // Calculates parkingspots taken and counts total parkingspots
            var totalParkings = context.Parkingspots.Count();
            var parkingsTaken = context.Parkingspots.Where(p => p.SpaceshipName != null).Count();

            // Check if any parkingspot can contain selected starships size and is available.
            //var parking = context.Parkingspots
            //    .Where(p => p.MinSize <= double.Parse(starShip.Length)
            //    && p.MaxSize >= double.Parse(starShip.Length)
            //    && p.SpaceshipName == null).FirstOrDefault();

            // Check if any parkingspot can contain selected starships size and is available.
            var parking = context.Parkingspots
                .Where(p => p.SpaceshipName == null).FirstOrDefault();

            // If a parkingspot was found, change the parkingspots values and save to database.
            if (parking != null)
            {
                parking.SpaceshipName = starShip.Name;
                parking.CharacterName = personData.Name;
                parking.Arrival = DateTime.Now;
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYour {starShip.Name} has been parked at parkingspot number: {parking.ID}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // If there are available parkingspots but none matching starshipsize, print message
            else if (parkingsTaken < totalParkings)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo parkings available for that size");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo parkings available\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static Receipt Unpark(StarShip starship, CharacterData character)
        {
           
            using var context = new SpaceParkContext();
            // Retrieves the parkingspot where the user has parked, if none was found parked is null.
            Parkingspot parked = context.Parkingspots.Where(p => p.CharacterName == character.Name && p.SpaceshipName == starship.Name).FirstOrDefault();

            // If a parkingspot where the user is parked was found.
            if (parked != null)
            {
                DateTime Departure = DateTime.Now;
                // Calculates how many minutes the user was parked
                double diff = (Departure - parked.Arrival).TotalMinutes;
                double price = 0;
                // Then calculate the minute price of parkingize times the amount of minutes + the starting fee.
                if (parked.MinSize == 0)
                {
                    price = (Math.Round(diff, 0) * 200) + 100;
                }
                else if(parked.MinSize == 500)
                {
                    price = (Math.Round(diff, 0) * 800) + 400;
                }
                else
                {
                    price = (Math.Round(diff, 0) * 12000) + 6000;
                }

                //Console.Clear();
                // Create a new receipt
                Receipt receipt = new ()
                {
                    StarshipName = starship.Name,
                    Name = character.Name,
                    Arrival = parked.Arrival,
                    Departure = Departure,
                    Parkingspot = parked,
                    TotalAmount = price
                };
                // Add receipt to database and change parkingspot values then save changes to database.
                context.Receipts.Add(receipt);
                parked.CharacterName = null;
                parked.SpaceshipName = null;
                parked.Arrival = default;
                context.SaveChanges();
                return receipt;

                //Console.WriteLine($"You have successfully unparked your vehicle {starship.Name}\n");
                //Print.PrintReceipt(receipt);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{starship.Name} is not parked in our SpacePark!\n");
                Console.ResetColor();

                return null;
            }
           
        }

        public static void ShowHistory(PersonData character)
        {
           
            using var context = new SpaceParkContext();
            // Gets all the users receipts based on character name.
            var characterReceipts = context.Receipts.Where(p => p.Name == character.Name).Include("Parkingspot").ToList();
            Console.WriteLine($"\n{character.Name}'s parking history");
            Console.WriteLine();
            //for (int i = 0; i < characterReceipts.Count; i++)
            //{
            //    Print.PrintReceipt(characterReceipts[i], i);
            //}
        }
    }
}
