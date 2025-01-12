using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using RA4_Ejercicios.View;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;

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
            U_DB_C.getUserBindingList().ListChanged += ReactToChangesToList;
            this.userDataGridView.SelectionChanged += ReactToChangesToList;
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Hardcoded, 
            this.userDataGridView.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void enableSaveAndRevertAllButtonsIfNeeded()
        {
            if (Utils.isThereAnyTempUser())
            {
                buttonRevertAll.Enabled = true;
                buttonSaveAll.Enabled = true;
            }
            else
            {
                buttonRevertAll.Enabled = false;
                buttonSaveAll.Enabled = false;
            }
        }

        //Enables or disables the buttons
        private void ReactToChangesToList(object sender, EventArgs e)
        {

            if (userDataGridView.SelectedRows.Count > 0)
            {
                //Always a possibility
                buttonDeleteSelected.Enabled = true;
                enableOrDisableModifyButton(userDataGridView);
                OneOrManySaveOrRevertButtons(userDataGridView);
            }
            else
            {
                buttonModify.Enabled = false;
                buttonDeleteSelected.Enabled = false;
                saveSelectedButton.Enabled = false;
                revertSelectedButton.Enabled = false;
            }
            enableSaveAndRevertAllButtonsIfNeeded();
        }

        private void enableOrDisableModifyButton(DataGridView dgvUsers)
        {
            if (dgvUsers.SelectedRows.Count == 1)
            {
                buttonModify.Enabled = true;
            }
            else
            {
                buttonModify.Enabled = false;
            }

        }

        private void OneOrManySaveOrRevertButtons(DataGridView dgvUsers)
        {
            //this is kinda very gorey

            Boolean exitCond = false;
            User us;
            for (int i = 0; i < dgvUsers.SelectedRows.Count; i++)
            {
                us = dgvUsers.SelectedRows[i].DataBoundItem as User;
                if (us.getTempStatus())
                {
                    exitCond = true;
                }
            }

            guardarToolStripMenuItem.Enabled = exitCond;
            saveSelectedButton.Enabled = exitCond;
            revertSelectedButton.Enabled = exitCond;

        }

        private void addListToBindingList(List<User> sourceList, BindingList<User> bindingList)
        {
            foreach (User u in sourceList)
            {
                bindingList.Add(u);
            }
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {

            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                U_DB_C.TurnTempUsersIntoPermanent(U_DB_C.getUserList());
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                U_DB_C.restoreAllUsersFromBackupAndEmptyBackup(U_DB_C.getUserList());
            }
        }


        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in userDataGridView.SelectedRows)
                {
                    User u = row.DataBoundItem as User;
                    U_DB_C.saveUser(u);
                }
                U_DB_C.getUserBindingList().ResetBindings();
            }
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            //TODO: Actually save the deletion and stuff for refetching
            if (DialogBoxes.DeleteConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in userDataGridView.SelectedRows)
                {
                    User u = row.DataBoundItem as User;
                    U_DB_C.getUserBindingList().Remove(u);
                }
                U_DB_C.getUserBindingList().ResetBindings();
            }
        }

        private void saveAll_Menu_Click(object sender, EventArgs e)
        {
            if (U_DB_C.getUsersBackupList().Count > 0)
            {
                buttonSaveAll_Click(sender, e);
            }
        }

        private void Search_Menu_Click(object sender, EventArgs e)
        {
            Form DetailedView = new FormBuscarUser(this);
            DetailedView.ShowDialog(this);
        }

        private void New_Menu_Click(object sender, EventArgs e)
        {
            Form newUserForm = new FormUser(this, false);
            newUserForm.ShowDialog(this);
        }

        private void Exit_Menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Print_Menu_Click(object sender, EventArgs e)
        {
            Form reportForm = new ReportForm(U_DB_C.getUserList());
            reportForm.ShowDialog();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userToEdit = (User)userDataGridView.SelectedRows[0].DataBoundItem;
            U_DB_C.modifyUser(userToEdit, U_DB_C.getUserBindingList(), this);
        }

        private void maximizarToolStrip_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void revertSelectedButton_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in userDataGridView.SelectedRows)
                {
                    User userToRevert = row.DataBoundItem as User;
                    U_DB_C.revertSingleUser(userToRevert, U_DB_C.getUserBindingList());
                }
            }
        }

        private void formPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.preventClosingWithUncommittedChanges(e);
        }
    }
}
