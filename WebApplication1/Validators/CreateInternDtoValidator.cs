using FluentValidation;
using WebApplication1.Models.DTO;

namespace WebApplication1.Validators;

public class CreateInternDtoValidator : AbstractValidator<CreateInternDto>
{
    public CreateInternDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakma.").MaximumLength(50)
            .WithMessage("O kadar uzun isim olmaz").MinimumLength(3).WithMessage("3 karakterden kısa isim olmaz.");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Boş Bırakma.").MaximumLength(50)
            .WithMessage("O kadar uzun soyisim olmaz").MinimumLength(3).WithMessage("3 karakterden kısa soyisim olmaz.");
    }
}