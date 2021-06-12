using MarsRover.Core.Enums;

namespace MarsRover.Core.Models
{
    public class Rover
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        RoverDirection Direction { get; set; }
        string Commands { get; set; }
        public virtual Plateau Plateau { get; set; }
    }
}