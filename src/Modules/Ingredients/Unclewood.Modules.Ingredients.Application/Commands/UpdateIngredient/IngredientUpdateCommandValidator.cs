using FluentValidation;

namespace Unclewood.Modules.Ingredients.Application.Commands.UpdateIngredient;

public class IngredientUpdateCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    public IngredientUpdateCommandValidator()
    {
        RuleFor(x => x.Name).Length(2, 50).WithMessage("Name must be between 3 and 50 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Name));
    }
}