﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using DatabaseInterfaceDemo.View;
using DatabaseInterface.Controller;
using DatabaseInterface.Model;
using DatabaseInterface.View;
using System.Collections.ObjectModel;
using System.Reflection;
using DataModel = DatabaseInterface.Model;
using DatabaseInterfaceDemo.Controller;


namespace DatabaseInterface
{
    public partial class formPrincipal : Form
    {

        static ObjectDataBaseController<object> db = new ObjectDataBaseController<object>(typeof(Empleado), "nif");

        private void formPrincipal_Load(object sender, EventArgs e)
        {

            initializeComboBox();                        
            
            db.setObjectBindingList(EmpleadoDebug.createEmpleadoList());
            db.turnIntoXMLFile(db.getBindingList().ToList<object>());
            db.getBindingList().ResetBindings();

            CustomXMLParser.test(new List<Empleado>());

            //initializeDataGridViewWithObject(db.getBindingList());
            db.getBindingList().ListChanged += ReactToChangesToList;

        }




        public void initializeDataGridView()
        {
            if (PrincipalDataGridView.DataSource != null)
            {
                PrincipalDataGridView.AutoGenerateColumns = true;
                PrincipalDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                PrincipalDataGridView.Columns[0].Width = 25;
                PrincipalDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                PrincipalDataGridView.Columns[0].ToolTipText = "[*] = Temporary\n[ ] = Permanent";
                PrincipalDataGridView.Columns[0].CellTemplate.ToolTipText = "[*] = Temporary\n[ ] = Permanent";
                PrincipalDataGridView.AllowUserToAddRows = false;
                PrincipalDataGridView.SelectionChanged += ReactToChangesToList;
                PrincipalDataGridView.DataSourceChanged += ReactToChangesToList;
                PrincipalDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //Doesn't work yet but what I want is that when the form changes visibility the buttons update
                VisibleChanged += ReactToChangesToList;


            }
         }

        
        //Enables or disables the buttons
        private void ReactToChangesToList(object sender, EventArgs e)
        {

            if (PrincipalDataGridView.SelectedRows.Count > 0)
            {
                //Always a possibility
                buttonDeleteSelected.Enabled = true;
                enableOrDisableModifyButton(PrincipalDataGridView);
                OneOrManySaveOrRevertButtons(PrincipalDataGridView);
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



        public void initializeDataGridViewWithObjects(BindingList<object> list)
        {
            this.PrincipalDataGridView.DataSource = list;

            if (list.Count > 0)
            {
                formatTableDateTime(list[0]);
            } else
            {
                throw new Exception("wow, empty table");
            }
            }




        //Checks the object of the list to see if it contains a DateTime, formats it accordingly.
        public void formatTableDateTime<T>(T obj)
        {
            for (int i = 0; i < obj.GetType().GetProperties().Length; i++)
            {
                if (Type.Equals(obj.GetType().GetProperties()[i].PropertyType, typeof(DateTime)))
                {
                    PrincipalDataGridView.Columns[i].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

            }
        }

        public formPrincipal()
        {
            InitializeComponent();
        }


        private void StyleTextBox(object sender, DrawItemEventArgs e)
        {

            var c = sender as ComboBox;
            e.DrawBackground();


            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
                e.DrawFocusRectangle();
            }

        }

        private void CenterComboBoxTextBox(object sender, DrawItemEventArgs e)
        {
            var c = sender as ComboBox;
            Font font = new Font(c.Font.FontFamily, c.Font.Size, FontStyle.Italic);
            
            if (e.Index >= 0)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(c.Items[e.Index].ToString(), font, new SolidBrush(c.ForeColor), e.Bounds, sf);
            }
        }

        private void initializeComboBox()
        {
            comboBoxCargarDatos.DrawMode = DrawMode.OwnerDrawFixed;
            if (comboBoxCargarDatos.Items.Count == 0)
            {
                OpenFileDialog ofd = Utils.formattedOpenFileDialog();

                this.comboBoxCargarDatos.Items.Add(ofd.Title);

                comboBoxCargarDatos.DrawItem += StyleTextBox;
                comboBoxCargarDatos.DrawItem += CenterComboBoxTextBox;
                comboBoxCargarDatos.ForeColor = System.Drawing.Color.Black;
                comboBoxCargarDatos.SelectionChangeCommitted += new EventHandler(delegate (Object o, EventArgs e)
                {
                    ofd.ShowDialog();
                });
            }
        }

        private void enableSaveAndRevertAllButtonsIfNeeded()
        {
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
            Empleado us;
            for (int i = 0; i < dgvUsers.SelectedRows.Count; i++)
            {
                us = dgvUsers.SelectedRows[i].DataBoundItem as Empleado;
                if (us.getTempStatus())
                {
                    exitCond = true;
                }
            }

            guardarToolStripMenuItem.Enabled = exitCond;
            saveSelectedButton.Enabled = exitCond;
            revertSelectedButton.Enabled = exitCond;

        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {

            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                db.TurnTempIntoPermanent(db.getBindingList());
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                db.restoreFromBackupAndEmptyBackup(db.getBindingList());
            }
        }


        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado u = row.DataBoundItem as Empleado;
                    db.saveObject(u);
                }
                db.getBindingList().ResetBindings();
            }
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            //TODO: Actually save the deletion and stuff for refetching
            if (DialogBoxes.DeleteConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado u = row.DataBoundItem as Empleado;
                    db.getBindingList().Remove(u);
                }
                db.getBindingList().ResetBindings();
            }
        }

        private void saveAll_Menu_Click(object sender, EventArgs e)
        {
            if (db.getBackupList().Count > 0)
            {
                buttonSaveAll_Click(sender, e);
            }
        }

        private void Search_Menu_Click(object sender, EventArgs e)
        {
            Form DetailedView = new FormBuscarUser(this, db);
            DetailedView.ShowDialog(this);
        }

        private void New_Menu_Click(object sender, EventArgs e)
        {
            Form newUserForm = new FormUser(this, false, db);
            newUserForm.ShowDialog(this);
        }

        private void Exit_Menu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Print_Menu_Click(object sender, EventArgs e)
        {
            Form reportForm = new ReportForm(db.getBindingList());
            reportForm.ShowDialog();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            object userToEdit = PrincipalDataGridView.SelectedRows[0].DataBoundItem;
            db.modifyObject(userToEdit, db.getBindingList(), this, db);
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
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado userToRevert = row.DataBoundItem as Empleado;
                    db.revertSingleObject(userToRevert, db.getBindingList());
                }
            }
        }

        private void formPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.preventClosingWithUncommittedChanges(e);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }
    }
}
