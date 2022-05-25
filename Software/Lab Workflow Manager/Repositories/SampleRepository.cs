using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class SampleRepository
    {
        public static Sample GetSample(int id)
        {
            Sample sample = null;
            string sql = $"SELECT * FROM Samples WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                sample = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return sample;
        }

        private static Sample CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            int patientId = int.Parse(reader["PatientId"].ToString());
            int sampleTypeId = int.Parse(reader["SampleTypeId"].ToString());
            string amount = reader["Amount"].ToString();

            var sample = new Sample
            {
                Id = id,
                Patient = PatientRepository.GetPatient(patientId),
                SampleType = SampleTypeRepository.GetSampleType(sampleTypeId),
                Amount = amount,
            };

            return sample;
        }
    }
}
