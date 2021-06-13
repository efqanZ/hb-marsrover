using System;
using System.Linq;
using FluentValidation;
using MarsRover.Core.Dtos.Request;
using MarsRover.Core.Enums;

namespace MarsRover.Infrastructure.Validations.Rover
{
    public class MoveRoverRequestValidator : AbstractValidator<MoveRoverRequest>
    {
        public MoveRoverRequestValidator()
        {
            RuleFor(r => r.RoverUuid).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Please enter rover Uuid");

            RuleFor(r => r.Commands).Cascade(CascadeMode.Stop)
                .Must(IsValidCommands)
                .WithMessage("Invalid rover command. Command letter should be one of L,R or M.");
        }

        private bool IsValidCommands(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            foreach (var command in value.ToCharArray())
            {
                switch (command)
                {
                    case 'L':
                    case 'R':
                    case 'M':
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }
    }
}