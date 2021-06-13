using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Collections.Generic;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        private static ServiceProvider InitializeServices()
        {
            var services = new ServiceCollection();
            services.ConfigureServices();
            return services.BuildServiceProvider();
        }


        static async Task Main(string[] args)
        {
            var provider = InitializeServices();

            Console.WriteLine("Welcome to the HB Mars Rover");
            Console.WriteLine("*******************************************");

            var mediator = provider.GetService<IMediator>();

            Console.WriteLine("\nPlease enter the plateau (like '6 6'): ");
            var size = Console.ReadLine();
            var plateau = await mediator.Send(new SetSizePlateauRequest { PlateauSize = size });

            while (true)
            {
                try
                {

                    Console.WriteLine("\nEnter position for rover (like '1 2 N'): ");
                    var position = Console.ReadLine();
                    var rover = await mediator.Send(new AddRoverRequest { Position = position });

                    Console.WriteLine("\nEnter your rover commands (like 'LMLMLMLMM'): ");
                    var commands = Console.ReadLine();
                    rover = await mediator.Send(new MoveRoverRequest { RoverUuid = rover.RoverUuid, Commands = commands });

                    plateau.Rovers.Add(rover);

                }
                catch (System.Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{ex.Message}");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine("\nDo you want to add another Rover?(Y/N): ");
                var answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                    break;
            }


            if (plateau.Rovers != null)
            {
                foreach (var rover in plateau.Rovers)
                {
                    Console.WriteLine($"\n{rover.PositionX} {rover.PositionY} {rover.Direction}");
                }
            }


            Console.Read();

        }
    }
}
