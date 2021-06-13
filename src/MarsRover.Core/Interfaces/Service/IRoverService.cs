using System;
using System.Threading.Tasks;
using MarsRover.Core.Models;

namespace MarsRover.Core.Interfaces.Service
{
    public interface IRoverService
    {
        Task Add(Rover model);
        Task TurnLeft(Guid uuid);
        Task TurnRight(Guid uuid);
        Task MoveForvard(Guid uuid);
        Task<Rover> Get(Guid uuid);
    }
}