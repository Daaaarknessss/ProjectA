using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusStop.Models;

namespace BusStop.Data
{
    public class BusStopContext : DbContext
    {
        public BusStopContext (DbContextOptions<BusStopContext> options)
            : base(options)
        {
        }

        public DbSet<BusStop.Models.Employee> Employee { get; set; } = default!;

        public DbSet<BusStop.Models.Vehicle> Vehicle { get; set; } = default!;

        public DbSet<BusStop.Models.Routee> Routee { get; set; } = default!;
        public DbSet<BusStop.Models.Allocate>Allocate { get; set; } = default!;
    }
}
