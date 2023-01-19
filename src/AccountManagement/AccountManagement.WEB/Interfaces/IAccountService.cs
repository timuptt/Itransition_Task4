using AccountManagement.WEB.Models;

namespace AccountManagement.WEB.Interfaces;

public interface IAccountService
{
    public Task<List<ApplicationUserViewModel>> GetAllUsers();
    
    public Task LockUsersAsync(IEnumerable<string> userIds);
    
    public Task UnlockUsersAsync(IEnumerable<string> userIds);
    
    public Task DeleteUsersAsync(IEnumerable<string> userIds);
}