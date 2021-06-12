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

            var mediator = provider.GetService<Mediator>();
            List<PlateauDto> plateauList = new List<PlateauDto>();
            while (true)
            {
                Console.WriteLine("\nPlease enter the plateau (like '6 6'): ");
                var size = Console.ReadLine();
                var plateau = await mediator.Send(new AddPlateauRequest { PlateauSize = size });
                plateauList.Add(plateau);

                Console.WriteLine("\nEnter position for rover (like '1 2 N'): ");
                var position = Console.ReadLine();
                

                //ToDo:!!


                Console.WriteLine("\nDo you want to add another Rover?(Y/N): ");
                var answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                    break;
            }


            Console.Read();

        }
    }
}
