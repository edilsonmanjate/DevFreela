using DevFreela.Application.Commands.CreateUser;

using FluentValidation;

using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p=>p.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(p=>p.Password)
                .Must(ValidatePassword)
                .NotNull()
                .WithMessage("Senha inválida");

            RuleFor(p=>p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome inválido");

            RuleFor(p=>p.BirthDate)
                .LessThan(DateTime.Now)
                .WithMessage("Data de nascimento inválida");

        }

      
        public bool ValidatePassword(string password) {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            return regex.IsMatch(password);
        }
    }
}
