using FluentValidation;
using MarsRover.Core.Dtos.Request;

namespace MarsRover.Infrastructure.Validations.Plateau
{
    public class SetSizePlateauRequestValidator : AbstractValidator<SetSizePlateauRequest>
    {
        public SetSizePlateauRequestValidator()
        {
            RuleFor(x => x.PlateauSize).Cascade(CascadeMode.Stop)
                                       .Must(IsValidSize)
                                       .WithMessage("Please type two numbers (except 0) with one space character between them.");
        }

        private bool IsValidSize(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            var splittedSize = value.Split(' ');

            if (splittedSize.Length != 2)
                return false;

            if (!int.TryParse(splittedSize[0], out int width))
                return false;

            if (!int.TryParse(splittedSize[1], out int height))
                return false;

            return true;

        }
    }
}