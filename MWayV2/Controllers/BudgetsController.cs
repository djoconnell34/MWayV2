#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWayV2.Data;
using MWayV2.Models;

namespace MWayV2.Controllers
{
    public class BudgetsController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=zMWayV2;Integrated Security=True");
        private readonly ApplicationDbContext _context;

        public BudgetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Budgets
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(await _context.budgets.Where(x => x.IdHolder == currentUserID).ToListAsync());
        }


        [HttpPost]
        public JsonResult AjaxBud(string a, string b, string c, string d, string e)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            Budget Input = new Budget
            {
                BudgetGroup = a,
                BudgetItemName = b,
                BudgetItemCost = Convert.ToDouble(c),
                MonthlyYearly = d,
                IdHolder = currentUserID,
            };

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into budgets (BudgetGroup, BudgetItemName, BudgetItemCost, MonthlyYearly, IdHolder ) values ('" + Input.BudgetGroup + "', '" + Input.BudgetItemName + "', '" + Input.BudgetItemCost + "', '" + Input.MonthlyYearly + "', '" + Input.IdHolder + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(Input);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetItemID,BudgetGroupId,BudgetGroup,BudgetItemName,BudgetItemCost,MonthlyYearly,IdHolder")] Budget budget)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            budget.IdHolder = currentUserID;

            if (ModelState.IsValid)
            {
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BudgetItemID,BudgetGroupId,BudgetGroup,BudgetItemName,BudgetItemCost,MonthlyYearly,IdHolder")] Budget budget)
        {
            if (id != budget.BudgetItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.BudgetItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.budgets
                .FirstOrDefaultAsync(m => m.BudgetItemID == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budget = await _context.budgets.FindAsync(id);
            _context.budgets.Remove(budget);
            await _context.SaveChangesAsync();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
            return _context.budgets.Any(e => e.BudgetItemID == id);
        }
    }
}
