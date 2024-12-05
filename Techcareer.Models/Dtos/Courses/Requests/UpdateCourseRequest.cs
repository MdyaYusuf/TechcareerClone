using Techcareer.Models.Enums;

namespace Techcareer.Models.Dtos.Courses.Requests;

public record UpdateCourseRequest(int Id, string Title, string Description, Category Category, string Image, string Level, string Duration, bool HasCertificate);
