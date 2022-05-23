using DBLayer;
using Lab_Workflow_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Repositories
{
    public class WorkOrderRepository
    {

        public static List<WorkOrder> GetWorkOrders()
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();

            string sql = "SELECT * FROM WorkOrders";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            WorkOrder workOrder = null;

            while (reader.Read())
            {
                workOrder = CreateObject(reader);
                workOrders.Add(workOrder);
            }
            reader.Close();
            DB.CloseConnection();

            return workOrders;
            
        }

        private static WorkOrder CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            long id = long.Parse(reader["Id"].ToString());
            DateTime date = (DateTime)reader["DateTime"];
            SearchType searchType = (SearchType)reader["SearchType"];
            Employee employee = (Employee)reader["Employee"];
            Sample sample = (Sample)reader["Sample"];
            var workorder = new WorkOrder
            {
                Id = id,
                Date = date,
                SearchType = searchType,
                Employee = employee,
                Sample = sample
            };
            return workorder;


        }

        public bool CheckId()
        {

        }
    }
}
