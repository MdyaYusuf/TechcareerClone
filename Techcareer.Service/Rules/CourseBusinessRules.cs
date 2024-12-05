using Core.Exceptions;
using Techcareer.DataAccess.Abstracts;

namespace Techcareer.Service.Rules;

public class CourseBusinessRules(ICourseRepository _courseRepository)
{
  public async Task IsCourseExistAsync(int id)
  {
    var course = await _courseRepository.GetByIdAsync(id);

    if (course == null)
    {
      throw new NotFoundException($"{id} numaralı yapılacak iş bulunamadı."); 
    }
  }

  public async Task IsTitleUniqueAsync(string title)
  {
    var course = await _courseRepository.GetByTitleAsync(title);

    if (course != null)
    {
      throw new BusinessException("Bu isim ile sistemimizde zaten bir kurs mevcut.");
    }
  }
}
