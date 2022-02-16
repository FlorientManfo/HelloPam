using HelloPam.BLL;
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
    public partial class FrmLogin : Form
    {
        private bool exitApp = true;
        private UserBLO userBLO;
        public FrmLogin()
        {
            InitializeComponent();
            userBLO = new UserBLO();
        }

        public FrmLogin(User user):this()
        {
            TxtUsername.Text = user.Username;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exitApp)
                Application.Exit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var user = userBLO.AuthenticateUser(TxtUsername.Text, TxtPassword.Text);
                FrmHome form = new FrmHome(user);
                form.Show();
            }
            catch(KeyNotFoundException ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show
                (
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            catch(Exception ex)
            {
                MessageBox.Show
                (
                    "An error occured. please try again later !",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.Error.WriteLine($"---> {ex.Message}");
            }
        }
    }
}
