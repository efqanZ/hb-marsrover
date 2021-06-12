using System;
using MediatR;

namespace MarsRover.Core.Dtos.Request
{
    public class AddRoverRequest : IRequest<RoverDto>
    {
        public Guid PlateauUuid { get; set; }
        public string Position { get; set; }
    }
}