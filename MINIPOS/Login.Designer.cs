using System.Drawing;
using System.Windows.Forms;

namespace MINIPOS
{
    partial class Login
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.lblBadgeLetter = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblFeat1 = new System.Windows.Forms.Label();
            this.lblFeat2 = new System.Windows.Forms.Label();
            this.lblFeat3 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblUserCap = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassCap = new System.Windows.Forms.Label();
            this.pnlPass = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlBadge.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlLeft.Controls.Add(this.pnlBadge);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.lblBrandSub);
            this.pnlLeft.Controls.Add(this.lblFeat1);
            this.pnlLeft.Controls.Add(this.lblFeat2);
            this.pnlLeft.Controls.Add(this.lblFeat3);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(380, 500);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlLeft_Paint);
            this.pnlLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            // 
            // pnlBadge
            // 
            this.pnlBadge.BackColor = System.Drawing.Color.White;
            this.pnlBadge.Controls.Add(this.lblBadgeLetter);
            this.pnlBadge.Location = new System.Drawing.Point(48, 72);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Size = new System.Drawing.Size(60, 60);
            this.pnlBadge.TabIndex = 10;
            // 
            // lblBadgeLetter
            // 
            this.lblBadgeLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBadgeLetter.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblBadgeLetter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblBadgeLetter.Location = new System.Drawing.Point(0, 0);
            this.lblBadgeLetter.Name = "lblBadgeLetter";
            this.lblBadgeLetter.Size = new System.Drawing.Size(60, 60);
            this.lblBadgeLetter.TabIndex = 0;
            this.lblBadgeLetter.Text = "M";
            this.lblBadgeLetter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(44, 148);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(300, 50);
            this.lblBrand.TabIndex = 11;
            this.lblBrand.Text = "MINIPOS";
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.lblBrandSub.Location = new System.Drawing.Point(44, 202);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(310, 30);
            this.lblBrandSub.TabIndex = 12;
            this.lblBrandSub.Text = "Hệ thống quản lý bán hàng";
            // 
            // lblFeat1
            // 
            this.lblFeat1.BackColor = System.Drawing.Color.Transparent;
            this.lblFeat1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFeat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lblFeat1.Location = new System.Drawing.Point(44, 306);
            this.lblFeat1.Name = "lblFeat1";
            this.lblFeat1.Size = new System.Drawing.Size(310, 30);
            this.lblFeat1.TabIndex = 13;
            this.lblFeat1.Text = "✓   Bán hàng nhanh chóng";
            // 
            // lblFeat2
            // 
            this.lblFeat2.BackColor = System.Drawing.Color.Transparent;
            this.lblFeat2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFeat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lblFeat2.Location = new System.Drawing.Point(44, 342);
            this.lblFeat2.Name = "lblFeat2";
            this.lblFeat2.Size = new System.Drawing.Size(310, 30);
            this.lblFeat2.TabIndex = 14;
            this.lblFeat2.Text = "✓   Quản lý kho thông minh";
            // 
            // lblFeat3
            // 
            this.lblFeat3.BackColor = System.Drawing.Color.Transparent;
            this.lblFeat3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFeat3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lblFeat3.Location = new System.Drawing.Point(44, 378);
            this.lblFeat3.Name = "lblFeat3";
            this.lblFeat3.Size = new System.Drawing.Size(310, 30);
            this.lblFeat3.TabIndex = 15;
            this.lblFeat3.Text = "✓   Chăm sóc khách hàng thân thiết";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblMin);
            this.pnlRight.Controls.Add(this.lblClose);
            this.pnlRight.Controls.Add(this.lblHeading);
            this.pnlRight.Controls.Add(this.lblSub);
            this.pnlRight.Controls.Add(this.lblUserCap);
            this.pnlRight.Controls.Add(this.pnlUser);
            this.pnlRight.Controls.Add(this.lblPassCap);
            this.pnlRight.Controls.Add(this.pnlPass);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.lblFooter);
            this.pnlRight.Location = new System.Drawing.Point(380, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(480, 500);
            this.pnlRight.TabIndex = 1;
            this.pnlRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            // 
            // lblMin
            // 
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMin.Location = new System.Drawing.Point(404, 14);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(28, 28);
            this.lblMin.TabIndex = 20;
            this.lblMin.Text = "—";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.Click += new System.EventHandler(this.Min_Click);
            this.lblMin.MouseEnter += new System.EventHandler(this.Min_MouseEnter);
            this.lblMin.MouseLeave += new System.EventHandler(this.HeaderBtn_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClose.Location = new System.Drawing.Point(438, 14);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(28, 28);
            this.lblClose.TabIndex = 21;
            this.lblClose.Text = "✕";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.Close_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.Close_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.HeaderBtn_MouseLeave);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHeading.Location = new System.Drawing.Point(54, 74);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(230, 54);
            this.lblHeading.TabIndex = 2;
            this.lblHeading.Text = "Đăng nhập";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSub.Location = new System.Drawing.Point(57, 122);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(335, 23);
            this.lblSub.TabIndex = 3;
            this.lblSub.Text = "Chào mừng trở lại! Đăng nhập để tiếp tục.";
            // 
            // lblUserCap
            // 
            this.lblUserCap.AutoSize = true;
            this.lblUserCap.BackColor = System.Drawing.Color.Transparent;
            this.lblUserCap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblUserCap.Location = new System.Drawing.Point(56, 168);
            this.lblUserCap.Name = "lblUserCap";
            this.lblUserCap.Size = new System.Drawing.Size(123, 21);
            this.lblUserCap.TabIndex = 4;
            this.lblUserCap.Text = "Tên đăng nhập";
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));

            this.pnlUser.Controls.Add(this.txtUsername);
            this.pnlUser.Location = new System.Drawing.Point(56, 190);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(368, 46);
            this.pnlUser.TabIndex = 5;
            this.pnlUser.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlInput_Paint);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtUsername.Location = new System.Drawing.Point(16, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(336, 25);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.Input_FocusChanged);
            this.txtUsername.Leave += new System.EventHandler(this.Input_FocusChanged);
            // 
            // lblPassCap
            // 
            this.lblPassCap.AutoSize = true;
            this.lblPassCap.BackColor = System.Drawing.Color.Transparent;
            this.lblPassCap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPassCap.Location = new System.Drawing.Point(56, 250);
            this.lblPassCap.Name = "lblPassCap";
            this.lblPassCap.Size = new System.Drawing.Size(82, 21);
            this.lblPassCap.TabIndex = 6;
            this.lblPassCap.Text = "Mật khẩu";
            // 
            // pnlPass
            // 
            this.pnlPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));

            this.pnlPass.Controls.Add(this.txtPassword);
            this.pnlPass.Controls.Add(this.btnShowPass);
            this.pnlPass.Location = new System.Drawing.Point(56, 272);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(368, 46);
            this.pnlPass.TabIndex = 7;
            this.pnlPass.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlInput_Paint);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPassword.Location = new System.Drawing.Point(16, 13);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(280, 25);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.Input_FocusChanged);
            this.txtPassword.Leave += new System.EventHandler(this.Input_FocusChanged);
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPass.FlatAppearance.BorderSize = 0;
            this.btnShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPass.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnShowPass.Location = new System.Drawing.Point(302, 10);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(54, 26);
            this.btnShowPass.TabIndex = 3;
            this.btnShowPass.TabStop = false;
            this.btnShowPass.Text = "HIỆN";
            this.btnShowPass.UseVisualStyleBackColor = false;
            this.btnShowPass.Click += new System.EventHandler(this.BtnShowPass_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(56, 344);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(368, 50);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnLogin_Paint);
            this.btnLogin.MouseEnter += new System.EventHandler(this.BtnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.BtnLogin_MouseLeave);
            // 
            // lblFooter
            // 
            this.lblFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFooter.Location = new System.Drawing.Point(56, 414);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(368, 44);
            this.lblFooter.TabIndex = 8;
            this.lblFooter.Text = "Tài khoản demo: quanly / nhanvien1 — mật khẩu 123456";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.pnlLeft.ResumeLayout(false);
            this.pnlBadge.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBadge;
        private System.Windows.Forms.Label lblBadgeLetter;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblFeat1;
        private System.Windows.Forms.Label lblFeat2;
        private System.Windows.Forms.Label lblFeat3;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUserCap;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassCap;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblFooter;
    }
}
