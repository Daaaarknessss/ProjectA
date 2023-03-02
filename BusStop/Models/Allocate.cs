using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStop.Models
{
    public class Allocate
    {
        [Key]
        public int allocateID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        [ForeignKey("Vehicle")]
        public string? VehicleID { get; set; }
        public Vehicle? Vehicle { get; set; }
        [ForeignKey("Routee")]
        public int RouteeID { get; set; }
        public Routee? Routee { get; set;}






    }
}
