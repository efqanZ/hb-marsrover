using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;

namespace MarsRover.Infrastructure.Services
{
    public class PlateauService : BaseService, IPlateauService
    {
        public PlateauService()
        {

        }

        public async Task<Plateau> SetSize(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new PlateauSizeException("Plateau width or height cannot be 0");

            Plateau.Width = width;
            Plateau.Height = height;

            await Task.CompletedTask;
            return Plateau;
        }
    }
}