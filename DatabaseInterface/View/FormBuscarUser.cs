﻿using System;
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

                if (DB.isThereAnyTempUser())
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
            object nifKey = DB.getKey(objectToEdit);
            DB.modifyObject(objectToEdit, DB.GetBindingList(), this, DB);
            //Sets the pointer correctly
            UpdateListBoxPointerByKey(objectToEdit);

        }

        private void UpdateListBoxPointerByKey(object SelectedItem)
        {
            if (SelectedItem != null)
            {
                object nifKey = DB.getKey(SelectedItem);
                int userIndex =
                    DB.GetBindingList().IndexOf(
                    DB.GetBindingList().FirstOrDefault(user => DB.getKey(user) == nifKey));
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


        private void buttonRevert_Click(object sender, EventArgs e)
        {
            object objectWithTempFlag = userPropertyGrid.SelectedObject;
            DB.revertSingleObject(objectWithTempFlag, DB.GetBindingList());
            UpdateListBoxPointerByKey(objectWithTempFlag);
            userListBox.DataSource = DB.GetBindingList();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            DB.PreventClosingWithUncommittedChanges(e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            object userWithTempFlag = (Empleado)userPropertyGrid.SelectedObject;
            DB.saveObject(userWithTempFlag);
            UpdateObjectView(this, e);

        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_SaveConfirm() == DialogResult.Yes)
            {
                DB.TurnTempIntoPermanent(DB.GetBindingList());
                UpdateListBoxPointerByKey((userListBox.SelectedItem));
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_RevertConfirm() == DialogResult.Yes)
            {
                DB.restoreFromBackupAndEmptyBackup(DB.GetBindingList());
                UpdateListBoxPointerByKey(userListBox.SelectedItem);

            }
        }
    }
}
