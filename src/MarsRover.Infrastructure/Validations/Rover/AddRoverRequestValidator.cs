using FluentValidation;
using MarsRover.Core.Dtos.Request;

namespace MarsRover.Infrastructure.Validations.Rover
{
    public class AddRoverRequestValidator: AbstractValidator<AddRoverRequest>
    {
        public AddRoverRequestValidator()
        {
            //Please type two numbers and a letter(N, E, S, W) with one space character between them.
        }
    }
}