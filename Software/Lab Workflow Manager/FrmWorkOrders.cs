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
    public partial class FrmWorkOrders : Form
    {
        public FrmWorkOrders()
        {
            InitializeComponent();
        }

        private void FrmWorkOrders_Load(object sender, EventArgs e)
        {
            ShowWorkOrders();
        }

        private void ShowWorkOrders()
        {
            List<WorkOrder> workOrders = WorkOrderRepository.GetWorkOrders();
            dgvWorkOrders.DataSource = workOrders;
        }
    }
}
