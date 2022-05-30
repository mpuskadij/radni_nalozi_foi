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


            if (workOrder != null)
            {
                workOrder.Id = int.Parse(txtId.Text);
                workOrder.Sample.Id = int.Parse(txtSampleId.Text);
                workOrder.SearchType.Id = int.Parse(cboTypeOfWorkSearch.SelectedValue.ToString());
                workOrder.Employee.Id = 1;
            }

            else
            {
                WorkOrder currentWorkOrder = new WorkOrder();
                currentWorkOrder.Sample = new Sample();
                currentWorkOrder.Employee = new Employee();
                currentWorkOrder.SearchType = new SearchType();
                currentWorkOrder.Status = new Status();

                currentWorkOrder.Id = int.Parse(txtId.Text);
                currentWorkOrder.Sample.Id = int.Parse(txtSampleId.Text);
                currentWorkOrder.SearchType.Id = int.Parse(cboTypeOfWorkSearch.SelectedValue.ToString());
                currentWorkOrder.Employee.Id = 1;
                currentWorkOrder.Status.InsertStatus();
                workOrder = currentWorkOrder;
            }

            Employee.PerformAction(workOrder);



            Close();
            
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
            cboTypeOfWorkSearch.DisplayMember = "Name";
            cboTypeOfWorkSearch.ValueMember = "Id";
            cboTypeOfWorkSearch.DataSource = searchTypes;
        }

        private void SetFormText()
        {
            Text = workOrder.Status.ToString();
        }
    }
}
