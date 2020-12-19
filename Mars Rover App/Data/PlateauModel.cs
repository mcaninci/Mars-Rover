using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public class PlateauModel
    {
        public int? PlateauMaxX {get;set;}
        public int? PlateauMaxY { get; set; }
    }

    public record PlateauSize {

        public static int PlateauX { get; set; }
        public static int PlateauY { get; set; }
    }
}
