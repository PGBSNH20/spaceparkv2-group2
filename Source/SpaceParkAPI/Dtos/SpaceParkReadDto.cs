﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Dtos
{
    public class SpaceParkReadDto
    {
        public int ID { get; set; }      
        public string Name { get; set; }
        public string StarshipName { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public double TotalAmount { get; set; }
        
       
       



    }
}