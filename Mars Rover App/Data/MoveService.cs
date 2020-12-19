using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public class MoveService
    {
        
        private static Dictionary<string, Action<RoverModel>> MoveActions =
                          new Dictionary<string, Action<RoverModel>>
                              {
                                    {"N", MoveNorth},
                                    {"W", MoveWest},
                                    {"S", MoveSouth},
                                    {"E", MoveEast}
                              };

        /// <summary>
        /// Rover is moved next origin by move method. This method increases to the x or y  according direction information.
        /// </summary>
        /// <param name="roverModel"></param>
        public static void Move( RoverModel roverModel)
        {
            string currentDirection = roverModel.RoverD;
            MoveActions[currentDirection](roverModel);
        }

        // Yon N move y+1
        //yon w move x-1
        //yon e move x+1
        ////yon s m y-1

        private static void  MoveEast(RoverModel roverModel)
        {
            roverModel.RoverX +=1;
            ValidationService.CheckRoverMoveStatus(roverModel);


        }

        private static void  MoveSouth(RoverModel roverModel)
        {
            roverModel.RoverY -=1;
            ValidationService.CheckRoverMoveStatus(roverModel);

        }

        private static void  MoveWest(RoverModel roverModel)
        {
            roverModel.RoverX -=1;
            ValidationService.CheckRoverMoveStatus(roverModel);
        }

        private static void  MoveNorth(RoverModel roverModel)
        {
            roverModel.RoverY += 1;
            ValidationService.CheckRoverMoveStatus(roverModel);

        }

    }

}
