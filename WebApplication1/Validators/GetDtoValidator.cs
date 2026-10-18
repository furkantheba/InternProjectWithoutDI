using FluentValidation;
using WebApplication1.Models.DTO;

namespace WebApplication1.Validators;

public class GetDtoValidator : AbstractValidator<GetDto>
{
    public GetDtoValidator()
    {
        RuleFor(x => x.name).MaximumLength(50).WithMessage("Bu kadar uzun olamaz.").MinimumLength(0)
            .WithMessage("Bu kadar Kısa Olamaz");
        RuleFor(x => x.name).MaximumLength(50).WithMessage("Bu kadar uzun olamaz.").MinimumLength(0)
            .WithMessage("Bu kadar Kısa Olamaz");
        RuleFor(x => x.pageSize).InclusiveBetween(0, 9999).WithMessage("Page size uygun değil.");
        RuleFor(x => x.page).InclusiveBetween(0, 9999).WithMessage("Page uygun değil.");

    }
}