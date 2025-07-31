using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is Required").EmailAddress().WithMessage("Invalid Email Format");

        //Password
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password can not be empty");
    }
}
