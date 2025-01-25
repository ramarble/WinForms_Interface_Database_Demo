﻿using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.View;
using DatabaseInterfaceDemo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Data;


namespace DatabaseInterfaceDemo
{
    partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        static ObjectDataBaseController<object> DB;

        static readonly List<string> GLOBAL_PATHS_FILES = new List<string>();

        static readonly OpenFileDialog OFD = Utils.FormattedOpenFileDialog();

        static readonly Dictionary<Type, string> TYPE_DICT = Utils.TypeDictionary();

        static readonly Dictionary<string, string> LOC_STRINGS = LocalizationText.localizedStrings;

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            InitializeLoadFileComboBox();
            SetLocalizedStringText();
            InitializeDataTypeComboBox();
            PrincipalDataGridView.DataSourceChanged += OnListChangeUpdateButtons;

        }

        private void SetLocalizedStringText()
        {
            labelDatabase.Text = LOC_STRINGS["INFO_DatabaseNotInitialized"];
            labelFile.Text = LOC_STRINGS["FILE"];
            labelDataType.Text = LOC_STRINGS["DATA_TYPE"];
        }

        private void InitializeDataTypeComboBox()
        {
            foreach (Type type in TYPE_DICT.Keys)
            {
                comboBoxDataType.Items.Add(type.Name);
            }
            comboBoxDataType.SelectedIndexChanged += InitializeDatabaseChange;
        }

        //Today I decided to reverse engineer my own program
        private Type GetTypeFromComboBox()
        {
            return Type.GetType(typeof(TEMPLATE_Class).Namespace + "." + comboBoxDataType.SelectedItem.ToString());
        }


        private void InitializeDatabaseChange(object sender, EventArgs e)
        {
            if (DB == null || DB.GetBindingList().Count == 0)
            {
                InitDGVColumnsWithEmptyList();
            }
            if (DB.GetBindingList().Count > 0 && !IsDataTypeSynced())
            {
                if (DB.isThereAnyTempUser())
                {
                    LocalizationText.WARN_UncommittedChanges();
                    ReSyncDataTypeComboBoxType();
                }
                if (LocalizationText.CHOICE_WARN_DatabaseOverwrite() == DialogResult.Yes)
                {
                    //Spaghetti
                    InitDGVColumnsWithEmptyList();
                }
                else
                {
                    ReSyncDataTypeComboBoxType();
                }
            }
        }

        private void InitDGVColumnsWithEmptyList()
        {
            Type t = GetTypeFromComboBox();
            StartDatabaseController(t, new List<object>() { Activator.CreateInstance(t) });
            DB.GetBindingList().RemoveAt(0);
        }

        //This button will only be up when there's 2+ entries to select from
        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            //There's a memory leak somewhere here :D
            List<object> objList = CustomXMLParser.XMLReadObjects(GLOBAL_PATHS_FILES[comboBoxCargarDatos.SelectedIndex]);
            
            if (objList == null ||objList.Count < 1)
            {
                return;
            }

            StartDatabaseController(objList[0].GetType(), objList);
            
        }

        //This should be the only method I use for the constructor? 
        public void StartDatabaseController(Type type, List<object> objList)
        {    
            DB = new ObjectDataBaseController<object>(type);
            DB.SetObjectBindingList(objList);
            comboBoxDataType.SelectedItem = DB.GetDBObjectType().Name;
            InitializeDataGridView();
        }

        private Boolean IsDataTypeSynced()
        {
            return (string) comboBoxDataType.SelectedItem == DB.GetDBObjectType().Name;        
        }
        
        private void ReSyncDataTypeComboBoxType()
        {
            comboBoxDataType.SelectedItem = DB.GetDBObjectType().Name;
        }

        public void InitializeDataGridView()
        {
            PrincipalDataGridView.AutoGenerateColumns = true;
            PrincipalDataGridView.DataSource = DB.GetBindingList();
            DB.GetBindingList().ResetBindings();
            DB.GetBindingList().ListChanged += OnListChangeUpdateButtons;
            InitializeDataGridViewStyling();
        }

        //This is specific to Empleado
        //This should check for tempStatus whenever loading and put it at the first possible column
        public void InitializeDataGridViewStyling()
        {

            if (PrincipalDataGridView.DataSource != null)
            {
                //PopulateColumnsWithObjectData();
                PrincipalDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                PrincipalDataGridView.Columns[0].Width = 25;
                PrincipalDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                PrincipalDataGridView.Columns[0].ToolTipText = LOC_STRINGS["TEMPCHAR_TOOLTIP"];
                PrincipalDataGridView.Columns[0].CellTemplate.ToolTipText = LOC_STRINGS["TEMPCHAR_TOOLTIP"];
                PrincipalDataGridView.AllowUserToAddRows = false;
                PrincipalDataGridView.SelectionChanged += OnListChangeUpdateButtons;
                PrincipalDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                FormatDateTimeColumn();

                //Doesn't work? but what I want is that when the form changes visibility the buttons update
                VisibleChanged += OnListChangeUpdateButtons;
            }
        }
       

        //Enables or disables the buttons
        private void OnListChangeUpdateButtons(object sender, EventArgs e)
        {

            if (PrincipalDataGridView.SelectedRows.Count > 0)
            {
                //Always a possibility
                buttonDeleteSelected.Enabled = true;
                ManageModifyButton(PrincipalDataGridView);
                ManageSaveAndRevertButtons(PrincipalDataGridView);
            }
            else
            {
                buttonModify.Enabled = false;
                buttonDeleteSelected.Enabled = false;
                saveSelectedButton.Enabled = false;
                revertSelectedButton.Enabled = false;
            }
            ManageButtonsForTempUsers();
        }


        //Checks the object of the list to see if it contains a DateTime, formats it accordingly.
        public void FormatDateTimeColumn()
        {
            for (int i = 0; i < PrincipalDataGridView.Columns.Count; i++)
            {
                if (PrincipalDataGridView.Columns[i].ValueType == typeof(DateTime))
                {
                    PrincipalDataGridView.Columns[i].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
                  
        }

        private void StyleTextBox(object sender, DrawItemEventArgs e)
        {

            var c = sender as ComboBox;
            e.DrawBackground();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220,220,220)), e.Bounds);
                e.DrawFocusRectangle();
            }

        }

        private void StyleTextInComboBox(object sender, DrawItemEventArgs e)
        {
            var c = sender as ComboBox;
            Font font = new Font(c.Font.FontFamily, c.Font.Size-1, FontStyle.Bold);
            StringFormat sf = new StringFormat();

            if (e.Index == comboBoxCargarDatos.Items.Count -1 )
            {
                font = new Font(c.Font.FontFamily, c.Font.Size-2, FontStyle.Italic);
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(c.Items[e.Index].ToString(), font, new SolidBrush(Color.FromArgb(25,25,25)), e.Bounds, sf);

            }
            else if (e.Index >= 0)
            {
                sf.LineAlignment = StringAlignment.Near;
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(c.Items[e.Index].ToString(), font, new SolidBrush(c.ForeColor), e.Bounds, sf);
            }

        }

        private void InitializeLoadFileComboBox()
        {
            comboBoxCargarDatos.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxCargarDatos.Items.Add(OFD.Title);
            comboBoxCargarDatos.DrawItem += StyleTextBox;
            comboBoxCargarDatos.DrawItem += StyleTextInComboBox;
            comboBoxCargarDatos.ForeColor = Color.Black;
            comboBoxCargarDatos.SelectionChangeCommitted += ManageComboBoxEntries;
            comboBoxCargarDatos.SelectedIndexChanged += CheckLoadButtonEligibility;
        }

        //This event starts an OpenFileDialog if you select its entry, and adds the according file returned to the list
        private void ManageComboBoxEntries(object sender, EventArgs e)
        {
            if (comboBoxCargarDatos.SelectedIndex == comboBoxCargarDatos.Items.Count - 1)
            {
                string filePathReturned;
                if ((filePathReturned = Utils.ReturnPathFromOFD(OFD)) != null)
                {
                    GLOBAL_PATHS_FILES.Insert(0, filePathReturned);
                    comboBoxCargarDatos.Items.Insert(0, Path.GetFileName(filePathReturned));
                    
                    //Old code to find entry and change the name, sadly this also changes the entry and I don't want that.
                    //comboBoxCargarDatos.Items[comboBoxCargarDatos.FindStringExact(filePathReturned.ToString())] = Path.GetFileName(filePathReturned);
                    
                    comboBoxCargarDatos.SelectedIndex = 0;
                } else
                {
                    comboBoxCargarDatos.SelectedIndex = -1;
                }

            }
        }

        private void CheckLoadButtonEligibility(object sender, EventArgs e)
        {
            if (comboBoxCargarDatos.Items.Count > 1 && comboBoxCargarDatos.SelectedIndex != -1)
            {
                buttonLoadData.Enabled = true;
            } else
            {
                buttonLoadData.Enabled = false;
            }
        }

        private void ManageButtonsForTempUsers()
        {

            if (DB.GetBackupList().Count > 0 | DB.isThereAnyTempUser())
            {
                buttonRevertAll.Enabled = true;
                buttonSaveTemp.Enabled = true;

                buttonSaveToFile.Enabled = false;
            }
            else
            {
                buttonRevertAll.Enabled = false;
                buttonSaveTemp.Enabled = false;

                buttonSaveToFile.Enabled = true;
            }
        }


        private void ManageModifyButton(DataGridView dgvUsers)
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
        
        //Why am I sending the global dgv as a parameter? it's a mystery.
        private void ManageSaveAndRevertButtons(DataGridView dgv)
        {
            //this has crashed before for no real reason.
            Boolean exitCond = false;
            object obj;

            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {
                obj = dgv.SelectedRows[i].DataBoundItem;
                if (DB.GetTempStatus(obj))
                {
                    exitCond = true;
                }
            }

            guardarToolStripMenuItem.Enabled = exitCond;
            saveSelectedButton.Enabled = exitCond;
            revertSelectedButton.Enabled = exitCond;

        }

        private void ButtonSaveAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_SaveConfirm() == DialogResult.Yes)
            {
                DB.TurnTempIntoPermanent(DB.GetBindingList());
            }
        }

        private void ButtonRevertAll_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_RevertConfirm() == DialogResult.Yes)
            {
                DB.restoreFromBackupAndEmptyBackup(DB.GetBindingList());
            }
        }


        private void SaveSelectedObjectButton_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_SaveConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado u = row.DataBoundItem as Empleado;
                    DB.saveObject(u);
                }
                DB.GetBindingList().ResetBindings();
            }
        }

        private void DeleteSelectedObjectButton_Click(object sender, EventArgs e)
        {
            //TODO: Actually save the deletion and stuff for refetching
            if (LocalizationText.WARN_DeleteConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado u = row.DataBoundItem as Empleado;
                    DB.GetBindingList().Remove(u);
                }
                DB.GetBindingList().ResetBindings();
            }
        }

        private void SaveAll_Menu_Click(object sender, EventArgs e)
        {
            if (DB.GetBackupList().Count > 0)
            {
                ButtonSaveAll_Click(sender, e);
            }
        }

        private void Search_Menu_Click(object sender, EventArgs e)
        {
            if (DB != null) 
            {
                Form DetailedView = new FormBuscarUser(this, DB);
                DetailedView.ShowDialog(this);
            } else
            {
                DialogResult d = LocalizationText.ERR_DBNotInitialized();
                d = DialogResult.None;
            }
        }

        private void New_Menu_Click(object sender, EventArgs e)
        {
            if (DB != null)
            {
                Form newUserForm = new FormUser(this, false, DB);
                newUserForm.ShowDialog(this);
            }
            else
            {
                DialogResult d = LocalizationText.ERR_DBNotInitialized();
                d = DialogResult.None;
            }
        }

        private void Exit_Menu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Print_Menu_Click(object sender, EventArgs e)
        {
            if (DB != null)
            {
                Form reportForm = new ReportForm(DB.GetBindingList());
                reportForm.ShowDialog();
            } else
            {
                DialogResult d = LocalizationText.ERR_DBNotInitialized();
                d = DialogResult.None;
            }
        }

        private void ButtonModifyObject_Click(object sender, EventArgs e)
        {
            object userToEdit = PrincipalDataGridView.SelectedRows[0].DataBoundItem;
            DB.modifyObject(userToEdit, DB.GetBindingList(), this, DB);
        }

        private void MaximizarToolStrip_Click(object sender, EventArgs e)
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

        private void RevertSelectedButton_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_RevertConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado userToRevert = row.DataBoundItem as Empleado;
                    DB.revertSingleObject(userToRevert, DB.GetBindingList());
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DB != null)
            {
                DB.PreventClosingWithUncommittedChanges(e);
            } 
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }

        private void ButtonSaveToFile_Click(object sender, EventArgs e)
        {
            string path;
            if ((path = Utils.GetFilePathFromSaveFileDialog()) != null)
            {
                CustomXMLParser.turnIntoXMLFile(DB.GetBindingList().ToList<object>(), path);
            }
        }
    }
}
