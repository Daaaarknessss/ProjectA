using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStop.Models;

public  class Routee
{
    [Key]
    public int RouteId { get; set; }

    public string? Stop1 { get; set; }
    public string? Stop2 { get; set; }
    public string? Stop3 { get; set; }

    public Vehicle? Vehicle { get; set; }
}
