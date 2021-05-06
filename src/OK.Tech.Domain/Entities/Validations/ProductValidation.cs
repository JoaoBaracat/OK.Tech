using FluentValidation;

namespace OK.Tech.Domain.Entities.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .Length(3, 200).WithMessage("The {PropertyName} legth must be between {MinLenght} and {MaxLenght}");


            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .Length(3, 1000).WithMessage("The {PropertyName} legth must be between {MinLenght} and {MaxLenght}");

        }

    }
}
