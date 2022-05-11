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
            string test = Convert.ToString(currentUser);
            if (currentUser.Identity.Name != null)
            {


                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

                var budGroupCar = "Car";
                var dataCar = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupCar).Sum(x => x.BudgetItemCost);


                var budGroupHome = "Home";
                var dataHome = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupHome).Sum(x => x.BudgetItemCost);


                var budGroupElectronics = "Electronics";
                var dataElect = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupElectronics).Sum(x => x.BudgetItemCost);


                var budGroupOther = "Other";
                var dataOther = _context.budgets.Where(x => x.IdHolder.Contains(currentUserID) && x.BudgetGroup == budGroupOther).Sum(x => x.BudgetItemCost);

                return View(dataCar);
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


        public async Task<ActionResult> ToDo()
        {
            ToDo toDo = new ToDo();
            toDo.ToDoName = "test";
            toDo.ToDoDescription = "test";
            return View(toDo);
        }



        public ActionResult barChart()
        {
            return View();
        }


    }
}
