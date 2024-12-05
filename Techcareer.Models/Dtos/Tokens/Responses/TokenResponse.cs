namespace Techcareer.Models.Dtos.Tokens.Responses;

public sealed class TokenResponse
{
  public string AccessToken {  get; set; }
  public DateTime AccessTokenExpiration { get; set; }
}
