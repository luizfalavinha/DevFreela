using System.Text.RegularExpressions;
using DevFreela.Application.InputModels;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class NewUserInputModelValidator : AbstractValidator<NewUserInputModel>
    {
        public NewUserInputModelValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracters, um número, uma letra minúscula, uma letra maiíscula e um caractere especial");
        
            RuleFor(p => p.Fullname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex($@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$");

            return regex.IsMatch(password);
        }
    }
}