using Techcareer.Models.Dtos.Users.Requests;

namespace Techcareer.Service.Abstracts;

internal interface IRoleService
{
  Task<string> AddRoleToUser(AddRoleToUserRequest request);
  Task<List<string>> GetAllRolesByUserId(string userId);
  Task<string> AddRoleAsync(string name);
}
