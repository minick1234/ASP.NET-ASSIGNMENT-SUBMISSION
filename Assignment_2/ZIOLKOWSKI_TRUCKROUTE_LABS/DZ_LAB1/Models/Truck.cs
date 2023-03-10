using System.ComponentModel.DataAnnotations;

namespace DZ_LAB1.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int truckNum { get; set; }
        [Required]
        public string truckModel { get; set; }
        [Required]
        public string truckMake { get; set; }
        public int truckRouteNumber { get; set; } // this will be assigned by the route.

    }
}
