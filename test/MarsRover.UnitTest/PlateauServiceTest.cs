using System.Threading.Tasks;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;
using MarsRover.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    public class PlateauServiceTest
    {
        private IPlateauService _plateauService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();
            var provider = services.BuildServiceProvider();

            _plateauService = provider.GetService<IPlateauService>();
        }

        [Test]
        public async Task Plateau_SetSize()
        {
            Plateau plateau = await _plateauService.SetSize(1,5);

            Assert.AreEqual(1, plateau.Width);
            Assert.AreEqual(5, plateau.Height);
        }


        [Test]
        public void Rover_SetSize_PlateauSizeException()
        {
            Assert.ThrowsAsync(typeof(PlateauSizeException), () => _plateauService.SetSize(5, -1));
        }
    }
}