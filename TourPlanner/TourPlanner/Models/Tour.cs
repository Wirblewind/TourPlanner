using System;
using System.Collections.Generic;

namespace TourPlanner.Models;

public partial class Tour
{
    public string? Tourdescription { get; set; }

    public string Tourfrom { get; set; } = null!;

    public string Tourto { get; set; } = null!;

    public string Tourtransporttype { get; set; } = null!;

    public string? Tourdistance { get; set; }

    public string? Tourtimeestimate { get; set; }

    public string? Tourrouteinformation { get; set; }

    public int Tourid { get; set; }

    public string Tourname { get; set; } = null!;
}
