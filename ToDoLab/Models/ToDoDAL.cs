using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoLab.Models
{
    public class ToDoDAL
    {
        public List<ToDo> GetTodo()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todos";
                connect.Open();
                List<ToDo> todos = connect.Query<ToDo>(sql).ToList();
                connect.Close();

                return todos;
            }
        }

        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todos where id =" + id;
                connect.Open();
                ToDo todos = connect.Query<ToDo>(sql).ToList().First();
                connect.Close();

                return todos;
            }
        }

        public void AddToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into todos values (0, '{t.Name}', '{t.Description}', null, {t.HoursNeeded}, {false})";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }



        public void AssignedTo(ToDo a)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update todos set assignedto = {a.AssignedTo} where todoid = {a.Id}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
    }
}
