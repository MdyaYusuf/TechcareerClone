using Core.Responses;
using Techcareer.Models.Dtos.Tokens.Responses;
using Techcareer.Models.Dtos.Users.Requests;

namespace Techcareer.Service.Abstracts;

public interface IAuthenticationService
{
  Task<ReturnModel<TokenResponse>> LoginAsync(LoginRequest request);
  Task<ReturnModel<TokenResponse>> RegisterAsync(RegisterRequest request);
}
