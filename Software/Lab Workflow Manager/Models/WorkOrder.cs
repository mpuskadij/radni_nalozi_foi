using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class WorkOrder
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public SearchType SearchType { get; set; }

        public Employee Employee { get; set; }

        public Sample Sample { get; set; }



    }
}
