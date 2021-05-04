using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Data.DB
{
    public class SpaceParkContext:DbContext
    {

        public DbSet<Parkingspot> Parkingspots { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 6; i++)
            {
                modelBuilder.Entity<Parkingspot>().HasData(
                    new Parkingspot() { ID = i, MinSize = 0, MaxSize = 500 }
                    );
            }
            for (int i = 6; i < 9; i++)
            {
                modelBuilder.Entity<Parkingspot>()
                    .HasData(new Parkingspot() { ID = i, MinSize = 500, MaxSize = 5000 });
            }
            for (int i = 9; i < 10; i++)
            {
                modelBuilder.Entity<Parkingspot>()
                    .HasData(new Parkingspot() { ID = i, MinSize = 5000, MaxSize = 120000 });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //PATRIC
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-KID3QF2\SQLEXPRESS;Database=SpacePark;Trusted_Connection=Yes;");

            //ANAS
            //optionsBuilder.UseSqlServer(@"Server = DESKTOP-7NBHFKN; Database = CodeFirst; Trusted_Connection = True;");

            //JONAS
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-7NBHFKN; Database = SpaceParkAPI; User Id=Anas; Password=123123;");
        }
    }

}

