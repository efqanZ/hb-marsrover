using System.Threading.Tasks;
using FluentValidation;
using MarsRover.Core.Dtos.Request;
using MarsRover.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.UnitTest.UseCases
{
    public class PlateauUseCasesTest
    {
        private IMediator _mediatR;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();
            var provider = services.BuildServiceProvider();

            _mediatR = provider.GetService<IMediator>();
        }

        [Test]
        public async Task PlateauUseCases_SetSizePlateau()
        {
            var plateau = await _mediatR.Send(new SetSizePlateauRequest { PlateauSize = "5 5" });

            Assert.AreEqual(plateau.X, 5);
            Assert.AreEqual(plateau.Y, 5);
        }

        [Test]
        public void PlateauUseCases_SetSizePlateau_ValidationException()
        {
            var request = new SetSizePlateauRequest { PlateauSize = "A 5" };

            Assert.ThrowsAsync(typeof(ValidationException), () => _mediatR.Send(request));

        }
    }
}