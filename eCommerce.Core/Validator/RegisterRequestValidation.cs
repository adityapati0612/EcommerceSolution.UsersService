using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class RegisterRequestValidation:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidation()
    {
        RuleFor(temp=>temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName can't be blank").Length(1,50).WithMessage("Person name should be 1 to 50 charachters long");
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender is required");




    }
}
