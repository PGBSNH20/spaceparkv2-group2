using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Database
{
    public class SpacePark
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
