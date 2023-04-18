using System.ComponentModel.DataAnnotations;

namespace DZ_LAB1.Models
{
    public class RoutePath
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int routeNumber { get; set; }
        [Required]
        public string routeName { get; set; }
        [Required]
        public float routeLength { get; set; }
        [Required]
        public float routePayPerKM { get; set; }
    }
}
