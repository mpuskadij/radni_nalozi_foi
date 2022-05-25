using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class StatusRepository
    {

        public static Status GetStatus(int id)
        {
            Status status = null;
            string sql = $"SELECT * FROM Statuses WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                status = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return status;
        }

        private static Status CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();

            var status = new Status
            {
                Id = id,
                Name = name,
                
            };

            return status;
        }
    }
}
