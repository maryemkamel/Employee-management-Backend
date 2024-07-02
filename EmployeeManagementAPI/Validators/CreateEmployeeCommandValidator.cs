using EmployeeManagementAPI.Commands;
using FluentValidation;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required!!")
            .MaximumLength(60).WithMessage("First name cannot be longer than 60 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required!!")
            .MaximumLength(60).WithMessage("Last name cannot be longer than 60 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required!!")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required!!")
            .Matches(@"^[0-9]{10}$").WithMessage("Phone number must be 10 digits.");

        RuleFor(x => x.Position)
            .NotEmpty().WithMessage("Position is required!!")
            .MaximumLength(100).WithMessage("Position cannot be longer than 100 characters.");

        RuleFor(x => x.Department)
            .NotEmpty().WithMessage("Department is required!!")
            .MaximumLength(100).WithMessage("Department cannot be longer than 100 characters.");
    }
}
