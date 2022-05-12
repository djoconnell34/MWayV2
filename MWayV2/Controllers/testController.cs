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

                var incomeYear = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Yearly").Sum(x => x.Income);
                incomeYear = incomeYear / 12;
                var incomeMonth = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Monthly").Sum(x => x.Income);
                var incomeTotal = incomeYear + incomeMonth;

                var expYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
                expYear = expYear / 12;
                var expMonth = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
                var expTotal = expYear + expMonth;



                var revTotal = incomeTotal - expTotal;
                ViewBag.IncomeTotal = Math.Round((double)incomeTotal, 2);
                ViewBag.ExpTotal = Math.Round((double)expTotal, 2);
                ViewBag.RevTotal = Math.Round((double)revTotal, 2);

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

            var incomeYear = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Yearly").Sum(x => x.Income);
            incomeYear = incomeYear / 12;
            var incomeMonth = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Monthly").Sum(x => x.Income);
            var incomeTotal = incomeYear + incomeMonth;

            var expYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
            expYear = expYear / 12;
            var expMonth = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
            var expTotal = expYear + expMonth;

            var total = incomeTotal - expTotal;

            percent2 obj2 = new percent2();
            obj2.revenue1 = (double)total;
            obj2.cost1 = (double)expTotal;

            return Json(obj2);
        }
        public class percent2
        {
            public double revenue1 { get; set; }
            public double cost1 { get; set; }

        }
    }
}
