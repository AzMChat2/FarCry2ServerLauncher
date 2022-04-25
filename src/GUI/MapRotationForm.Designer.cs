namespace GSL
{
	partial class MapRotationForm
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
			this.pbxMapImage = new System.Windows.Forms.PictureBox();
			this.lblMapInfo = new System.Windows.Forms.Label();
			this.cboMapTypeFilter = new System.Windows.Forms.ComboBox();
			this.tabMapRotation = new System.Windows.Forms.TabControl();
			this.tpgAvailableMaps = new System.Windows.Forms.TabPage();
			this.grdAvailableMaps = new System.Windows.Forms.DataGridView();
			this.Include = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.MapName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tpgSelectedMaps = new System.Windows.Forms.TabPage();
			this.lstSelectedMaps = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnBottom = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnTop = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).BeginInit();
			this.tabMapRotation.SuspendLayout();
			this.tpgAvailableMaps.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvailableMaps)).BeginInit();
			this.tpgSelectedMaps.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(507, 391);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(426, 391);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// pbxMapImage
			// 
			this.pbxMapImage.Location = new System.Drawing.Point(374, 35);
			this.pbxMapImage.Name = "pbxMapImage";
			this.pbxMapImage.Size = new System.Drawing.Size(208, 128);
			this.pbxMapImage.TabIndex = 7;
			this.pbxMapImage.TabStop = false;
			// 
			// lblMapInfo
			// 
			this.lblMapInfo.Location = new System.Drawing.Point(374, 166);
			this.lblMapInfo.Name = "lblMapInfo";
			this.lblMapInfo.Size = new System.Drawing.Size(208, 197);
			this.lblMapInfo.TabIndex = 8;
			// 
			// cboMapTypeFilter
			// 
			this.cboMapTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMapTypeFilter.FormattingEnabled = true;
			this.cboMapTypeFilter.Items.AddRange(new object[] {
            "Show Original Maps",
            "Show Custom Maps",
            "Show All Maps"});
			this.cboMapTypeFilter.Location = new System.Drawing.Point(374, 12);
			this.cboMapTypeFilter.Name = "cboMapTypeFilter";
			this.cboMapTypeFilter.Size = new System.Drawing.Size(205, 21);
			this.cboMapTypeFilter.TabIndex = 9;
			this.cboMapTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cboMapTypeFilter_SelectedIndexChanged);
			// 
			// tabMapRotation
			// 
			this.tabMapRotation.Controls.Add(this.tpgAvailableMaps);
			this.tabMapRotation.Controls.Add(this.tpgSelectedMaps);
			this.tabMapRotation.Location = new System.Drawing.Point(12, 12);
			this.tabMapRotation.Name = "tabMapRotation";
			this.tabMapRotation.SelectedIndex = 0;
			this.tabMapRotation.Size = new System.Drawing.Size(356, 402);
			this.tabMapRotation.TabIndex = 10;
			this.tabMapRotation.SelectedIndexChanged += new System.EventHandler(this.tabMapRotation_SelectedIndexChanged);
			// 
			// tpgAvailableMaps
			// 
			this.tpgAvailableMaps.Controls.Add(this.grdAvailableMaps);
			this.tpgAvailableMaps.Location = new System.Drawing.Point(4, 22);
			this.tpgAvailableMaps.Name = "tpgAvailableMaps";
			this.tpgAvailableMaps.Padding = new System.Windows.Forms.Padding(3);
			this.tpgAvailableMaps.Size = new System.Drawing.Size(348, 376);
			this.tpgAvailableMaps.TabIndex = 0;
			this.tpgAvailableMaps.Text = "Available Maps";
			this.tpgAvailableMaps.UseVisualStyleBackColor = true;
			// 
			// grdAvailableMaps
			// 
			this.grdAvailableMaps.AllowUserToAddRows = false;
			this.grdAvailableMaps.AllowUserToDeleteRows = false;
			this.grdAvailableMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAvailableMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Include,
            this.MapName,
            this.Category});
			this.grdAvailableMaps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAvailableMaps.Location = new System.Drawing.Point(3, 3);
			this.grdAvailableMaps.Name = "grdAvailableMaps";
			this.grdAvailableMaps.RowHeadersVisible = false;
			this.grdAvailableMaps.RowHeadersWidth = 20;
			this.grdAvailableMaps.Size = new System.Drawing.Size(342, 370);
			this.grdAvailableMaps.TabIndex = 6;
			this.grdAvailableMaps.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAvailableMaps_RowEnter);
			// 
			// Include
			// 
			this.Include.DataPropertyName = "Include";
			this.Include.HeaderText = "";
			this.Include.Name = "Include";
			this.Include.Width = 20;
			// 
			// MapName
			// 
			this.MapName.DataPropertyName = "Name";
			this.MapName.HeaderText = "Name";
			this.MapName.Name = "MapName";
			this.MapName.ReadOnly = true;
			this.MapName.Width = 150;
			// 
			// Category
			// 
			this.Category.DataPropertyName = "Category";
			this.Category.HeaderText = "Category";
			this.Category.Name = "Category";
			this.Category.ReadOnly = true;
			this.Category.Width = 150;
			// 
			// tpgSelectedMaps
			// 
			this.tpgSelectedMaps.Controls.Add(this.lstSelectedMaps);
			this.tpgSelectedMaps.Controls.Add(this.panel1);
			this.tpgSelectedMaps.Location = new System.Drawing.Point(4, 22);
			this.tpgSelectedMaps.Name = "tpgSelectedMaps";
			this.tpgSelectedMaps.Padding = new System.Windows.Forms.Padding(3);
			this.tpgSelectedMaps.Size = new System.Drawing.Size(348, 376);
			this.tpgSelectedMaps.TabIndex = 1;
			this.tpgSelectedMaps.Text = "Selected Maps";
			this.tpgSelectedMaps.UseVisualStyleBackColor = true;
			// 
			// lstSelectedMaps
			// 
			this.lstSelectedMaps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstSelectedMaps.FormattingEnabled = true;
			this.lstSelectedMaps.Location = new System.Drawing.Point(3, 3);
			this.lstSelectedMaps.Name = "lstSelectedMaps";
			this.lstSelectedMaps.Size = new System.Drawing.Size(228, 368);
			this.lstSelectedMaps.TabIndex = 1;
			this.lstSelectedMaps.SelectedIndexChanged += new System.EventHandler(this.lstSelectedMaps_SelectedIndexChanged);
			this.lstSelectedMaps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSelectedMaps_KeyDown);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnRemove);
			this.panel1.Controls.Add(this.btnBottom);
			this.panel1.Controls.Add(this.btnDown);
			this.panel1.Controls.Add(this.btnUp);
			this.panel1.Controls.Add(this.btnTop);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(231, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(114, 370);
			this.panel1.TabIndex = 0;
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(15, 187);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(88, 29);
			this.btnRemove.TabIndex = 4;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnBottom
			// 
			this.btnBottom.Location = new System.Drawing.Point(15, 118);
			this.btnBottom.Name = "btnBottom";
			this.btnBottom.Size = new System.Drawing.Size(88, 38);
			this.btnBottom.TabIndex = 3;
			this.btnBottom.Text = "Move to &Bottom";
			this.btnBottom.UseVisualStyleBackColor = true;
			this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(15, 83);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(88, 29);
			this.btnDown.TabIndex = 2;
			this.btnDown.Text = "Move &Down";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(15, 48);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(88, 29);
			this.btnUp.TabIndex = 1;
			this.btnUp.Text = "Move &Up";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnTop
			// 
			this.btnTop.Location = new System.Drawing.Point(15, 13);
			this.btnTop.Name = "btnTop";
			this.btnTop.Size = new System.Drawing.Size(88, 29);
			this.btnTop.TabIndex = 0;
			this.btnTop.Text = "Move to &Top";
			this.btnTop.UseVisualStyleBackColor = true;
			this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
			// 
			// MapRotationForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(594, 426);
			this.ControlBox = false;
			this.Controls.Add(this.tabMapRotation);
			this.Controls.Add(this.cboMapTypeFilter);
			this.Controls.Add(this.lblMapInfo);
			this.Controls.Add(this.pbxMapImage);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MapRotationForm";
			this.ShowInTaskbar = false;
			this.Text = "Edit Map Rotation";
			((System.ComponentModel.ISupportInitialize)(this.pbxMapImage)).EndInit();
			this.tabMapRotation.ResumeLayout(false);
			this.tpgAvailableMaps.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdAvailableMaps)).EndInit();
			this.tpgSelectedMaps.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.PictureBox pbxMapImage;
		private System.Windows.Forms.Label lblMapInfo;
		private System.Windows.Forms.ComboBox cboMapTypeFilter;
		private System.Windows.Forms.TabControl tabMapRotation;
		private System.Windows.Forms.TabPage tpgAvailableMaps;
		private System.Windows.Forms.DataGridView grdAvailableMaps;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Include;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Category;
		private System.Windows.Forms.TabPage tpgSelectedMaps;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox lstSelectedMaps;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnBottom;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnTop;
	}
}