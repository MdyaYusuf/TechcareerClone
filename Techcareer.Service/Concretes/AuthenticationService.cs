using Core.Responses;
using Techcareer.Models.Dtos.Tokens.Responses;
using Techcareer.Models.Dtos.Users.Requests;
using Techcareer.Service.Abstracts;

namespace Techcareer.Service.Concretes;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{
  public async Task<ReturnModel<TokenResponse>> LoginAsync(LoginRequest request)
  {
    var user = await _userService.LoginAsync(request);
    var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

    return new ReturnModel<TokenResponse>()
    {
      Success = true,
      Message = "Giriş başarılı.",
      Data = tokenResponse,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<TokenResponse>> RegisterAsync(RegisterRequest request)
  {
    var user = await _userService.RegisterAsync(request);
    var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

    return new ReturnModel<TokenResponse>()
    {
      Success = true,
      Message = "Üyelik oluşturuldu.",
      Data = tokenResponse,
      StatusCode = 200
    };
  }
}
