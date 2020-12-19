using Mars_Rover_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Console_App
{
    public class ParserHelper
    {
        private static string[] allCommandsLine;
        private static int roverIndex = 1;
        public ParserHelper(string data)
        {
            allCommandsLine = ParseLines(data);

        }
        public static PlateauModel ParsePlateauOrigin()
        {

            var plateuOrigin = ParseWithSpace(allCommandsLine[0]);
            var response = new PlateauModel();
            var origins = ConvertOrigin(plateuOrigin);
            response.PlateauMaxX = origins.Item1;
            response.PlateauMaxY = origins.Item2;
            return response;
        }
        public static RoverModel GetNextRover()
        {
            var response = new RoverModel();
            if (allCommandsLine.Length <= roverIndex + 1)
            {
                return null;
            }
            var roverText = allCommandsLine[roverIndex];
            var roverCommands = allCommandsLine[roverIndex + 1];

            var roverData = ParseWithSpace(roverText);
            var origins = ConvertOrigin(roverData);
            response.RoverName = "Rover "+(roverIndex);
            response.RoverX = origins.Item1;
            response.RoverY = origins.Item2;
            response.RoverD = roverData[2];
            response.RoverCommands = roverCommands;
            roverIndex+=2;
            return response;
        }

        private static string[] ParseWithSpace(string txt)
        {
            return txt.Split(" ");
        }
        private static string[] ParseLines(string txt)
        {
            string[] lines = txt.Split(
          new[] { "\r\n", "\r", "\n" },
          StringSplitOptions.None
              );
            return lines;
        }

        private static Tuple<int, int> ConvertOrigin(string[] data)
        {


            int x = 0;
            int y = 0;
            int.TryParse(data[0], out x);

            int.TryParse(data[1], out y);

            return new Tuple<int, int>(x, y);
        }
    }
}
