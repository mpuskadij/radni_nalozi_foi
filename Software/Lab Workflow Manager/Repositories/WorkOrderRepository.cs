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
            int id = int.Parse(reader["Id"].ToString());
            string date = reader["Date"].ToString();
            int searchType = int.Parse(reader["SearchTypeId"].ToString());
            int employee = int.Parse(reader["EmployeeId"].ToString());
            int sample = int.Parse(reader["SampleId"].ToString());
            int status = int.Parse(reader["StatusId"].ToString());
            var workorder = new WorkOrder
            {
                Id = id,
                Date = date,
                SearchType = SearchTypeRepository.GetSearchType(searchType),
                Employee = EmployeeRepository.GetEmployee(employee),
                Sample = SampleRepository.GetSample(sample),
                Status = StatusRepository.GetStatus(status)
            };
            return workorder;


        }

        public bool CheckId(long id)
        {
            List<WorkOrder> workOrders = GetWorkOrders();

            foreach (WorkOrder workOrder in workOrders)
            {
                if (workOrder.Id == id)
                    return false;
            }
            return true;
        }

        public bool CheckSample(long Id)
        {
            List<WorkOrder> workOrders = GetWorkOrders();
            
            foreach(WorkOrder workOrder in workOrders)
            {
                if (workOrder.Sample.Id == Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
