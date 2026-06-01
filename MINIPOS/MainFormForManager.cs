using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MINIPOS
{
    public partial class MainFormForManager : Form
    {
        public MainFormForManager()
        {
            InitializeComponent();

            this.FormClosed += MainFormForManager_FormClosed;
        }

        private void MainFormForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            InventoryForManager frm = new InventoryForManager();

            frm.Show();

            this.Hide();
        }
    }
}
