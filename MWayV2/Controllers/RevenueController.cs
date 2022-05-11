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
    public class RevenueController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=zMWayV2;Integrated Security=True");
        private readonly ApplicationDbContext _context;

        public RevenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Revenue
        public async Task<IActionResult> Index()
        {
              return _context.revenue != null ? 
                          View(await _context.revenue.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.revenue'  is null.");
        }

        public async Task<IActionResult> test()
        {
            return _context.revenue != null ?
                        View(await _context.revenue.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.revenue'  is null.");
        }

        // GET: Revenue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.revenue
                .FirstOrDefaultAsync(m => m.RevenueId == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }


        [HttpPost]
        public JsonResult AjaxRev(string a, string b, string c)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            Revenue Input = new Revenue
            {
                IncomeName = a,
                Income = Convert.ToDouble(b),
                IncomeMonthlyYearly = c,
                IdHolder = currentUserID
            };

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into revenue (IncomeName, Income, IncomeMonthlyYearly, IdHolder ) values ('" + Input.IncomeName + "', '" + Input.Income + "', '" + Input.IncomeMonthlyYearly + "', '" + Input.IdHolder + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(Input);
        }







        // GET: Revenue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Revenue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RevenueId,IncomeName,Income,IncomeMonthlyYearly")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revenue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revenue);
        }

        // GET: Revenue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.revenue.FindAsync(id);
            if (revenue == null)
            {
                return NotFound();
            }
            return View(revenue);
        }

        // POST: Revenue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RevenueId,IncomeName,Income,IncomeMonthlyYearly")] Revenue revenue)
        {
            if (id != revenue.RevenueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revenue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevenueExists(revenue.RevenueId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(revenue);
        }

        // GET: Revenue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.revenue == null)
            {
                return NotFound();
            }

            var revenue = await _context.revenue
                .FirstOrDefaultAsync(m => m.RevenueId == id);
            if (revenue == null)
            {
                return NotFound();
            }

            return View(revenue);
        }

        // POST: Revenue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.revenue == null)
            {
                return Problem("Entity set 'ApplicationDbContext.revenue'  is null.");
            }
            var revenue = await _context.revenue.FindAsync(id);
            if (revenue != null)
            {
                _context.revenue.Remove(revenue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevenueExists(int id)
        {
          return (_context.revenue?.Any(e => e.RevenueId == id)).GetValueOrDefault();
        }
    }
}
