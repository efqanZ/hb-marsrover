using System.Threading.Tasks;
using MarsRover.Core.Models;

namespace MarsRover.Core.Interfaces.Service
{
    public interface IPlateauService
    {
        Task<Plateau> SetSize(int width, int height);
    }
}