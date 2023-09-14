using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MapQuestResponse
{
    public Route route { get; set; }
}

public class Route
{
    public double distance { get; set; }
    public string formattedTime { get; set; }
    // Andere Felder, die Sie benötigen
}
