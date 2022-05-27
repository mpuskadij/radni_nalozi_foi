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
        private WorkOrder workOrder;

        public FrmAddWorkOrder(WorkOrder selectedWorkOrder)
        {
            InitializeComponent();
            workOrder = selectedWorkOrder;
        }

        public FrmAddWorkOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            WorkOrder currentWorkOrder = null;
            currentWorkOrder.Id = int.Parse(txtId.Text);
            currentWorkOrder.SearchType = cboTypeOfWorkSearch.SelectedItem as SearchType;
            if (currentWorkOrder.Date == null) currentWorkOrder.InsertCurrentDate();
            currentWorkOrder.Status.InsertStatus();

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void FrmAddWorkOrder_Load(object sender, EventArgs e)
        {
            if(workOrder != null)
            {
                txtId.Text = workOrder.Id.ToString();
                txtSampleId.Text = workOrder.Sample.Id.ToString();
                SetFormText();
            }
            var searchTypes = SearchTypeRepository.GetSearchTypes();
            cboTypeOfWorkSearch.DataSource = searchTypes;
        }

        private void SetFormText()
        {
            Text = workOrder.Status.ToString();
        }
    }
}
