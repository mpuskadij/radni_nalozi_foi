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
        //Ova metoda je za pronalazak svih naloga koji odgovaraju unesenom broju na formi
        public static List<WorkOrder> GetWorkOrders(int id)
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();

            string sql = $"SELECT * FROM WorkOrders WHERE Id = {id}";
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

        //Pronađi 1 nalog i vrati ga
        public static WorkOrder GetWorkOrder(int id)
        {

            string sql = $"SELECT * FROM WorkOrders WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            WorkOrder workOrder = null;

            if (reader.HasRows)
            {
                reader.Read();
                workOrder = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();

            return workOrder;
        }

        //Dohvati sve naloge
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
                Date = DateTime.Parse(date),
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

        public static void DeleteWorkOrder(WorkOrder workOrder)
        {
            string sql = $"DELETE FROM WorkOrders WHERE Id = {workOrder.Id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void InsertWorkOrder(WorkOrder workOrder)
        {
            string sql = $"INSERT INTO WorkOrders (Id,Date,EmployeeId,StatusId,SearchTypeId,SampleId) VALUES({workOrder.Id}, GETDATE(),{workOrder.Employee.Id},{workOrder.Status.Id},{workOrder.SearchType.Id},{workOrder.Sample.Id})";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void UpdateWorkOrder(WorkOrder workOrder)
        {
            string sql = $"UPDATE WorkOrders SET Id = {workOrder.Id}, SearchTypeId = {workOrder.SearchType.Id}, SampleId = {workOrder.Sample.Id} WHERE Id = {workOrder.Id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

    }
}
