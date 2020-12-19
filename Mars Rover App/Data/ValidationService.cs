using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public class ValidationService
    {
        /// <summary>
        ///    This method check null wxception for input data 
        /// </summary>
        /// <param name="marsRoverModel"></param>
        /// <returns></returns>
        public static bool CheckInputData(MarsRoverModel marsRoverModel)
        {

            if (marsRoverModel!=null)
            {
                if (marsRoverModel.PlateauModel.PlateauMaxX!=null || marsRoverModel.PlateauModel.PlateauMaxY != null)
                {
                    if (marsRoverModel.RoverModels.Count>0)
                    {
                        foreach (var rover in marsRoverModel.RoverModels)
                        {
                            if (string.IsNullOrEmpty(rover.RoverCommands) || rover.RoverX==null || rover.RoverY==null || string.IsNullOrEmpty(rover.RoverD)  )
                            {
                                throw new ArgumentException("Rover data is invalid.");
                            }
                        }
                        return true;
                    }

                }

                throw new ArgumentException("Plateau data is invalid.");

            }
            throw new ArgumentNullException(nameof(marsRoverModel));
           
        }
    
        /// <summary>
        /// This Method check Next origin is valid and avaible for rover
        /// </summary>
        /// <param name="roverModel"></param>
       public static void CheckRoverMoveStatus(RoverModel roverModel)
        {

            var rovers = SimulateService._inputDataRef.RoverModels;
            if (roverModel.RoverX > SimulateService._inputDataRef.PlateauModel.PlateauMaxX|| roverModel.RoverY > SimulateService._inputDataRef.PlateauModel.PlateauMaxY)
            {
                throw new Exception("Invalid location for "+roverModel.RoverName);
            }
          

            var anotherRoverIsSameOrigin = (from rover in rovers
                                            where rover.RoverName != roverModel.RoverName && rover.RoverX == roverModel.RoverX && rover.RoverY == roverModel.RoverY
                                            && roverModel.RoverD == rover.RoverD
                                            select rover).Any();


            if (anotherRoverIsSameOrigin)
            {
                throw new Exception("Invalid location for " + roverModel.RoverName +" Because another rover in same origin");
            }
        }

    }

}
