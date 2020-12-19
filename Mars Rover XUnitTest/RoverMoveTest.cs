using Mars_Rover_App.Data;
using System;
using System.Linq;
using Xunit;


namespace Mars_Rover_XUnitTest
{
    public class RoverMoveTest
    {
        MarsRoverModel marsRoverModel = new();
        public RoverMoveTest()
        {
            marsRoverModel.PlateauModel = new() { PlateauMaxX = 5, PlateauMaxY = 5 };
            marsRoverModel.RoverModels = new();


        }
        [Fact]
        public void MoveTest()
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

            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            // Assert
            Assert.Equal(4, marsRoverModel.RoverModels.FirstOrDefault().RoverY);
        }
        [Fact]
        public void MoveExceptionTest()
        {

            // Arrange
            marsRoverModel.RoverModels.Add(new RoverModel()
            {
                RoverName = "Rover 1",
                RoverD = "N",
                RoverX = 1,
                RoverY = 2,
                RoverCommands = "MMMMMM"

            });
            SimulateService._inputDataRef = marsRoverModel;

            // Act

            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            MoveService.Move(marsRoverModel.RoverModels.FirstOrDefault());
            // Assert
            Assert.Equal(4, marsRoverModel.RoverModels.FirstOrDefault().RoverY);
        }


    }



}
