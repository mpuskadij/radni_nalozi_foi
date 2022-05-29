using Lab_Workflow_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public SearchType SearchType { get; set; }

        public Employee Employee { get; set; }

        public Sample Sample { get; set; }

        public Status Status { get; set; }

        public string GetCurrentDate()
        {
            return DateTime.Now.ToString("dd-M-yyyy H:m");
        }

        public void PerformSQL()
        {
            var workOrder = WorkOrderRepository.GetWorkOrders();
        }
    }
}
