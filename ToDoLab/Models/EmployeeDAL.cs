using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoLab.Models
{
    public class EmployeeDAL
    {
        //GetCrud
        public List<Employee> GetEmployees()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from employees";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(sql).ToList();
                connect.Close();

                return employees;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from employees where id =" + id;
                connect.Open();
                Employee employee = connect.Query<Employee>(sql).ToList().First();
                connect.Close();

                return employee;
            }
        }

        public void AddEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into employees values (0, '{e.Name}', {e.Hours}, '{e.Title}')";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void EditEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update employees" +
                    $"set Name= '{e.Name}', hours={e.Hours}, title='{e.Title}'" +
                    $"where id={e.Id};";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "delete from employees where id =" + id;
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }
    }
}
