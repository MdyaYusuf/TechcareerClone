using FluentValidation;
using Techcareer.Models.Dtos.Courses.Requests;

namespace Techcareer.Service.Validations.Courses;

public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>
{
  public CreateCourseRequestValidator()
  {
    RuleFor(c => c.Title).NotEmpty().WithMessage("Kurs başlığı boş bırakılamaz.")
      .Length(2, 50).WithMessage("Kurs başlığı minimum 2, maksimum 50 karakterli olmalıdır.");

    RuleFor(c => c.Description).NotEmpty().WithMessage("Description içeriği boş bırakılamaz.");

    RuleFor(c => c.Category).IsInEnum().WithMessage("Geçerli bir Category değeri girmelisiniz.");
  }
}
