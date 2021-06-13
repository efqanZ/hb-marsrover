using FluentValidation;
using MarsRover.Core.Dtos.Request;

namespace MarsRover.Infrastructure.Validations.Rover
{
    public class MoveRoverRequestValidator : AbstractValidator<MoveRoverRequest>
    {
        public MoveRoverRequestValidator()
        {
            
        }
    }
}