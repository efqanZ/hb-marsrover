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

            if (!int.TryParse(splittedSize[0], out int width) ||
                !int.TryParse(splittedSize[1], out int height) ||
                width == 0 || height == 0)
                throw new PlateauSizeException("Please type two numbers (except 0) with one space character between them.");


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