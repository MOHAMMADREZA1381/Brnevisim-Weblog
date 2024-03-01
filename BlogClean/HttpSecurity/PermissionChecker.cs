using Application.Interfaces;
using BlogClean.ClaimsManager;
using Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogClean.HttpSecurity;

public  class PermissionChecker:AuthorizeAttribute,IAuthorizationFilter
{
    public async  void OnAuthorization(AuthorizationFilterContext context)
    {
        var userRepo = context.HttpContext.RequestServices.GetRequiredService<IUserService>();


        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            var userEmail = context.HttpContext.User.GetCurrentUserEmail();

            var user = await userRepo.GetUserEmail(userEmail);
            if (!user.IsAdmin)
            {
                context.Result = new RedirectResult("/");
            }
        }
        else
        {
            context.Result = new RedirectResult("/");
        }
    }
}