using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public record RoverModel
    {
        public string RoverName;
        public int? RoverX;
        public int? RoverY;
        public string? RoverD;
        public string? RoverCommands;
    }
}
