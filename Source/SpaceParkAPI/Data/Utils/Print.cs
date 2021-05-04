using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Data.DB;
using System;
using System.Linq;

namespace SpaceParkAPI
{
    public class Print
    {
        public static void TakenSpots()
        {
            
            using var context = new SpaceParkContext();
            // Calculates parkingspots taken and counts total parkingspots
            var parkingsTaken = context.Parkingspots.Where(p => p.SpaceshipName != null).Count();
            var totalParkings = context.Parkingspots.Count();

            Console.WriteLine();
            if (parkingsTaken == totalParkings)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (parkingsTaken > (totalParkings / 2))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Parkingsspots occupied [{parkingsTaken}/{totalParkings}]\n");
            Console.ResetColor();
        }

        public static void PrintReceipt(Receipt receipt, int i = 0)
        {
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.WriteLine($"Receipt ID: {receipt.ID}\n " +
            $"Character: {receipt.Name}\n " +
            $"Starship: {receipt.StarshipName}\n " +
            $"Parkingspot: {receipt.Parkingspot.ID}\n " +
            $"Parking size: {receipt.Parkingspot.MaxSize}meters\n " +
            $"Arrival: {receipt.Arrival}\n " +
            $"Departure: {receipt.Departure}\n " +
            $"Total Price:{receipt.TotalAmount}\n");
            Console.ResetColor();
        }
    }
}
