using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;

namespace MarsRover.Infrastructure.Services
{
    public class PlateauService : BaseService, IPlateauService
    {
        public PlateauService()
        {

        }

        public async Task SetSize(int width, int height)
        {
            Plateau.Width = width;
            Plateau.Height = height;
            
            await Task.CompletedTask;
        }
    }
}