using Lab_Workflow_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class Employee : Person
    {
       public Role Role { get; set; }
       public override string ToString()
       {
           return this.Name;
       }

       public void PerformAction(int id)
        {
            var workOrder = WorkOrderRepository.GetWorkOrder(id);
            if (workOrder == null)
            {
                WorkOrderRepository.InsertWorkOrder(workOrder);
            }
            else
            {
                WorkOrderRepository.UpdateWorkOrder(workOrder);
            }
        }

    }
}
