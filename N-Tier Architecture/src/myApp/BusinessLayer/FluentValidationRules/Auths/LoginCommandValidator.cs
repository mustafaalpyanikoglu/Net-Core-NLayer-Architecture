using BusinessLayer.DTOs.Auths;
using FluentValidation;

namespace BusinessLayer.FluentValidationRules.Auths;

public class LoginCommandValidator : AbstractValidator<UserForLoginDto>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(3);
    }
}
