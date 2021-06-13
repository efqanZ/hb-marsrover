using MediatR;

namespace MarsRover.Core.Dtos.Request
{
    public class SetSizePlateauRequest: IRequest<PlateauDto>
    {
        public string PlateauSize { get; set; }
    }
}