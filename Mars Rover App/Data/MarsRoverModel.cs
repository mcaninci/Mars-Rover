using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public class MarsRoverModel
    {
             
        public PlateauModel PlateauModel {get;set;}
        public List<RoverModel> RoverModels { get; set; }
    }
}
