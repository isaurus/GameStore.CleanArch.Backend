using FluentValidation;
using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Application.Features.Game.Validators
{
    public class GameModelValidator : AbstractValidator<GameModel>
    {
        public GameModelValidator()
        {
            RuleFor(g => g.Title)
                .NotEmpty().WithMessage("El título del juego es obligatorio")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres")
                .Matches(@"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ.,:;¡!¿?\-']+$")
                .WithMessage("El título contiene caracteres no permitidos");

            RuleFor(g => g.Description)
                .MaximumLength(255).WithMessage("Máximo 255 caracteres");

            RuleFor(x => x.Release)
                .NotEmpty().WithMessage("La fecha de lanzamiento es requerida")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("La fecha de lanzamiento no puede ser futura");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0")
                .PrecisionScale(6, 2, false)
                .WithMessage("El precio debe tener máximo 2 decimales y 6 dígitos en total");
        }
    }
}
