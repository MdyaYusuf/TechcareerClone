using Techcareer.Models.Dtos.Tokens.Responses;
using Techcareer.Models.Entities;

namespace Techcareer.Service.Abstracts;

public interface IJwtService
{
  Task<TokenResponse> CreateJwtTokenAsync(User user);
}
