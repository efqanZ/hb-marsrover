using System;
using MediatR;

namespace MarsRover.Core.Dtos.Request
{
    public class MoveRoverRequest : IRequest<RoverDto>
    {
        public Guid RoverUuid { get; set; }
        public string Commands { get; set; }
    }
}