﻿using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Techcareer.Models.Entities;

namespace Techcareer.Service.Rules;

public class UserBusinessRules(UserManager<User> _userManager)
{
  public async Task<User> EnsureUserExistAsync(string id)
  {
    var user = await _userManager.FindByIdAsync(id);

    if (user == null)
    {
      throw new NotFoundException("Kullanıcı bulunamadı.");
    }

    return user;
  }

  public async Task<User> EnsureUserExistByEmailAsync(string email)
  {
    var user = await _userManager.FindByIdAsync(email);

    if (user == null)
    {
      throw new NotFoundException("Kullanıcı bulunamadı.");
    }

    return user;
  }

  public void EnsurePasswordsMatch(string newPassword, string confirmNewPassword)
  {
    if (!newPassword.Equals(confirmNewPassword))
    {
      throw new BusinessException("Parolalar uyuşmuyor.");
    }
  }

  public async Task IsUsernameUniqueAsync(string username)
  {
    var existingUser = await _userManager.FindByIdAsync(username);

    if (existingUser != null)
    {
      throw new BusinessException($"{username} kullanıcı adı daha önceden alınmıştır.");
    }
  }
}
