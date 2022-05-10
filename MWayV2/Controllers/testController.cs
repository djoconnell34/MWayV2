using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MWayV2.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View();
        }
    }
}
