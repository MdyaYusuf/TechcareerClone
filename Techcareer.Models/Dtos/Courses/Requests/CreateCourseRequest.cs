using Techcareer.Models.Enums;

namespace Techcareer.Models.Dtos.Courses.Requests;

public record CreateCourseRequest(string Title, string Instructor, string Description, Category Category, string Image, string Level, string Duration, bool HasCertificate);
