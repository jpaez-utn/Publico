using FluentValidation;
using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("The name is required");
            RuleFor(user => user.Email).NotEmpty().WithMessage("The email is required");
            RuleFor(user => user.Phone).NotEmpty().WithMessage("The phone is required");
            RuleFor(user => user.Address).NotEmpty().WithMessage("The address is required");
        }
    }
}
