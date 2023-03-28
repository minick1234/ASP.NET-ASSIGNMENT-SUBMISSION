using DZ_LAB1.Models;
using System.ComponentModel.DataAnnotations;

namespace DZ_LAB1.Models
{
    public class TruckWorkshop
    {
        [Key] public int WorkOrderID { get; set; }

        [Required]
        public string? WorkDescription { get; set; }

        [Required] public float WorkOrderCost { get; set; }

        [Required] public int TruckId { get; set; }

    }
}
