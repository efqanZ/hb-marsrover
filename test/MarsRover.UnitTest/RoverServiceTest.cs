using System;
using System.Threading.Tasks;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;
using MarsRover.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    public class RoverServiceTest
    {
        private IRoverService _roverService;

        private Plateau _pleateau;

        [SetUp]
        public async Task Setup()
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();
            var provider = services.BuildServiceProvider();

            _roverService = provider.GetService<IRoverService>();

            var plateauService = provider.GetService<IPlateauService>();
            _pleateau = await plateauService.SetSize(5, 5);
            await _roverService.Add(new Rover
            {
                Direction = Core.Enums.RoverDirection.N,
                PositionX = 1,
                PositionY = 2
            });

        }

        [Test]
        public void Rover_Add()
        {
            var rover = new Rover
            {
                Direction = Core.Enums.RoverDirection.N,
                PositionX = 1,
                PositionY = 2
            };

            Assert.DoesNotThrowAsync(() => _roverService.Add(rover));
        }

        [Test]
        public void Rover_Add_PlateauSizeException()
        {
            var rover = new Rover
            {
                Direction = Core.Enums.RoverDirection.N,
                PositionX = 7,
                PositionY = 2
            };

            Assert.ThrowsAsync(typeof(PlateauSizeException), () => _roverService.Add(rover));
        }

        [Test]
        public async Task Rover_Get()
        {
            var rover = _pleateau.Rovers[0];

            var respRover = await _roverService.Get(rover.Uuid);

            Assert.AreEqual(rover.Uuid, respRover.Uuid);
            Assert.AreEqual(rover.PositionX, respRover.PositionX);
            Assert.AreEqual(rover.PositionY, respRover.PositionY);
        }

        [Test]
        public void Rover_Get_ArgumentNullException()
        {
            Guid randomGuid = Guid.NewGuid();

            Assert.ThrowsAsync(typeof(ArgumentNullException), () => _roverService.Get(randomGuid));
        }

        [Test]
        public void Rover_MoveForvard()
        {
            var rover = _pleateau.Rovers[0];
            Assert.DoesNotThrowAsync(() => _roverService.MoveForvard(rover.Uuid));
        }

        [Test]
        public void Rover_TurnLeft()
        {
            var rover = _pleateau.Rovers[0];
            Assert.DoesNotThrowAsync(() => _roverService.TurnLeft(rover.Uuid));
        }

        [Test]
        public void Rover_TurnRight()
        {
            var rover = _pleateau.Rovers[0];
            Assert.DoesNotThrowAsync(() => _roverService.TurnRight(rover.Uuid));
        }
    }
}