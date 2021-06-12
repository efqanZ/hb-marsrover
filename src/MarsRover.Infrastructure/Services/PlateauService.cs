using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Core.Models;

namespace MarsRover.Infrastructure.Services
{
    public class PlateauService : IPlateauService
    {
        private static List<Plateau> PlateauList = new List<Plateau>();
        public PlateauService()
        {

        }

        public async Task Add(Plateau model)
        {
            model.Uuid = Guid.NewGuid();
            PlateauList.Add(model);
            
            await Task.CompletedTask;
        }
    }
}