using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public  class RotateService 
    {
        private static readonly LinkedList<string> directions =
                        new LinkedList<string>(new[] { "N", "W", "S", "E" });

        private static readonly Dictionary<string, Action<RoverModel>> RoteteActions =
                                new Dictionary<string, Action<RoverModel>>
        {
        {"L", TurnLeft},
        {"R", TurnRight}
        };

        /// <summary>
        /// Rover is rotated direction by Rotete method. This method rotate to the rover direction newDirectionCommand.
        /// </summary>
        /// <param name="newDirectionCommand"></param>
        /// <param name="roverModel"></param>
        public static void Rotete(string newDirectionCommand, RoverModel roverModel)
        {
            RoteteActions[newDirectionCommand](roverModel);
        }

        private static void TurnRight(RoverModel roverModel)
        {
            LinkedListNode<string> currentIndex = directions.Find(roverModel.RoverD);
            LinkedListNode<string> newDirection = currentIndex.Previous ?? currentIndex.List.Last;
            roverModel.RoverD = newDirection.Value;
        }

        private static void TurnLeft(RoverModel roverModel)
        {
            LinkedListNode<string> currentIndex = directions.Find(roverModel.RoverD);
            LinkedListNode<string> newDirection = currentIndex.Next ?? currentIndex.List.First;
            roverModel.RoverD = newDirection.Value;
        }

      
    }






}
