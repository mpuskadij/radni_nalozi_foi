using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class EmployeeRepository
    {
        public static Employee GetEmployee(int id)
        {
            Employee employee = null;
            string sql = $"SELECT * FROM Employees WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                employee = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return employee;
        }

        private  static Employee CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string contact = reader["Contact"].ToString();
            string address = reader["Address"].ToString();
            int role = int.Parse(reader["RoleId"].ToString());

            var employee = new Employee
            {
                Id = id,
                Name = name,
                Contact = contact,
                Address = address,
                Role = RoleRepository.GetRole(role),
            };

            return employee;
        }
    }
}
