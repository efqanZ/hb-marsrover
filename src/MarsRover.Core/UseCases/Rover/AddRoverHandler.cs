using System.Threading;
using System.Threading.Tasks;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using MediatR;

namespace MarsRover.Core.UseCases.Rover
{
    public class AddRoverHandler : IRequestHandler<AddRoverRequest, RoverDto>
    {
        public async Task<RoverDto> Handle(AddRoverRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}