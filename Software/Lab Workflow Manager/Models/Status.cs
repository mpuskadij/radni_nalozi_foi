using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class Status  : Type
    {
        public void InsertStatus()
        {
            this.Id = 0;
            this.Name = "U radu";
            return;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
