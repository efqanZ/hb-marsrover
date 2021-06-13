using System;

namespace MarsRover.Core.Exceptions
{
    public class RoverPositionException : Exception
    {
        public RoverPositionException() : base("Please type two numbers and a letter(N, E, S, W) with one space character between them.")
        {
            
        }
    }
}