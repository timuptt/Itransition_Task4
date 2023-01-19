using AccountManagement.Infrastructure.Identity;
using AccountManagement.WEB.Interfaces;
using AccountManagement.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.WEB.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<ApplicationUserViewModel>> GetAllUsers()
    {
        var users = await _userManager.Users.Select(u => 
            new ApplicationUserViewModel()
            {
                Id = u.Id,
                FullName = u.FullName,
                LastLoginDate = u.LastLoginDate,
                RegistrationDate = u.RegistrationDate,
                Status = u.Status,
                Email = u.Email
            })
            .ToListAsync();

        return users;
    }

    public async Task LockUsersAsync(IEnumerable<string>  userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(1000));
        }
    }

    public async Task UnlockUsersAsync(IEnumerable<string>  userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEndDateAsync(user, null);
        }
    }

    public async Task DeleteUsersAsync(IEnumerable<string> userIds)
    {
        foreach (var userId in userIds)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
        }
    }
}