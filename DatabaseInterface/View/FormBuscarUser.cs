using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterface.Controller;
using DatabaseInterface.Model;
using Utils = DatabaseInterface.Controller;
using DataModel = DatabaseInterface.Model;

namespace DatabaseInterface.View
{
    public partial class FormBuscarUser : Form
    {
        //tempEditedUsers will store the users that
        //have been edited in the case they need to be fetched back

        Form owner;
        ObjectDataBaseController<object> db;
        
        public FormBuscarUser(Form sender, ObjectDataBaseController<object> db)
        {
            InitializeComponent();
            this.db = db;
            this.owner = sender;
            sender.Visible = false;
        }

        private void FormBuscarUser_Load(object sender, EventArgs e)
        {
            userListBox.DataSource = db.getBindingList();
            userListBox.ValueMember = "";
            userListBox.DisplayMember = "Name";
            userListBox.SelectedValueChanged += UpdateObjectView;
            db.getBindingList().ListChanged += UpdateObjectView;


            if (db.getBindingList().Count > 0)
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
        private void userSent(object sender, ObjectEvents<object> e)
        {
            db.addObjectToList(db.getObjectList(), e.getObject(), e.getEditMode());
        }


        //This updates the buttons whenever you change the object being viewed
        //So if a user is temp it can be reverted
        private void UpdateObjectView(object sender, EventArgs e)
        {
            userPropertyGrid.SelectedObject = userListBox.SelectedItem;

            if (userListBox.SelectedItems.Count > 0)
            {
                Empleado u = userListBox.SelectedItem as Empleado;
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

                if (db.isThereAnyTempUser())
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


        private void buttonModify_Click(object sender, EventArgs e)
        {
            object objectToEdit = userPropertyGrid.SelectedObject;
            object nifKey = db.getKey(objectToEdit);
            db.modifyObject(objectToEdit, db.getBindingList(), this, db);
            //Sets the pointer correctly
            UpdateListBoxPointerByKey(objectToEdit);

        }

        private void UpdateListBoxPointerByKey(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                object nifKey = db.getKey(SelectedItem);
                int userIndex =
                    db.getBindingList().IndexOf(
                    db.getBindingList().FirstOrDefault(user => db.getKey(user) == nifKey));
                if (userIndex != -1)
                {
                    userListBox.SetSelected(userIndex, true);
                }
                else
                {
                    userListBox.ClearSelected();
                }
            }
            db.getBindingList().ResetBindings();
        }


        private void buttonRevert_Click(object sender, EventArgs e)
        {
            object objectWithTempFlag = userPropertyGrid.SelectedObject;
            db.revertSingleObject(objectWithTempFlag, db.getBindingList());
            UpdateListBoxPointerByKey(objectWithTempFlag);
            userListBox.DataSource = db.getBindingList();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            db.preventClosingWithUncommittedChanges(e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            object userWithTempFlag = (Empleado)userPropertyGrid.SelectedObject;
            db.saveObject(userWithTempFlag);
            UpdateObjectView(this, e);

        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                db.TurnTempIntoPermanent(db.getObjectList());
                UpdateListBoxPointerByKey((userListBox.SelectedItem));
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                db.restoreFromBackupAndEmptyBackup(db.getObjectList());
                UpdateListBoxPointerByKey(userListBox.SelectedItem);

            }
        }
    }
}
