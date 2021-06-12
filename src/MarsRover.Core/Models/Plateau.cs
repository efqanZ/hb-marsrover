using System;
using System.Collections.Generic;

namespace MarsRover.Core.Models
{
    public class Plateau
    {
        public Guid Uuid { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual ICollection<Rover> Rovers { get; set; }
    }
}