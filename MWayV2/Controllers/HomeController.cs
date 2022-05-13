using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWayV2.Data;
using MWayV2.Models;
using System.Diagnostics;
using System.Security.Claims;


namespace MWayV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            
            if (currentUser.Identity.Name != null)
            {
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;


                var incomeYear = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Yearly").Sum(x => x.Income);
                incomeYear = incomeYear / 12;
                var incomeMonth = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Monthly").Sum(x => x.Income);
                var incomeTotal = incomeYear + incomeMonth;

                var budGroupCar = "Car";
                var dataCarYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
                dataCarYear = dataCarYear / 12;
                var dataCar = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
                var dataCarTotal = dataCarYear + dataCar;

                var budGroupHome = "Home";
                var dataHomeYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
                dataHomeYear = dataHomeYear / 12;
                var dataHome = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
                var dataHomeTotal = dataHomeYear + dataHome;

                var budGroupElectronics = "Electronics";
                var dataElectYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
                dataElectYear = dataElectYear / 12;
                var dataElect = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
                var dataElectTotal = dataElectYear + dataElect;

                var budGroupOther = "Other";
                var dataOtherYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
                dataOtherYear = dataOtherYear / 12;
                var dataOther = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
                var dataOtherTotal = dataOtherYear + dataOther;


                var total = dataCarTotal + dataHomeTotal + dataElectTotal + dataOtherTotal;

                ViewBag.dataCar1 = Math.Round((double)dataCarTotal, 2);
                ViewBag.dataHome1 = Math.Round((double)dataHomeTotal, 2);
                ViewBag.dataElect1 = Math.Round((double)dataElectTotal, 2);
                ViewBag.dataOther1 = Math.Round((double)dataOtherTotal, 2);
                ViewBag.total = Math.Round((double)total, 2);

                return View();
            }
            else
            {
                return Redirect("Identity/Account/Register");
            }

        }


        public ActionResult GetData()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var budGroupCar = "Car";
            var dataCar = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar).Sum(x => x.BudgetItemCost);


            var budGroupHome = "Home";
            var dataHome = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome).Sum(x => x.BudgetItemCost);


            var budGroupElectronics = "Electronics";
            var dataElectron = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics).Sum(x => x.BudgetItemCost);


            var budGroupOther = "Other";
            var dataOther = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther).Sum(x => x.BudgetItemCost);




            var incomeYear = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Yearly").Sum(x => x.Income);
            incomeYear = incomeYear / 12;
            var incomeMonth = _context.revenue.Where(x => x.IdHolder.Contains(currentUserID) && x.IncomeMonthlyYearly == "Monthly").Sum(x => x.Income);
            var incomeTotal = incomeYear + incomeMonth;

    
            var dataCarYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
            dataCarYear = dataCarYear / 12;
            var dataCar1 = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
            var dataCarTotal = dataCarYear + dataCar1;

            var dataHomeYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
            dataHomeYear = dataHomeYear / 12;
            var dataHome1 = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
            var dataHomeTotal = dataHomeYear + dataHome1;

            var dataElectYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
            dataElectYear = dataElectYear / 12;
            var dataElect = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
            var dataElectTotal = dataElectYear + dataElect;

       
            var dataOtherYear = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther && x.MonthlyYearly == "Yearly").Sum(x => x.BudgetItemCost);
            dataOtherYear = dataOtherYear / 12;
            var dataOther1 = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther && x.MonthlyYearly == "Monthly").Sum(x => x.BudgetItemCost);
            var dataOtherTotal = dataOtherYear + dataOther1;


            var total = dataCarTotal + dataHomeTotal + dataElectTotal + dataOtherTotal;



            percent obj = new percent();
            obj.car = (double)dataCarTotal;
            obj.home = (double)dataHomeTotal;
            obj.electron = (double)dataElectTotal;
            obj.other = (double)dataOtherTotal;

            return Json(obj);
        }
        public class percent
        {
            public double car { get; set; }
            public double home { get; set; }
            public double electron { get; set; }
            public double other { get; set; }
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
