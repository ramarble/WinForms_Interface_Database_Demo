using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;

namespace RA4_Ejercicios.View
{
    public partial class FormBuscarUser : Form
    {
        //tempEditedUsers will store the users that
        //have been edited in the case they need to be fetched back

        Form owner;
        public FormBuscarUser(Form sender)
        {
            InitializeComponent();

            this.owner = sender;
            sender.Visible = false;
        }

        private void FormBuscarUser_Load(object sender, EventArgs e)
        {
            userListBox.DataSource = U_DB_C.getUserBindingList();
            userListBox.ValueMember = "";
            userListBox.DisplayMember = "Name";
            userListBox.SelectedValueChanged += UpdateObjectView;
            U_DB_C.getUserBindingList().ListChanged += UpdateObjectView;


            if (U_DB_C.getUserBindingList().Count > 0)
            {
                userListBox.SetSelected(0, true);
            }
            else
            {
                buttonModify.Enabled = false;
            }

            userListBox.SelectionMode = SelectionMode.One;
            buttonRevert.Enabled = false;
            buttonSave.Enabled = false;
            userPropertyGrid.PropertySort = PropertySort.NoSort;
            userPropertyGrid.Enabled = false;
            tooltipTextBox.SetToolTip(this.filterFindUserTextBox, "Puedes encontrar un usuario por su NIF o nombre. (también lo he puesto aquí.))");
        }


        protected override void OnClosed(EventArgs e)
        {
            owner.Visible = true;
            //idk??
            //SUEC.UserSaved += userSent;
            base.OnClosed(e);
        }

        //Unsure as to what this was used for. Staying here in case I need it in the future.
        private void userSent(object sender, EventSendUser e)
        {
            U_DB_C.addUserToList(U_DB_C.getUserList(), e.getUsuario(), e.getEditMode());
        }


        //This updates the buttons whenever you change the object being viewed
        //So if a user is temp it can be reverted
        private void UpdateObjectView(object sender, EventArgs e)
        {
            userPropertyGrid.SelectedObject = userListBox.SelectedItem;

            if (userListBox.SelectedItems.Count > 0)
            {
                User u = userListBox.SelectedItem as User;
                if (u.getTempStatus())
                {
                    buttonRevert.Enabled = true;
                    buttonSave.Enabled = true;
                }
                else
                {
                    buttonRevert.Enabled = false;
                    buttonSave.Enabled = false;
                }

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
        }

        private void DynamicSearchBarUpdate(object sender, KeyEventArgs e)
        {
            List<User> lista = U_DB_C.getUserBindingList().Where(user => user.nif.ToString().Contains(filterFindUserTextBox.Text)).ToList();

            if (filterFindUserTextBox.Text != "")
            {
                lista.AddRange(
                U_DB_C.getUserBindingList().Where(
                    user => user.name.ToLower().Contains(filterFindUserTextBox.Text.ToLower())
                    )
                );
            }
            userListBox.DataSource = lista;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userToEdit = (User)userPropertyGrid.SelectedObject;
            int nifKey = userToEdit.nif;
            U_DB_C.modifyUser(userToEdit, U_DB_C.getUserBindingList(), this);
            //Sets the pointer correctly
            UpdateListBoxPointerByNIF(userToEdit);

        }

        private void UpdateListBoxPointerByNIF(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                int nifKey = (SelectedItem as User).nif;
                int userIndex =
                    U_DB_C.getUserBindingList().IndexOf(
                    U_DB_C.getUserBindingList().FirstOrDefault(user => user.nif == nifKey));
                if (userIndex != -1)
                {
                    userListBox.SetSelected(userIndex, true);
                }
                else
                {
                    userListBox.ClearSelected();
                }
            }
            U_DB_C.getUserBindingList().ResetBindings();
        }


        private void buttonRevert_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            U_DB_C.revertSingleUser(userWithTempFlag, U_DB_C.getUserBindingList());
            UpdateListBoxPointerByNIF(userWithTempFlag);
            userListBox.DataSource = U_DB_C.getUserBindingList();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Utils.preventClosingWithUncommittedChanges(e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            U_DB_C.saveUser(userWithTempFlag);
            UpdateObjectView(this, e);

        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                U_DB_C.TurnTempUsersIntoPermanent(U_DB_C.getUserList());
                UpdateListBoxPointerByNIF((userListBox.SelectedItem));
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                U_DB_C.restoreAllUsersFromBackupAndEmptyBackup(U_DB_C.getUserList());
                UpdateListBoxPointerByNIF(userListBox.SelectedItem);

            }
        }
    }
}
