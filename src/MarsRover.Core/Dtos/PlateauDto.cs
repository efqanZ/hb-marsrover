using System;
using System.Collections.Generic;

namespace MarsRover.Core.Dtos
{
    public class PlateauDto
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<RoverDto> Rovers { get; set; }
    }
}