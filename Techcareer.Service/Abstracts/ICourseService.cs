using Core.Responses;
using Techcareer.Models.Dtos.Courses.Responses;
using Techcareer.Models.Dtos.Courses.Requests;

namespace Techcareer.Service.Abstracts;

public interface ICourseService
{
  Task<ReturnModel<List<CourseResponse>>> GetAllAsync();
  ValueTask<ReturnModel<CourseResponse>> GetByIdAsync(int id);
  ValueTask<ReturnModel<CourseResponse>> AddAsync(CreateCourseRequest request);
  Task<ReturnModel<NoData>> UpdateAsync(UpdateCourseRequest request);
  Task<ReturnModel<NoData>> RemoveAsync(int id);
}
