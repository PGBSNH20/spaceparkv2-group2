using System.ComponentModel.DataAnnotations;

namespace SpaceParkModel.Database
{
    public class Spaceship
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
