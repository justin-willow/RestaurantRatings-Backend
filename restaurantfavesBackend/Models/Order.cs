using System.ComponentModel.DataAnnotations;

namespace restaurantfavesBackend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Restaurant { get; set; }
        public int Rating { get; set; }
        public bool OrderAgain { get; set; }

    }
}
