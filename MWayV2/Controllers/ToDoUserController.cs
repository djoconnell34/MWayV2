using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MWayV2.Data;
using MWayV2.Models;
using System.Data;

namespace MWayV2.Controllers
{
    public class ToDoUserController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=zMWayV2;Integrated Security=True");
        ApplicationDbContext _context;

        public ToDoUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.todo.ToListAsync());
        }


        [HttpPost]
        public JsonResult AjaxToDo(string a, string b)
        {
            ToDo todoInput = new ToDo
            {
                ToDoName = a,
                ToDoDescription = b,
                ToDoIsComplete = false
            };

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into todo (ToDoName, ToDoDescription, ToDoIsComplete) values ('" + todoInput.ToDoName + "', '" + todoInput.ToDoDescription + "', '" + todoInput.ToDoIsComplete + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(todoInput);
        }

        public IActionResult Edit()
        {
            return View();
        }








        //public IActionResult Edit(int id)
        //{
        //    var todoInput = _context.todo.Where(x => x.ToDoId == id).FirstOrDefault();
        //    return PartialView("_editToDo", todoInput);

        //}
        //[HttpPost]
        //public IActionResult Edit(ToDo toDo)
        //{
        //    _context.todo.Update(toDo);
        //    _context.SaveChanges();
        //    return PartialView("_editToDo", toDo);

        //}
    }
}
