using Mars_Rover_App.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover_Console_App
{
    class Program
    {//MMRMMRMRRM
        public static string inputData= "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
        static void Main(string[] args)
        {
         
            Console.WriteLine("Welcome to Mars Rover");
            MarsRoverModel marsRoverModel = new() { 
            RoverModels=new()
            };
            ParserHelper parserHelper = new(inputData);
            marsRoverModel.PlateauModel = ParserHelper.ParsePlateauOrigin();
            Console.WriteLine("Plateu Range : X:" + marsRoverModel.PlateauModel.PlateauMaxX + " Y:" + marsRoverModel.PlateauModel.PlateauMaxY);

            while (true)
            {
                RoverModel newRover =  ParserHelper.GetNextRover();
                if (newRover == null)
                {
                    break;
                }
                marsRoverModel.RoverModels.Add(newRover);

            }
           

            foreach (var rover in marsRoverModel.RoverModels)
            {
                Console.WriteLine(rover.RoverName+ ": X:" + rover.RoverX + " Y:" + rover.RoverY+ " Direction : "+rover.RoverD +" Rover Commands : "+ rover.RoverCommands);

            }

            SimulateService simulate = new();

            simulate.RunSimulate(marsRoverModel);
            Console.WriteLine("Last Origin For Rovers");
            foreach (var rover in marsRoverModel.RoverModels)
            {
                Console.WriteLine(rover.RoverName + ": X:" + rover.RoverX + " Y:" + rover.RoverY + " Direction : " + rover.RoverD );

            }

        }
    }
}
