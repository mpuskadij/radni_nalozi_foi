using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class PatientRepository
    {
        public static Patient GetPatient(int id)
        {
            Patient patient = null;
            string sql = $"SELECT * FROM Patients WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                patient = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return patient;
        }

        private static Patient CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            string contact = reader["Contact"].ToString();
            string address = reader["Address"].ToString();

            var patient = new Patient
            {
                Id = id,
                Name = name,
                Contact = contact,
                Address = address
            };

            return patient;
        }
    }
}
