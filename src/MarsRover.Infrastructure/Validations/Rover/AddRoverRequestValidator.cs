using System;
using System.Linq;
using FluentValidation;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Enums;

namespace MarsRover.Infrastructure.Validations.Rover
{
    public class AddRoverRequestValidator : AbstractValidator<AddRoverRequest>
    {
        public AddRoverRequestValidator()
        {
            RuleFor(r => r.Position)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidPosition)
                .WithMessage("Please type two numbers and a letter(N, E, S, W) with one space character between them.");
        }

        private bool IsValidPosition(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            var splittedPosition = value.Split(' ');

            if (splittedPosition.Length != 3)
                return false;

            if (!int.TryParse(splittedPosition[0], out int positionX))
                return false;

            if (!int.TryParse(splittedPosition[1], out int positionY))
                return false;

            if (!Enum.GetNames(typeof(RoverDirection)).Contains(splittedPosition[2]))
                return false;

            return true;
        }
    }
}