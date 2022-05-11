using Microsoft.AspNetCore.Mvc;
using MWayV2.Data;
using System.Security.Claims;

namespace MWayV2.Controllers
{
    public class testController : Controller
    {
        private readonly ApplicationDbContext _context;

        public testController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<ActionResult> Index()
        {
            

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (currentUser.Identity.Name != null)
            {
                var rev = _context.revenue.Where(x => x.IdHolder == currentUserID).Sum(x => x.Income);

                var cost = _context.budgets.Where(x => x.IdHolder == currentUserID).Sum(x => x.BudgetItemCost);

                percent2 obj2 = new percent2();
                obj2.revenue = (double)rev;
                obj2.cost = (double)cost;

                return View();
            }
            else
            {
                return Redirect("Identity/Account/Register");
            }

        }


        public ActionResult ChartData()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var rev = _context.revenue.Where(x => x.IdHolder == currentUserID).Sum(x => x.Income);

            var cost = _context.budgets.Where(x => x.IdHolder == currentUserID).Sum(x => x.BudgetItemCost);



            percent2 obj2 = new percent2();
            obj2.revenue = (double)rev;
            obj2.cost = (double)cost;

            return Json(obj2);
        }
        public class percent2
        {
            public double revenue { get; set; }
            public double cost { get; set; }

        }
    }
}
