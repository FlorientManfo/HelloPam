using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmHome : Form
    {
        private bool exitApp = true;
        private readonly User user;

        public FrmHome()
        {
            InitializeComponent();
            TsslDate.Text = DateTime.Now.ToString();
            TsslStatus.Text = "Ready";
            TsslUser.Text = string.Empty;
        }

        public FrmHome(User user):this()
        {
            this.user = user;
            TsslUser.Text = $"{user.Fullname} - {user.Profile}";
        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exitApp)
                Application.Exit();
        }

        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitApp)
            {
                var result = MessageBox.Show
                (
                    "Do you really want to close this app ?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin(user);
            form.Show();
            exitApp = false;
            this.Close();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserEdit frmUser = new FrmUserEdit();
            frmUser.MdiParent = this;
            frmUser.Show();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmUserList frmUser = new FrmUserList();
            frmUser.MdiParent = this;
            frmUser.Show();
        }
    }
}
