using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class Status  : Type
    {
        public Status GetStatus()
        {
            Status status = null;
            status.Id = 1;
            status.Name = "Otvoren";

            return status;
        }
    }
}
