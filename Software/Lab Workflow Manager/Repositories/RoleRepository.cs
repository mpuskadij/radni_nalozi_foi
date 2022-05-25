using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class RoleRepository
    {

        public static Role GetRole(int id)
        {
            Role role = null;
            string sql = $"SELECT * FROM Roles WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                role = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return role;
        }

        private static Role CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            var role = new Role
            {
                Id = id,
                Name = name
            };
            return role;
        }
    }
}
