using System;
using MediatR;

namespace MarsRover.Core.Dtos.Request
{
    public class AddRoverRequest : IRequest<RoverDto>
    {
        public string Position { get; set; }
    }
}