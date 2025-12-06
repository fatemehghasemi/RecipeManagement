using Application.Recipe.ResponseModels;
using FluentValidation;

namespace Application.Validators
{
    public class RecipeValidator : AbstractValidator<RecipeResponse>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(x => x.Calories)
                .GreaterThanOrEqualTo(0).WithMessage("Calories must be 0 or more.");

            RuleFor(x => x.Protein)
                .GreaterThanOrEqualTo(0).WithMessage("Protein must be 0 or more.");

            RuleFor(x => x.Fat)
                .GreaterThanOrEqualTo(0).WithMessage("Fat must be 0 or more.");

            RuleFor(x => x.Carbs)
                .GreaterThanOrEqualTo(0).WithMessage("Carbs must be 0 or more.");

            RuleFor(x => x.Tags)
                .NotEmpty().WithMessage("Tags are required.")
                .MaximumLength(500).WithMessage("Tags cannot exceed 500 characters.");
        }
    }
}
