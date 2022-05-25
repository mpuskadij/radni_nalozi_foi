using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class SampleTypeRepository
    {
        public static SampleType GetSampleType(int id)
        {
            SampleType sampleType = null;
            string sql = $"SELECT * FROM SampleTypes WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                sampleType = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return sampleType;
        }

        private static SampleType CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();
            var sampleType = new SampleType
            {
                Id = id,
                Name = name
            };

            return sampleType;
        }
    }
}
