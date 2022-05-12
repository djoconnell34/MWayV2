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

                var budGroupCar = "Car";
                var dataCar = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar).Sum(x => x.BudgetItemCost);
                var dataCarDiv = dataCar / 12;

                var budGroupHome = "Home";
                var dataHome = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome).Sum(x => x.BudgetItemCost);
                var dataHomeDiv = dataHome / 12;

                var budGroupElectronics = "Electronics";
                var dataElect = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics).Sum(x => x.BudgetItemCost);
                var dataElectDiv = dataElect / 12;

                var budGroupOther = "Other";
                var dataOther = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther).Sum(x => x.BudgetItemCost);
                var dataOtherDiv = dataOther / 12;

                var total = dataCarDiv + dataHomeDiv + dataElectDiv + dataOtherDiv;

                ViewBag.dataCar1 = Math.Round((double)dataCarDiv, 2);
                ViewBag.dataHome1 = Math.Round((double)dataHomeDiv, 2);
                ViewBag.dataElect1 = Math.Round((double)dataElectDiv, 2);
                ViewBag.dataOther1 = Math.Round((double)dataOtherDiv, 2);
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

            percent obj = new percent();
            obj.car = (double)dataCar;
            obj.home = (double)dataHome;
            obj.electron = (double)dataElectron;
            obj.other = (double)dataOther;

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
