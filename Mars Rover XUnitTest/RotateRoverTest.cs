using Mars_Rover_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mars_Rover_XUnitTest
{
    public class RotateRoverTest
    {
        MarsRoverModel marsRoverModel = new();
        public RotateRoverTest()
        {
            marsRoverModel.PlateauModel = new() { PlateauMaxX = 5, PlateauMaxY = 5 };
            marsRoverModel.RoverModels = new();


        }

        [Fact]
        public void RorateRightTest()
        {

            // Arrange
            marsRoverModel.RoverModels.Add(new RoverModel()
            {
                RoverName = "Rover 1",
                RoverD = "N",
                RoverX = 1,
                RoverY = 2,
                RoverCommands = "MM"

            });
            SimulateService._inputDataRef = marsRoverModel;

            // Act
            RotateService.Rotete("R", marsRoverModel.RoverModels.FirstOrDefault());
           
            // Assert
            Assert.Equal("E", marsRoverModel.RoverModels.FirstOrDefault().RoverD);
        }


        [Fact]
        public void RorateLeftTest()
        {

            // Arrange
            marsRoverModel.RoverModels.Add(new RoverModel()
            {
                RoverName = "Rover 2",
                RoverD = "N",
                RoverX = 1,
                RoverY = 2,
                RoverCommands = "MM"

            });
            SimulateService._inputDataRef = marsRoverModel;
            var rover = marsRoverModel.RoverModels.Where(x => x.RoverName == "Rover 2").FirstOrDefault();
            // Act
            RotateService.Rotete("L", rover);

            // Assert
            Assert.Equal("W", rover.RoverD);
        }
    }
}
