using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoLab.Models
{
    public class EmployeeTaskViewModel
    {
        //A view model is a model created specifically only to exist on views. They are used to show off multiple model classes at once
        //or to move small pieces of data from controller to the view
        public List<ToDo> ToDos { get; set; }
        public List<Employee> Employees { get; set; }

        public EmployeeTaskViewModel()
        {
            //We will use both our DALs to fill out this model
            ToDoDAL tdDal = new ToDoDAL();
            EmployeeDAL eDal = new EmployeeDAL();

            ToDos = tdDal.GetTodo();
            Employees = eDal.GetEmployees();
        }

    }
}
