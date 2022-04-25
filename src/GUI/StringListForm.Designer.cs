namespace GSL
{
	partial class StringListForm
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.grdList = new System.Windows.Forms.DataGridView();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblInstructions = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(307, 339);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(226, 339);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grdList);
			this.panel1.Controls.Add(this.lblInstructions);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 322);
			this.panel1.TabIndex = 0;
			// 
			// grdList
			// 
			this.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value});
			this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdList.Location = new System.Drawing.Point(0, 13);
			this.grdList.Name = "grdList";
			this.grdList.RowHeadersWidth = 25;
			this.grdList.Size = new System.Drawing.Size(370, 309);
			this.grdList.TabIndex = 1;
			// 
			// Value
			// 
			this.Value.DataPropertyName = "Value";
			this.Value.HeaderText = "Column1";
			this.Value.MaxInputLength = 40;
			this.Value.Name = "Value";
			this.Value.Width = 325;
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblInstructions.Location = new System.Drawing.Point(0, 0);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(35, 13);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "label1";
			// 
			// StringListForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(394, 374);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "StringListForm";
			this.ShowInTaskbar = false;
			this.Text = "StringListForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView grdList;
		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
	}
}