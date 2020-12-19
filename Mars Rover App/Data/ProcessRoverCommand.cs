using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public static class ProcessRoverCommand
    {

        /// <summary>
        /// This method analize rover command and execute it.
        /// </summary>
        /// <param name="roverModel"></param>
       public static void Execute(RoverModel roverModel)
        {
            foreach (var command in roverModel.RoverCommands)
            {
                switch (command)
                {
                    case 'M':
                        MoveService.Move(roverModel);
                        break;
                    case 'L':
                    case 'R':
                        RotateService.Rotete(command.ToString(), roverModel);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
