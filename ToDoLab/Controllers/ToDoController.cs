using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLab.Models;

namespace ToDoLab.Controllers
{
    public class ToDoController : Controller
    {
        ToDoDAL db = new ToDoDAL();
        EmployeeDAL eDb = new EmployeeDAL();

        public IActionResult Index()
        {
            List<ToDo> td = db.GetTodo();
            return View(td);
        }

        
        public IActionResult Create()
        {
            ToDo t = new ToDo();
            t.Employees = eDb.GetEmployees();
            return View(t);
        }

        [HttpPost]
        public IActionResult Create(ToDo t)
        {
            db.AddToDo(t);
            return RedirectToAction("Index");
        }

        public IActionResult AssignToDo()
        {
            EmployeeTaskViewModel em = new EmployeeTaskViewModel();
            return View(em);
        }

        [HttpPost]
        public IActionResult AssignToDo(int toDoId, int employeeId)
        {
            Assignment a = new Assignment();
            a.EmployeeId = employeeId;
            a.ToDoId = toDoId;
            AssignmentDAL ad = new AssignmentDAL();
            ad.CreateAssignment(a);
            return RedirectToAction("Index", "Employee");
        }
    }
}
