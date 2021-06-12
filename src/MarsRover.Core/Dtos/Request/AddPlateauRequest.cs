using MediatR;

namespace MarsRover.Core.Dtos.Request
{
    public class AddPlateauRequest: IRequest<PlateauDto>
    {
        public string PlateauSize { get; set; }
    }
}