using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithErrorCode("Tamanho Maximo de descrição é de 255 caracteres");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho maximo do título é de 30 carcteres");

              
         
                
        }
    }
}
