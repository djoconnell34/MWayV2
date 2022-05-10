using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWayV2.Data;
using MWayV2.Models;
using MWayV2.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MWayV2.ViewModels;

namespace MWayV2.Controllers
{
    public class BudgetController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-HPFIADMV;Initial Catalog=zMWayV2;Integrated Security=True");
        ApplicationDbContext _db;
        public BudgetController(ApplicationDbContext db)
        {
            _db = db;
        }



        
        

        public async Task<IActionResult> Index()
        {
            
            return View(await _db.budgets.ToListAsync());
        }

        //ApplicationUser applicationUser = _userManager.FindByIdAsync(user.Id);
       



        [HttpPost]
        public JsonResult AjaxBudget(string a, string b, string c, string d, string e)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;



            BudgetIDViewModel model = new BudgetIDViewModel();
            model.Budget = new Budget { BudgetGroupId = 1, BudgetGroup = "car", BudgetItemName = "tires", BudgetItemCost = 124, MonthlyYearly = "monthly" };
           

            

            Budget bud = new Budget
            {
                //UserId = 
                //BudgetGroupId = 1,
                BudgetGroup = a,
                BudgetItemName = b,
                BudgetItemCost = Convert.ToDouble(c),
                MonthlyYearly = d,
                IdHolder = currentUserID,
                ApplicationUser = currentUserID

        };
            
            

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into budgets (BudgetGroup, BudgetItemName, BudgetItemCost, MonthlyYearly, IDHolder, ApplicationUser)  " +
                "values ('" + bud.BudgetGroup + "' , '" + bud.BudgetItemName + "', '" + bud.BudgetItemCost + "', '" + bud.MonthlyYearly + "', '" + bud.IdHolder + "', '" + bud.ApplicationUser + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(bud);
        }
    }
}
