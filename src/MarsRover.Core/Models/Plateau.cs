using System.Collections.Generic;

namespace MarsRover.Core.Models
{
    public class Plateau
    {
        int Width { get; set; }
        int Height { get; set; }

        public virtual ICollection<Rover> Rovers { get; set; }
    }
}