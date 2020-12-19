using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mars_Rover_App.Data
{
    public class SimulateService
    {
        public static MarsRoverModel _inputDataRef;


        /// <summary>
        /// This method startpoint in execute side.Check input data and execute rover command.
        /// </summary>
        /// <param name="marsRoccerModel"></param>
        public void RunSimulate(MarsRoverModel marsRoccerModel)
        {
            _inputDataRef = marsRoccerModel;

            ValidationService.CheckInputData(marsRoccerModel);

            PlateauSize.PlateauX =(int) marsRoccerModel.PlateauModel.PlateauMaxX;
            PlateauSize.PlateauY = (int) marsRoccerModel.PlateauModel.PlateauMaxY;

            foreach (var rover in marsRoccerModel.RoverModels)
            {
                try
                {
                    ProcessRoverCommand.Execute(rover);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
              
            }

        }
    }
}
