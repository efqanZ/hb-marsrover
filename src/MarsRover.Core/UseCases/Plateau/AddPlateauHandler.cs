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
    public class AddPlateauHandler : IRequestHandler<AddPlateauRequest, PlateauDto>
    {
        private readonly IPlateauService _plateauService;
        public AddPlateauHandler(IPlateauService plateauService)
        {
            _plateauService = plateauService;
        }

        public async Task<PlateauDto> Handle(AddPlateauRequest request, CancellationToken cancellationToken)
        {
            var splittedSize = request.PlateauSize.Split(' ');

            if (!int.TryParse(splittedSize[0], out int width)
                ||
                !int.TryParse(splittedSize[1], out int height)
                ||
                width == 0
                ||
                height == 0)
                throw new PlateauSizeException("Please type two numbers (except 0) with one space character between them.");

            var plateau = new Models.Plateau
            {
                Width = int.Parse(splittedSize[0]),
                Height = int.Parse(splittedSize[1])
            };

            await _plateauService.Add(plateau);

            return new PlateauDto
            {
                PlateauUuId = plateau.Uuid,
                X = plateau.Width,
                Y = plateau.Height
            };
        }
    }
}