using FluentValidation;
using Techcareer.Models.Dtos.Events.Requests;

namespace Techcareer.Service.Validations.Events;

public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
{
  public CreateEventRequestValidator()
  {
    RuleFor(e => e.Title).NotEmpty().WithMessage("Etkinlik başlığı boş bırakılamaz.")
      .Length(2, 50).WithMessage("Etkinlik başlığı minimum 2, maksimum 50 karakterli olmalıdır.");

    RuleFor(e => e.Description).NotEmpty().WithMessage("Description içeriği boş bırakılamaz.");

    RuleFor(e => e.Tag).IsInEnum().WithMessage("Geçerli bir Tag değeri girmelisiniz.");
  }
}
