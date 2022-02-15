using HelloPam.BLL;
using HelloPam.BO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmUserList : Form
    {
        private readonly UserBLO userBLO;
        public FrmUserList()
        {
            InitializeComponent();
            userBLO = new UserBLO();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadData(IEnumerable<User> users)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
            LbItemsCount.Text = $"{dataGridView1.Rows.Count} item(s)";
            dataGridView1.ClearSelection();
        }

        private void FrmUserList_Load(object sender, System.EventArgs e)
        {
            TxtSearch.Clear();
            LoadData(userBLO.FindUser());
        }

        private void TxtSearch_TextChanged(object sender, System.EventArgs e)
        {
            User user = new User { Username = TxtSearch.Text};
            var users1 = userBLO.FindUser(user);

            user = new User { Fullname = TxtSearch.Text };
            var users2 = userBLO.FindUser(user);

            LoadData(users1.Union(users2).ToList());
        }

        private void refreshToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
                TxtSearch.Clear();
            else
                LoadData(userBLO.FindUser());
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FrmUserEdit form = new FrmUserEdit(LoadData);
            form.Show();
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var user = dataGridView1.SelectedRows[0].DataBoundItem as User;
                FrmUserEdit form = new FrmUserEdit(LoadData, user);
                form.Show();
            }
        } 


        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex >= 0)
                {
                    if (dataGridView1.SelectedRows.Count == 1)
                        dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show
            (
                "Do you really want to delete this item(s) ?",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    var user = dataGridView1.SelectedRows[i].DataBoundItem as User;
                    userBLO.DeleteUser(user.Id);
                }

                LoadData(userBLO.FindUser());
            }
        }
    }
}
