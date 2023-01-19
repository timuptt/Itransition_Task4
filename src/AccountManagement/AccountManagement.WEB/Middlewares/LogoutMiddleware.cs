using System.Security.Claims;
using AccountManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace AccountManagement.WEB.Middlewares;

public class LogoutMiddleware
{
    private readonly RequestDelegate _next;

    public LogoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, 
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            var userEmail = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await userManager.FindByEmailAsync(userEmail);
            if (user is not { LockoutEnd: null })
            {
                await signInManager.SignOutAsync();
                context.Response.Redirect("/Identity/Account/Login");
                return;
            }
        }

        await _next(context);
    }
}