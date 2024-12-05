using Techcareer.Models.Enums;

namespace Techcareer.Models.Dtos.Events.Requests;

public sealed record CreateEventRequest(string Title, string Description, Tag Tag, string Image, DateTime Deadline);
