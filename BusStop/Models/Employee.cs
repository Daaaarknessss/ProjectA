using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStop.Models;

public class Employee
{ 
    
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int Age { get; set; }

    public string? Location { get; set; }

    public string? ContactNo { get; set; }
    [ForeignKey("Routee")]

    public int RouteId { get; set; }

    public Routee ? Routee { get; set; }
}
