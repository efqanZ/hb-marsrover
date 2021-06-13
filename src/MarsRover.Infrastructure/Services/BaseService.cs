using System.Collections.Generic;
using MarsRover.Core.Models;

namespace MarsRover.Infrastructure.Services
{
    public abstract class BaseService
    {
        public BaseService()
        {

        }

        protected static Core.Models.Plateau Plateau = new Core.Models.Plateau()
        {
            Uuid = System.Guid.NewGuid(),
            Rovers = new List<Rover>()
        };
    }
}