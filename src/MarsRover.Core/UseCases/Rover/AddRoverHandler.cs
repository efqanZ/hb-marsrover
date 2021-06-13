using System;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Enums;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MediatR;

namespace MarsRover.Core.UseCases.Rover
{
    public class AddRoverHandler : IRequestHandler<AddRoverRequest, RoverDto>
    {
        private readonly IRoverService _roverService;
        public AddRoverHandler(IRoverService roverService)
        {
            _roverService = roverService;
        }
        public async Task<RoverDto> Handle(AddRoverRequest request, CancellationToken cancellationToken)
        {
            var splittedPosition = request.Position.Split(' ');

            var rover = new Models.Rover
            {
                Direction = (RoverDirection)Enum.Parse(typeof(RoverDirection), splittedPosition[2]),
                PositionX = int.Parse(splittedPosition[0]),
                PositionY = int.Parse(splittedPosition[1])
            };

            await _roverService.Add(rover);

            return new RoverDto
            {
                Direction = rover.Direction,
                PositionX = rover.PositionX,
                PositionY = rover.PositionY,
                RoverUuid = rover.Uuid
            };

        }
    }
}