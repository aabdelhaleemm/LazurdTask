using FluentValidation;
using Lazurdit.Domain.Entities;

namespace Lazurdit.Application.Validators;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.PhoneNumber)
            .NotEmpty();
    }
}