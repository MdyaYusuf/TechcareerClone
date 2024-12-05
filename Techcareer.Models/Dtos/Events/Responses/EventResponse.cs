using Techcareer.Models.Enums;

namespace Techcareer.Models.Dtos.Events.Responses;

public sealed record EventResponse
{
  public string Title { get; init; } = default!;
  public string Description { get; init; } = default!;
  public Tag Tag { get; init; } = default!;
  public DateTime Deadline { get; init; }
}
