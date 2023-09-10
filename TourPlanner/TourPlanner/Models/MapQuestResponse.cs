using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MapQuestResponse
{
    public Route Route { get; set; }
}

public class Route
{
    public double Distance { get; set; }
    public int Time { get; set; }
    // Andere Felder, die Sie benötigen
}
