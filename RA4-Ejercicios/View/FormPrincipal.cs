﻿using RA4_Ejercicios.Controller;
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

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            this.userDataGridView.DataSource = U_DB_C.getUserBindingList();
            SUEC.UserSaved += U_DB_C.userReceived;
            this.userDataGridView.AutoGenerateColumns = true;
            this.userDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDataGridView.Columns[0].ToolTipText = "[*] = Temporary\n[ ] = Permanent";
            this.userDataGridView.Columns[0].CellTemplate.ToolTipText = "[*] = Temporary\n[ ] = Permanent";
            this.userDataGridView.SelectionChanged += DataGridView1_SelectionChanged;
            this.userDataGridView.DataSourceChanged += EnableRevertButtonIfNeeded;
            this.userDataGridView.AllowUserToAddRows = false;
           

        }
        public formPrincipal()
        {
            InitializeComponent();

        }

        private void EnableRevertButtonIfNeeded(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }


        //Enables or disables the buttons
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            var senderr = sender as DataGridView;
            
            if (senderr.SelectedRows.Count > 0)
            {
                if (senderr.SelectedRows.Count==1)
                {
                    buttonModify.Enabled = true;
                }
                for (int i = 0; i < senderr.SelectedRows.Count; i++)
                {
                    var us = senderr.SelectedRows[i].DataBoundItem as User;
                        if (us.getTempStatus())
                    {
                        MessageBox.Show(us.getNif().ToString());
                        saveSelectedButton.Enabled = true;
                    }

                }
                
            } else
            {
                buttonModify.Enabled = false;
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
                U_DB_C.TurnTempUsersIntoPermanent(U_DB_C.getUserList());
            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Revert Changes? ", "Info", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                U_DB_C.RemoveTempUsers(U_DB_C.getUserList());
            }
        }

        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in userDataGridView.SelectedRows)
            {
                User u = row.DataBoundItem as User;
                u.setTempStatus(false);
            }
            U_DB_C.getUserBindingList().ResetBindings();
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in userDataGridView.SelectedRows)
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
            Form DetailedView = new FormBuscarUser(U_DB_C.getUserBindingList(), this);
            DetailedView.ShowDialog(this);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newUserForm = new FormUser(this, false);
            newUserForm.ShowDialog(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form reportForm = new ReportForm(U_DB_C.getUserList());
            reportForm.ShowDialog();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userToEdit = (User)userDataGridView.SelectedRows[0].DataBoundItem;
            MessageBox.Show(userToEdit.nif.ToString());
            int nifKey = userToEdit.nif;
            U_DB_C.getUsersBackupList().Add(userToEdit);
            U_DB_C.getUserList().Remove(userToEdit);

            //This form is the responsible for adding the new user to the list.
            FormUser f = new FormUser(this, userToEdit, true);
            this.Hide();
            f.ShowDialog();


            //In case the form exited abruptly
            if (U_DB_C.getUserList().Any(u => u.nif == userToEdit.nif))
            {
                U_DB_C.getUserList().Add(userToEdit);
                U_DB_C.getUsersBackupList().Remove(userToEdit);
                MessageBox.Show("Form exited without any changes");
            }
        }
    }
}
