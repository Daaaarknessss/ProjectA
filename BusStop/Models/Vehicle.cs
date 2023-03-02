using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStop.Models;

public class Vehicle
{
    public string? VehicleId { get; set; }

    public int Capacity { get; set; }

    public int AvailableSeats { get; set; }
    public bool IsOperable { get; set; }
    [ForeignKey("Routee")]
    public int RouteId { get; set; }
    public Routee? Routee { get; set; }



    
}
