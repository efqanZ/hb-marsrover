using System;
using MarsRover.Core.Enums;

namespace MarsRover.Core.Exceptions
{
    public class PlateauSizeException : Exception
    {
        public PlateauSizeException() : base("Plateau size exceeded.")
        {

        }

        public PlateauSizeException(RoverDirection direction) : base($"Reached plateau {direction} direction boundary. Cannot move forward to this direction!")
        {

        }

        public PlateauSizeException(string message) : base(message)
        {

        }
    }
}