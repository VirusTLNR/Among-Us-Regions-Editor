
namespace AmongUsRegionsEditor
{
    partial class formAURE
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
            this.dgvCustomRegions = new System.Windows.Forms.DataGridView();
            this.lblWarning = new System.Windows.Forms.Label();
            this.dgvOfficialRegions = new System.Windows.Forms.DataGridView();
            this.gbOfficialRegions = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateRegion = new System.Windows.Forms.Button();
            this.gbCustomRegions = new System.Windows.Forms.GroupBox();
            this.lblNoCustomRegions = new System.Windows.Forms.Label();
            this.gbEditingArea = new System.Windows.Forms.GroupBox();
            this.chkDNS = new System.Windows.Forms.CheckBox();
            this.lblRecordToEdit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveDetails = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtRegionDisplayName = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFqdn = new System.Windows.Forms.Label();
            this.txtFqdn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficialRegions)).BeginInit();
            this.gbOfficialRegions.SuspendLayout();
            this.gbCustomRegions.SuspendLayout();
            this.gbEditingArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomRegions
            // 
            this.dgvCustomRegions.AllowUserToAddRows = false;
            this.dgvCustomRegions.AllowUserToDeleteRows = false;
            this.dgvCustomRegions.AllowUserToResizeColumns = false;
            this.dgvCustomRegions.AllowUserToResizeRows = false;
            this.dgvCustomRegions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCustomRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomRegions.Location = new System.Drawing.Point(6, 19);
            this.dgvCustomRegions.MultiSelect = false;
            this.dgvCustomRegions.Name = "dgvCustomRegions";
            this.dgvCustomRegions.ReadOnly = true;
            this.dgvCustomRegions.RowHeadersVisible = false;
            this.dgvCustomRegions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomRegions.RowTemplate.ReadOnly = true;
            this.dgvCustomRegions.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomRegions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCustomRegions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomRegions.ShowEditingIcon = false;
            this.dgvCustomRegions.Size = new System.Drawing.Size(688, 114);
            this.dgvCustomRegions.TabIndex = 0;
            this.dgvCustomRegions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegions_CellFormatting);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.SystemColors.Control;
            this.lblWarning.Location = new System.Drawing.Point(13, 13);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(690, 13);
            this.lblWarning.TabIndex = 2;
            this.lblWarning.Text = "This program currently only supports DNS Regions, Static Regions (like Impostor) " +
    "will be ignored, so when you click save, these maybe removed) ";
            // 
            // dgvOfficialRegions
            // 
            this.dgvOfficialRegions.AllowUserToAddRows = false;
            this.dgvOfficialRegions.AllowUserToDeleteRows = false;
            this.dgvOfficialRegions.AllowUserToResizeColumns = false;
            this.dgvOfficialRegions.AllowUserToResizeRows = false;
            this.dgvOfficialRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficialRegions.Enabled = false;
            this.dgvOfficialRegions.Location = new System.Drawing.Point(6, 19);
            this.dgvOfficialRegions.MultiSelect = false;
            this.dgvOfficialRegions.Name = "dgvOfficialRegions";
            this.dgvOfficialRegions.ReadOnly = true;
            this.dgvOfficialRegions.RowHeadersVisible = false;
            this.dgvOfficialRegions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOfficialRegions.RowTemplate.ReadOnly = true;
            this.dgvOfficialRegions.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOfficialRegions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOfficialRegions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficialRegions.Size = new System.Drawing.Size(402, 89);
            this.dgvOfficialRegions.TabIndex = 3;
            this.dgvOfficialRegions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegions_CellFormatting);
            // 
            // gbOfficialRegions
            // 
            this.gbOfficialRegions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOfficialRegions.BackColor = System.Drawing.SystemColors.Control;
            this.gbOfficialRegions.Controls.Add(this.dgvOfficialRegions);
            this.gbOfficialRegions.Controls.Add(this.btnSave);
            this.gbOfficialRegions.Controls.Add(this.btnCreateRegion);
            this.gbOfficialRegions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbOfficialRegions.Location = new System.Drawing.Point(6, 43);
            this.gbOfficialRegions.Name = "gbOfficialRegions";
            this.gbOfficialRegions.Size = new System.Drawing.Size(770, 169);
            this.gbOfficialRegions.TabIndex = 4;
            this.gbOfficialRegions.TabStop = false;
            this.gbOfficialRegions.Text = "Official Regions - Found in your regioninfo.json but not available for editing!";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(625, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save RegionInfo.json";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateRegion
            // 
            this.btnCreateRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateRegion.Location = new System.Drawing.Point(625, 45);
            this.btnCreateRegion.Name = "btnCreateRegion";
            this.btnCreateRegion.Size = new System.Drawing.Size(119, 23);
            this.btnCreateRegion.TabIndex = 7;
            this.btnCreateRegion.Text = "Create Region";
            this.btnCreateRegion.UseVisualStyleBackColor = true;
            this.btnCreateRegion.Click += new System.EventHandler(this.btnCreateRegion_Click);
            // 
            // gbCustomRegions
            // 
            this.gbCustomRegions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCustomRegions.BackColor = System.Drawing.SystemColors.Control;
            this.gbCustomRegions.Controls.Add(this.dgvCustomRegions);
            this.gbCustomRegions.Controls.Add(this.lblNoCustomRegions);
            this.gbCustomRegions.Location = new System.Drawing.Point(6, 247);
            this.gbCustomRegions.Name = "gbCustomRegions";
            this.gbCustomRegions.Size = new System.Drawing.Size(770, 202);
            this.gbCustomRegions.TabIndex = 5;
            this.gbCustomRegions.TabStop = false;
            this.gbCustomRegions.Text = "Custom Regions (you are ok to edit these, they are not official regions)";
            // 
            // lblNoCustomRegions
            // 
            this.lblNoCustomRegions.AutoSize = true;
            this.lblNoCustomRegions.Location = new System.Drawing.Point(9, 41);
            this.lblNoCustomRegions.Name = "lblNoCustomRegions";
            this.lblNoCustomRegions.Size = new System.Drawing.Size(249, 13);
            this.lblNoCustomRegions.TabIndex = 1;
            this.lblNoCustomRegions.Text = "There are no custom regions in this RegionInfo.json";
            // 
            // gbEditingArea
            // 
            this.gbEditingArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditingArea.BackColor = System.Drawing.SystemColors.Control;
            this.gbEditingArea.Controls.Add(this.chkDNS);
            this.gbEditingArea.Controls.Add(this.lblRecordToEdit);
            this.gbEditingArea.Controls.Add(this.label4);
            this.gbEditingArea.Controls.Add(this.label3);
            this.gbEditingArea.Controls.Add(this.label2);
            this.gbEditingArea.Controls.Add(this.label1);
            this.gbEditingArea.Controls.Add(this.btnSaveDetails);
            this.gbEditingArea.Controls.Add(this.btnCancel);
            this.gbEditingArea.Controls.Add(this.txtPort);
            this.gbEditingArea.Controls.Add(this.txtIPAddress);
            this.gbEditingArea.Controls.Add(this.txtRegionDisplayName);
            this.gbEditingArea.Controls.Add(this.lblPort);
            this.gbEditingArea.Controls.Add(this.lblIPAddress);
            this.gbEditingArea.Controls.Add(this.lblName);
            this.gbEditingArea.Controls.Add(this.lblFqdn);
            this.gbEditingArea.Controls.Add(this.txtFqdn);
            this.gbEditingArea.Location = new System.Drawing.Point(6, 461);
            this.gbEditingArea.Name = "gbEditingArea";
            this.gbEditingArea.Size = new System.Drawing.Size(770, 169);
            this.gbEditingArea.TabIndex = 6;
            this.gbEditingArea.TabStop = false;
            this.gbEditingArea.Text = "Add Region";
            this.gbEditingArea.Visible = false;
            // 
            // chkDNS
            // 
            this.chkDNS.AutoSize = true;
            this.chkDNS.Location = new System.Drawing.Point(42, 20);
            this.chkDNS.Name = "chkDNS";
            this.chkDNS.Size = new System.Drawing.Size(15, 14);
            this.chkDNS.TabIndex = 17;
            this.chkDNS.UseVisualStyleBackColor = true;
            this.chkDNS.CheckedChanged += new System.EventHandler(this.chkDNS_CheckedChanged);
            // 
            // lblRecordToEdit
            // 
            this.lblRecordToEdit.AutoSize = true;
            this.lblRecordToEdit.Location = new System.Drawing.Point(739, 19);
            this.lblRecordToEdit.Name = "lblRecordToEdit";
            this.lblRecordToEdit.Size = new System.Drawing.Size(16, 13);
            this.lblRecordToEdit.TabIndex = 16;
            this.lblRecordToEdit.Text = "-1";
            this.lblRecordToEdit.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(725, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Port - The server port you wish to connect to, the defaul is 22023, i would sugge" +
    "st you dont change this unless told to by the person who runs the server.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "IP Address - The IP of the server you wish to connect to.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(708, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name - this is the words you will see within among us to reference this region. M" +
    "ake it something recognisable so you know what region you selected.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "DNS - if your server has a DNS address, tick the box and enter the DNS Address";
            // 
            // btnSaveDetails
            // 
            this.btnSaveDetails.Location = new System.Drawing.Point(635, 15);
            this.btnSaveDetails.Name = "btnSaveDetails";
            this.btnSaveDetails.Size = new System.Drawing.Size(97, 23);
            this.btnSaveDetails.TabIndex = 98;
            this.btnSaveDetails.Text = "Save Details";
            this.btnSaveDetails.UseVisualStyleBackColor = true;
            this.btnSaveDetails.Click += new System.EventHandler(this.btnSaveDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(635, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 99;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(551, 36);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(57, 20);
            this.txtPort.TabIndex = 97;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(404, 36);
            this.txtIPAddress.MaxLength = 20;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(125, 20);
            this.txtIPAddress.TabIndex = 96;
            // 
            // txtRegionDisplayName
            // 
            this.txtRegionDisplayName.Location = new System.Drawing.Point(208, 36);
            this.txtRegionDisplayName.MaxLength = 10;
            this.txtRegionDisplayName.Name = "txtRegionDisplayName";
            this.txtRegionDisplayName.Size = new System.Drawing.Size(172, 20);
            this.txtRegionDisplayName.TabIndex = 95;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(548, 20);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(401, 20);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(58, 13);
            this.lblIPAddress.TabIndex = 5;
            this.lblIPAddress.Text = "IP Address";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(205, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblFqdn
            // 
            this.lblFqdn.AutoSize = true;
            this.lblFqdn.Location = new System.Drawing.Point(6, 20);
            this.lblFqdn.Name = "lblFqdn";
            this.lblFqdn.Size = new System.Drawing.Size(30, 13);
            this.lblFqdn.TabIndex = 1;
            this.lblFqdn.Text = "DNS";
            // 
            // txtFqdn
            // 
            this.txtFqdn.Enabled = false;
            this.txtFqdn.Location = new System.Drawing.Point(9, 36);
            this.txtFqdn.MaxLength = 100;
            this.txtFqdn.Name = "txtFqdn";
            this.txtFqdn.Size = new System.Drawing.Size(176, 20);
            this.txtFqdn.TabIndex = 94;
            // 
            // formAURE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(784, 642);
            this.Controls.Add(this.gbEditingArea);
            this.Controls.Add(this.gbCustomRegions);
            this.Controls.Add(this.gbOfficialRegions);
            this.Controls.Add(this.lblWarning);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "formAURE";
            this.Text = "Among Us Region Editor (for 2021-12-14 on PC) v0.1";
            this.Load += new System.EventHandler(this.formAURE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficialRegions)).EndInit();
            this.gbOfficialRegions.ResumeLayout(false);
            this.gbCustomRegions.ResumeLayout(false);
            this.gbCustomRegions.PerformLayout();
            this.gbEditingArea.ResumeLayout(false);
            this.gbEditingArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomRegions;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.DataGridView dgvOfficialRegions;
        private System.Windows.Forms.GroupBox gbOfficialRegions;
        private System.Windows.Forms.GroupBox gbCustomRegions;
        private System.Windows.Forms.GroupBox gbEditingArea;
        private System.Windows.Forms.TextBox txtFqdn;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRegionDisplayName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateRegion;
        private System.Windows.Forms.Button btnSaveDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordToEdit;
        private System.Windows.Forms.CheckBox chkDNS;
        private System.Windows.Forms.Label lblFqdn;
        private System.Windows.Forms.Label lblNoCustomRegions;
    }
}

