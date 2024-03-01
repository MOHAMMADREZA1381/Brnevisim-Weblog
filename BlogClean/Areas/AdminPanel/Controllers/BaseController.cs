using BlogClean.HttpSecurity;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [PermissionChecker]
    public class BaseController : Controller
    {
    }
}
