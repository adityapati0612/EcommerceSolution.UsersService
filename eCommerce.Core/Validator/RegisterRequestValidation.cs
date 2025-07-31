using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class RegisterRequestValidation:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidation()
    {
        RuleFor(temp=>temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName is required");
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender is required");




    }
}
