using DBLayer;
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
            DB.SetConfiguration("mpuskadij20_DB", "mpuskadij20", "o@Rx0B7f");
            List<WorkOrder> workOrders = WorkOrderRepository.GetWorkOrders();
            foreach (WorkOrder workOrder in workOrders)
            {
                workOrder.Status.ToString();
                workOrder.Sample.ToString();
                workOrder.SearchType.ToString();
                workOrder.Employee.ToString();
            }
            dgvWorkOrders.DataSource = workOrders;
            
            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            WorkOrder selectedWorkOrder = dgvWorkOrders.CurrentRow.DataBoundItem as WorkOrder;
            if (selectedWorkOrder != null)
            {
                FrmAddWorkOrder frmAddWorkOrder = new FrmAddWorkOrder(selectedWorkOrder);
                frmAddWorkOrder.ShowDialog();
                

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddWorkOrder frmAddWorkOrder = new FrmAddWorkOrder();
            frmAddWorkOrder.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            WorkOrder workOrder = dgvWorkOrders.CurrentRow.DataBoundItem as WorkOrder;
            WorkOrderRepository.DeleteWorkOrder(workOrder);
            ShowWorkOrders();
        }

        private void txtSearchById_TextChanged(object sender, EventArgs e)
        {
            List<WorkOrder> workOrders;
            if (txtSearchById.Text == "") workOrders = WorkOrderRepository.GetWorkOrders();
            else workOrders = WorkOrderRepository.GetWorkOrders(int.Parse(txtSearchById.Text));
            dgvWorkOrders.DataSource = workOrders;
        }

        private void FrmWorkOrders_Activated(object sender, EventArgs e)
        {
            ShowWorkOrders();
        }
    }
}
