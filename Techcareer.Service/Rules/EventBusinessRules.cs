using Core.Exceptions;
using Techcareer.DataAccess.Abstracts;

namespace Techcareer.Service.Rules;

public class EventBusinessRules(IEventRepository _eventRepository)
{
  public async Task IsEventExistAsync(int id)
  {
    var eventVariable = await _eventRepository.GetByIdAsync(id);

    if (eventVariable == null)
    {
      throw new NotFoundException($"{id} numaralı etkinlik bulunamadı.");
    }
  }

  public async Task IsTitleUnique(string title)
  {
    var eventVariable = await _eventRepository.GetByTitleAsync(title);

    if (eventVariable != null)
    {
      throw new BusinessException("Bu isim ile sistemimizde zaten bir etkinlik mevcut.");
    }
  }
}
