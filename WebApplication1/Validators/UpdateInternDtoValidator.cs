using FluentValidation;
using WebApplication1.Models.DTO;

namespace WebApplication1.Validators;

public class UpdateInternDtoValidator: AbstractValidator<UpdateInternDto>
{

    public UpdateInternDtoValidator()
    {
        RuleFor(o => o.Name).NotEmpty().WithMessage("Name is required").MinimumLength(3).WithMessage("Çok kısa")
            .MaximumLength(50).WithMessage("Çok uzun");
        RuleFor(o => o.Surname).NotEmpty().WithMessage("SurnName is required").MinimumLength(3).WithMessage("Çok kısa")
            .MaximumLength(50).WithMessage("Çok uzun");
        RuleFor(o => o.Phone).NotEmpty().WithMessage("Phone is required").InclusiveBetween(1,99999).WithMessage("Phone is required");

    }
    
}