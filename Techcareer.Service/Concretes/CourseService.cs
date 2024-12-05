using AutoMapper;
using Core.Responses;
using Core.Tokens.Services;
using Techcareer.DataAccess.Abstracts;
using Techcareer.Models.Dtos.Courses.Requests;
using Techcareer.Models.Dtos.Courses.Responses;
using Techcareer.Models.Entities;
using Techcareer.Service.Abstracts;
using Techcareer.Service.Rules;

namespace Techcareer.Service.Concretes;

public class CourseService(ICourseRepository _courseRepository, IMapper _mapper, CourseBusinessRules _businessRules) : ICourseService
{
  public async ValueTask<ReturnModel<CourseResponse>> AddAsync(CreateCourseRequest request)
  {
    await _businessRules.IsTitleUniqueAsync(request.Title);

    Course createdCourse = _mapper.Map<Course>(request);
    await _courseRepository.AddAsync(createdCourse);
    CourseResponse response = _mapper.Map<CourseResponse>(createdCourse);

    return new ReturnModel<CourseResponse>()
    {
      Success = true,
      Message = "Kurs eklendi.",
      Data = response,
      StatusCode = 201
    };
  }

  public async Task<ReturnModel<List<CourseResponse>>> GetAllAsync()
  {
    List<Course> courses = await _courseRepository.GetAllAsync();
    List<CourseResponse> responseList = _mapper.Map<List<CourseResponse>>(courses);

    return new ReturnModel<List<CourseResponse>>()
    {
      Success = true,
      Message = "Kurs listesi başarılı bir şekilde getirildi.",
      Data = responseList,
      StatusCode = 200
    };
  }

  public async ValueTask<ReturnModel<CourseResponse>> GetByIdAsync(int id)
  {
    await _businessRules.IsCourseExistAsync(id);

    Course? course = await _courseRepository.GetByIdAsync(id);
    CourseResponse response = _mapper.Map<CourseResponse>(course);

    return new ReturnModel<CourseResponse>()
    {
      Success = true,
      Message = $"{id} numaralı kurs başarılı bir şekilde getirildi.",
      Data = response,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<NoData>> RemoveAsync(int id)
  {
    await _businessRules.IsCourseExistAsync(id);

    Course course = await _courseRepository.GetByIdAsync(id);
    _courseRepository.Delete(course);

    return new ReturnModel<NoData>()
    {
      Success = true,
      Message = "Kurs silindi.",
      StatusCode = 204
    };
  }

  public async Task<ReturnModel<NoData>> UpdateAsync(UpdateCourseRequest request)
  {
    await _businessRules.IsCourseExistAsync(request.Id);

    Course existingCourse = await _courseRepository.GetByIdAsync(request.Id);

    existingCourse.Id = existingCourse.Id;
    existingCourse.Title = request.Title;
    existingCourse.Description = request.Description;
    existingCourse.Category = request.Category;
    existingCourse.Image = request.Image;
    existingCourse.Level = request.Level;
    existingCourse.Duration = request.Duration;
    existingCourse.HasCertificate = request.HasCertificate;

    _courseRepository.Update(existingCourse);

    return new ReturnModel<NoData>()
    {
      Success = true,
      Message = $"{request.Id} numaralı kurs güncellendi.",
      StatusCode = 204
    };
  }
}
