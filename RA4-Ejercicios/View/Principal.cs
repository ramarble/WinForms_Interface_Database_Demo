using RA4_Ejercicios.Controller;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using RA4_Ejercicios.Model;
using RA4_Ejercicios.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = U_DB_C.getUserBindingList();
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.Columns[0].ToolTipText = "[*] = Temporary\n[ ] = Permanent";
            this.dataGridView1.Columns[0].CellTemplate.ToolTipText = "[*] = Temporary\n[ ] = Permanent";
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            this.dataGridView1.CellContentDoubleClick += startEdit;
            SUEC.UserSaved += U_DB_C.userReceived;
        }

        private void startEdit(object sender, EventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var senderr = sender as DataGridView;
            if (senderr.SelectedRows.Count > 0)
            {
                saveSelectedButton.Enabled = true;
                deleteSelectedButton.Enabled = true;
            } else
            {
                saveSelectedButton.Enabled = false;
                deleteSelectedButton.Enabled = false;
            }
        }

        private void addListToBindingList(List<User> sourceList, BindingList<User> bindingList)
        {
            foreach (User u in sourceList)
            {
                bindingList.Add(u);
            }
        }


        private void buttonCommit_Click(object sender, EventArgs e)
        {

            DialogResult = MessageBox.Show("Commit Changes? ", "Info", MessageBoxButtons.YesNo) ;
            if (DialogResult == DialogResult.Yes)
            {
                U_DB_C.saveChanges(U_DB_C.getUserList());
            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Revert Changes? ", "Info", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                U_DB_C.revertChanges(U_DB_C.getUserList());
            }
        }

        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                User u = row.DataBoundItem as User;
                u.setTempStatus(false);
            }
            U_DB_C.getUserBindingList().ResetBindings();
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                User u = row.DataBoundItem as User;
                U_DB_C.getUserBindingList().Remove(u);
            }
            U_DB_C.getUserBindingList().ResetBindings();

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCommit_Click(sender, e);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DetailedView = new DetailedView(U_DB_C.getUserBindingList(), this);
            DetailedView.ShowDialog(this);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newUserForm = new UserForm(this, false);
            newUserForm.ShowDialog(this);
        }

    }
}
