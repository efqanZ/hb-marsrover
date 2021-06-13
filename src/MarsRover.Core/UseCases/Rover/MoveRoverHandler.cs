using System.Threading;
using System.Threading.Tasks;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MediatR;

namespace MarsRover.Core.UseCases.Rover
{
    public class MoveRoverHandler : IRequestHandler<MoveRoverRequest, RoverDto>
    {
        private readonly IRoverService _roverService;
        public MoveRoverHandler(IRoverService roverService)
        {
            _roverService = roverService;
        }
        public async Task<RoverDto> Handle(MoveRoverRequest request, CancellationToken cancellationToken)
        {
            var commands = request.Commands.ToCharArray();

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        await _roverService.TurnLeft(request.RoverUuid);
                        break;
                    case 'R':
                        await _roverService.TurnRight(request.RoverUuid);
                        break;
                    case 'M':
                        await _roverService.MoveForvard(request.RoverUuid);
                        break;
                    default:
                        throw new CommandException();
                }
            }

            var rover = await _roverService.Get(request.RoverUuid);

            return new RoverDto
            {
                RoverUuid = rover.Uuid,
                Direction = rover.Direction,
                PositionX = rover.PositionX,
                PositionY = rover.PositionY
            };
        }
    }
}