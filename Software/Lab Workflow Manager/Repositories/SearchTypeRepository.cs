using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class SearchTypeRepository
    {
        public static SearchType GetSearchType(int id)
        {
            SearchType searchType = null;
            string sql = $"SELECT * FROM SearchTypes WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                searchType = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return searchType;
        }

        private static SearchType CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string name = reader["Name"].ToString();

            var searchType = new SearchType
            {
                Id = id,
                Name = name

            };

            return searchType;
        }
    }
}
