using AutoMapper;
using Techcareer.Models.Dtos.Courses.Requests;
using Techcareer.Models.Dtos.Courses.Responses;
using Techcareer.Models.Dtos.Events.Requests;
using Techcareer.Models.Dtos.Events.Responses;
using Techcareer.Models.Entities;

namespace Techcareer.Service.Profiles;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<CreateEventRequest, Event>();
    CreateMap<UpdateEventRequest, Event>();
    CreateMap<Event, EventResponse>();

    CreateMap<CreateCourseRequest, Course>();
    CreateMap<UpdateCourseRequest, Course>();
    CreateMap<Course, CourseResponse>();
  }
}
