namespace MINIPOS
{
    partial class FrmHoaDonNhap
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSuDung = new System.Windows.Forms.Button();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(643, 12);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.Size = new System.Drawing.Size(474, 549);
            this.dgvDetail.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(521, 166);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 50);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSuDung
            // 
            this.btnSuDung.Location = new System.Drawing.Point(521, 295);
            this.btnSuDung.Name = "btnSuDung";
            this.btnSuDung.Size = new System.Drawing.Size(111, 50);
            this.btnSuDung.TabIndex = 2;
            this.btnSuDung.Text = "Sử dụng";
            this.btnSuDung.UseVisualStyleBackColor = true;
            this.btnSuDung.Click += new System.EventHandler(this.btnSuDung_Click);
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Location = new System.Drawing.Point(12, 12);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(495, 549);
            this.dgvMaster.TabIndex = 3;
            this.dgvMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellClick);
            // 
            // FrmHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 573);
            this.Controls.Add(this.dgvMaster);
            this.Controls.Add(this.btnSuDung);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvDetail);
            this.Name = "FrmHoaDonNhap";
            this.Text = "FrmHoaDonNhap";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSuDung;
        private System.Windows.Forms.DataGridView dgvMaster;
    }
}