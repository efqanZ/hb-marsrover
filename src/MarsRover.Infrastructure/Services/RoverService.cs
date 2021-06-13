using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Core.Enums;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;

namespace MarsRover.Infrastructure.Services
{
    public class RoverService : BaseService, IRoverService
    {
        public async Task Add(Rover model)
        {
            model.Uuid = Guid.NewGuid();

            if (model.PositionX > Plateau.Width || model.PositionY > Plateau.Height)
                throw new PlateauSizeException();

            Plateau.Rovers.Add(model);

            await Task.CompletedTask;
        }

        public async Task<Rover> Get(Guid uuid)
        {
            var rover = Plateau.Rovers.FirstOrDefault(ap => ap.Uuid == uuid);
            await Task.CompletedTask;

            return rover;
        }

        public async Task MoveForvard(Guid uuid)
        {
            var rover = await Get(uuid);

            if (!CheckBoundaries(rover))
                return;

            switch (rover.Direction)
            {
                case RoverDirection.N:
                    rover.PositionY++;
                    break;
                case RoverDirection.E:
                    rover.PositionX++;
                    break;
                case RoverDirection.S:
                    rover.PositionY--;
                    break;
                case RoverDirection.W:
                    rover.PositionX--;
                    break;
                default:
                    throw new RoverDirectionException();
            }
        }

        public async Task TurnLeft(Guid uuid)
        {
            var rover = await Get(uuid);

            switch (rover.Direction)
            {
                case RoverDirection.N:
                    rover.Direction = RoverDirection.W;
                    break;
                case RoverDirection.E:
                    rover.Direction = RoverDirection.N;
                    break;
                case RoverDirection.S:
                    rover.Direction = RoverDirection.E;
                    break;
                case RoverDirection.W:
                    rover.Direction = RoverDirection.S;
                    break;
                default:
                    throw new RoverDirectionException();
            }
        }

        public async Task TurnRight(Guid uuid)
        {
            var rover = await Get(uuid);

            switch (rover.Direction)
            {
                case RoverDirection.N:
                    rover.Direction = RoverDirection.E;
                    break;
                case RoverDirection.E:
                    rover.Direction = RoverDirection.S;
                    break;
                case RoverDirection.S:
                    rover.Direction = RoverDirection.W;
                    break;
                case RoverDirection.W:
                    rover.Direction = RoverDirection.N;
                    break;
                default:
                    throw new RoverDirectionException();
            }
        }

        private bool CheckBoundaries(Rover rover)
        {
            if (
                (rover.Direction == RoverDirection.N && (rover.PositionY == Plateau.Height)) ||
                (rover.Direction == RoverDirection.S && (rover.PositionY == 0)) ||
                (rover.Direction == RoverDirection.E && (rover.PositionX == Plateau.Width)) ||
                (rover.Direction == RoverDirection.W && (rover.PositionX == 0)))
                throw new PlateauSizeException(rover.Direction);

            return true;
        }
    }
}