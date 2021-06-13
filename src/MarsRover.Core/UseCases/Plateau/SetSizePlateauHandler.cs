using System;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.Core.Dtos;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces.Service;
using MediatR;

namespace MarsRover.Core.UseCases.Plateau
{
    public class SetSizePlateauHandler : IRequestHandler<SetSizePlateauRequest, PlateauDto>
    {
        private readonly IPlateauService _plateauService;
        public SetSizePlateauHandler(IPlateauService plateauService)
        {
            _plateauService = plateauService;
        }

        public async Task<PlateauDto> Handle(SetSizePlateauRequest request, CancellationToken cancellationToken)
        {
            var splittedSize = request.PlateauSize.Split(' ');
            int width = int.Parse(splittedSize[0]);
            int height = int.Parse(splittedSize[1]);

            await _plateauService.SetSize(width, height);

            return new PlateauDto
            {
                X = width,
                Y = height,
                Rovers = new System.Collections.Generic.List<RoverDto>()
            };
        }
    }
}