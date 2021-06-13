using System;
using MarsRover.Core.Enums;

namespace MarsRover.Core.Models
{
    public class Rover
    {
        public Guid Uuid { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public RoverDirection Direction { get; set; }
    }
}