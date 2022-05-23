using Lab_Workflow_Manager.Models;
using Lab_Workflow_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Workflow_Manager
{
    public partial class FrmAddWorkOrder : Form
    {
        public FrmAddWorkOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WorkOrder currentWorkOrder = null;
            currentWorkOrder.SearchType = cboTypeOfWorkSearch.SelectedItem as SearchType;
            currentWorkOrder.InsertCurrentDate();
            currentWorkOrder.Status.GetStatus();
        }
    }
}
