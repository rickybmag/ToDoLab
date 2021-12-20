using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoLab.Models;

namespace ToDoLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL db = new EmployeeDAL();
        ToDoDAL dbToDo = new ToDoDAL();
        public IActionResult Index()
        {
            EmployeeTaskViewModel e = new EmployeeTaskViewModel();
            return View(e);
        }

        public IActionResult Details(int id)
        {
            Employee e = db.GetEmployee(id);
            return View(e);
        }
        
        public IActionResult AddEmployee()
        {
            return View();                       
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            db.AddEmployee(e);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee e = db.GetEmployee(id);
            return View(e);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee e)
        {
            db.EditEmployee(e);
            return View(e);
        }

        public IActionResult RemoveEmployee(int id)
        {
            db.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
