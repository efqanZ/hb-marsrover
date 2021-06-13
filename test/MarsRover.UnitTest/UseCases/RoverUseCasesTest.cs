using System.Threading.Tasks;
using FluentValidation;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Enums;
using MarsRover.Core.Exceptions;
using MarsRover.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.UnitTest.UseCases
{
    public class RoverUseCasesTest
    {
        private IMediator _mediatR;
        private PlateauDto Plateau;

        [SetUp]
        public async Task Setup()
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();
            var provider = services.BuildServiceProvider();

            _mediatR = provider.GetService<IMediator>();

            Plateau = await _mediatR.Send(new SetSizePlateauRequest { PlateauSize = "5 5" });
        }

        [Test]
        public async Task RoverUseCases_AddRover()
        {
            var rover = await _mediatR.Send(new AddRoverRequest { Position = "1 2 N" });

            Assert.AreEqual(1, rover.PositionX);
            Assert.AreEqual(2, rover.PositionY);
            Assert.AreEqual(RoverDirection.N, rover.Direction);
        }

        [Test]
        public void RoverUseCases_AddRover_ValidationException()
        {
            var request = new AddRoverRequest { Position = "-1 2 T" };
            Assert.ThrowsAsync(typeof(ValidationException), () => _mediatR.Send(request));
        }

        [Test]
        public void RoverUseCases_AddRover_PlateauSizeException()
        {
            var request = new AddRoverRequest { Position = "6 2 N" };
            Assert.ThrowsAsync(typeof(PlateauSizeException), () => _mediatR.Send(request));
        }

        [Test]
        public async Task RoverUseCases_MoveRover()
        {
            var rover = await _mediatR.Send(new AddRoverRequest { Position = "1 2 N" });

            var request = new MoveRoverRequest { RoverUuid = rover.RoverUuid, Commands = "LMLMLMLMM" };
            rover = await _mediatR.Send(request);
            Assert.AreEqual(1, rover.PositionX);
            Assert.AreEqual(3, rover.PositionY);
            Assert.AreEqual(RoverDirection.N, rover.Direction);

        }

        [Test]
        public async Task RoverUseCases_MoveRover_ValidationException()
        {
            var rover = await _mediatR.Send(new AddRoverRequest { Position = "1 2 N" });

            var request = new MoveRoverRequest { RoverUuid = rover.RoverUuid, Commands = "LMXLMLMLMM" };

            Assert.ThrowsAsync(typeof(ValidationException), () => _mediatR.Send(request));
        }

        [Test]
        public async Task RoverUseCases_MoveRover_PlateauSizeException()
        {
            var rover = await _mediatR.Send(new AddRoverRequest { Position = "1 2 N" });

            var request = new MoveRoverRequest { RoverUuid = rover.RoverUuid, Commands = "LMMMMMMMMMMMM" };

            Assert.ThrowsAsync(typeof(PlateauSizeException), () => _mediatR.Send(request));
        }
    }
}