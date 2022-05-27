namespace Lab_Workflow_Manager
{
    partial class FrmWorkOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvWorkOrders = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkOrders
            // 
            this.dgvWorkOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrders.Location = new System.Drawing.Point(39, 31);
            this.dgvWorkOrders.Name = "dgvWorkOrders";
            this.dgvWorkOrders.Size = new System.Drawing.Size(711, 326);
            this.dgvWorkOrders.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 380);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 52);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Izbriši nalog";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(613, 380);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 52);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(335, 380);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(137, 52);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Promijeni nalog";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // FrmWorkOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvWorkOrders);
            this.Name = "FrmWorkOrders";
            this.Text = "Pregled radnih naloga";
            this.Load += new System.EventHandler(this.FrmWorkOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkOrders;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChange;
    }
}