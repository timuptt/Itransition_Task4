using System.Diagnostics;
using AccountManagement.WEB.Constants;
using AccountManagement.WEB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AccountManagement.WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace AccountManagement.WEB.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAccountService _accountService;
    

    public HomeController(ILogger<HomeController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _accountService.GetAllUsers();
        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteUserAction(List<ApplicationUserViewModel> users, UserAction userAction)
    {
        var selectedUsers = users
            .Where(u => u.IsSelected)
            .Select(u => u.Id);

        switch (userAction)
        {
            case UserAction.Delete:
                await _accountService.DeleteUsersAsync(selectedUsers);
                break;
            case UserAction.Lock:
                await _accountService.LockUsersAsync(selectedUsers);
                break;
            case UserAction.Unlock:
                await _accountService.UnlockUsersAsync(selectedUsers);
                break;
        }

        return RedirectToAction("Index");
    }
}