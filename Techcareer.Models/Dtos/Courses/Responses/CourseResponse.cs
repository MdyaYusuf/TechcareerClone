using Techcareer.Models.Enums;

namespace Techcareer.Models.Dtos.Courses.Responses;

public sealed record CourseResponse
{
  public string Title { get; init; } = default!;
  public string Instructor { get; init; } = default!;
  public string Description { get; init; } = default!;
  public Category Category { get; init; } = default!;
  public string Level { get; init; } = default!;
  public string Duration { get; init; } = default!;
  public bool HasCertificate { get; init; }
}
