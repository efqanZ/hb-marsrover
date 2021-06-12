using System;
using MarsRover.Core.Enums;

namespace MarsRover.Core.Dtos
{
    public class RoverDto
    {
        public Guid RoverUuid { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public RoverDirection Direction { get; set; }
        public PlateauDto Plateau { get; set; }
    }
}