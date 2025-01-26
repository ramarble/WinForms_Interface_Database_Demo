using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using Utils = DatabaseInterfaceDemo.Controller;
using DataModel = DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.Data;

namespace DatabaseInterfaceDemo.View
{
    public partial class FormBuscarUser : Form
    {
        //tempEditedUsers will store the users that
        //have been edited in the case they need to be fetched back

        Form owner;
        ObjectDataBaseController<object> DB;
        
        public FormBuscarUser(Form sender, ObjectDataBaseController<object> db)
        {
            InitializeComponent();
            this.DB = db;
            this.owner = sender;
            sender.Visible = false;
        }

        private void FormBuscarUser_Load(object sender, EventArgs e)
        {
            userListBox.DataSource = DB.GetBindingList();
            userListBox.ValueMember = "";
            userListBox.DisplayMember = "Name";
            userListBox.SelectedValueChanged += UpdateObjectView;
            DB.GetBindingList().ListChanged += UpdateObjectView;


            if (DB.GetBindingList().Count > 0)
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


        //This updates the buttons whenever you change the object being viewed
        //So if a user is temp it can be reverted
        private void UpdateObjectView(object sender, EventArgs e)
        {
            userPropertyGrid.SelectedObject = userListBox.SelectedItem;

            if (userListBox.SelectedItems.Count > 0)
            {
                Empleado u = userListBox.SelectedItem as Empleado;
                if (u.GetTempStatus())
                {
                    buttonRevert.Enabled = true;
                    buttonSave.Enabled = true;
                }
                else
                {
                    buttonRevert.Enabled = false;
                    buttonSave.Enabled = false;
                }

                if (DB.IsThereAnyTempUser())
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

            /*
             * 
             * Too complex to fix atm
                List<Empleado> lista = db.getBindingList().Where(user => user.nif.ToString().Contains(filterFindUserTextBox.Text)).ToList();

                if (filterFindUserTextBox.Text != "")
                {
                    lista.AddRange(
                    db.getBindingList().Where(
                        user => user.name.ToLower().Contains(filterFindUserTextBox.Text.ToLower())
                        )
                    );
                }
                userListBox.DataSource = lista;
            
            */
        }


        private void ButtonModify_Click(object sender, EventArgs e)
        {
            object objectToEdit = userPropertyGrid.SelectedObject;
            object nifKey = DB.GetKey(objectToEdit);
            DB.ModifyObject(objectToEdit, this, DB);
            //Sets the pointer correctly
            UpdateListBoxPointerByKey(objectToEdit);

        }

        private void UpdateListBoxPointerByKey(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                object nifKey = DB.GetKey(SelectedItem);
                int userIndex =
                    DB.GetBindingList().IndexOf(
                    DB.GetBindingList().FirstOrDefault(user => DB.GetKey(user) == nifKey));
                if (userIndex != -1)
                {
                    userListBox.SetSelected(userIndex, true);
                }
                else
                {
                    userListBox.ClearSelected();
                }
            }
            DB.GetBindingList().ResetBindings();
        }


        private void ButtonRevert_Click(object sender, EventArgs e)
        {
            object objectWithTempFlag = userPropertyGrid.SelectedObject;
            DB.RevertSingleObject(objectWithTempFlag);
            UpdateListBoxPointerByKey(objectWithTempFlag);
            userListBox.DataSource = DB.GetBindingList();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            DB.PreventClosingWithUncommittedChanges(e);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            object userWithTempFlag = (Empleado)userPropertyGrid.SelectedObject;
            DB.SaveObject(userWithTempFlag);
            UpdateObjectView(this, e);

        }

        private void ButtonSaveAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_SaveConfirm() == DialogResult.Yes)
            {
                DB.TurnTempIntoPermanent(DB.GetBindingList());
                UpdateListBoxPointerByKey((userListBox.SelectedItem));
            }
        }

        private void ButtonRevertAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_RevertConfirm() == DialogResult.Yes)
            {
                DB.RestoreFromBackupAndEmptyBackup(DB.GetBindingList());
                UpdateListBoxPointerByKey(userListBox.SelectedItem);

            }
        }
    }
}
