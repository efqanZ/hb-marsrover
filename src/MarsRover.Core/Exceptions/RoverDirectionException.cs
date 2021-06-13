using System;

namespace MarsRover.Core.Exceptions
{
    public class RoverDirectionException : Exception
    {
         public RoverDirectionException() : base ("Invalid direction. Direction should be one of N, E, S or W.")
        {
            
        }
    }
}