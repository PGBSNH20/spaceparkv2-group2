using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class InvoiceDTO
    {
        public string Name { get; set; }
        public decimal Hours { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
