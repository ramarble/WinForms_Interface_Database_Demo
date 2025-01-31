using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.View;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.View.ObjectCreationForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


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

        static readonly OpenFileDialog OFD = FormUtils.FormattedOpenFileDialog();

        static readonly Dictionary<Type, string> TYPE_DICT = FormUtils.TypeDictionary();

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
                if (DB.IsThereAnyTempUser())
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


        /// <summary>
        /// Intermediary method which calls StartDatabaseController on an empty list based on the type selected from the ComboBox.
        /// This method creates the empty list by creating a fake object and then deleting it.
        /// This method has ObjectFactory references commented in the code.
        /// </summary>
        private void InitDGVColumnsWithEmptyList()
        {
            Type t = GetTypeFromComboBox();
            StartDatabaseController(t, new List<object>() { Activator.CreateInstance(t) });
            //StartDatabaseController(t, ObjectFactory.createEmpleadoList());
            //StartDatabaseController(t, ObjectFactory.createProductList());

            DB.GetBindingList().RemoveAt(0);
        }

        private void LoadDataFromFile(object sender, EventArgs e)
        {
            //There's a memory leak somewhere here :D
            string path = GLOBAL_PATHS_FILES[comboBoxCargarDatos.SelectedIndex];
            List<object> objList = null;
            List<Empleado> empleadoList;


            switch (Path.GetExtension(path))
            {
                case ".xml":
                    objList = CustomXMLParser.XMLReadObjects(path);
                    break;
                case ".json":
                    objList = CustomJSONParser.JSONReadObjects(path);
                    break;
                default:
                    throw new Exception("File Format not accepted (put this in the file)");
            }

            if (objList == null ||objList.Count < 1)
            {
                return;
            }

            StartDatabaseController(objList[0].GetType(), objList);

        }


        private void StartDatabaseController(Type type, List<object> objList)
        {    
            DB = new ObjectDataBaseController<object>(type);
            DB.SetObjectBindingList(objList);
            ReSyncDataTypeComboBoxType();
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

        private void InitializeDataGridView()
        {
            PrincipalDataGridView.AutoGenerateColumns = true;
            PrincipalDataGridView.DataSource = DB.GetBindingList();
            DB.GetBindingList().ResetBindings();
            DB.GetBindingList().ListChanged += OnListChangeUpdateButtons;
            InitializeDataGridViewStyling();
        }

        private void InitializeDataGridViewStyling()
        {

            if (PrincipalDataGridView.DataSource != null)
            {
                //PopulateColumnsWithObjectData();
                PrincipalDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                PrincipalDataGridView.AllowUserToAddRows = false;
                PrincipalDataGridView.SelectionChanged += OnListChangeUpdateButtons;
                PrincipalDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                FormatDateTimeColumn();
                FormatTempStatusColumn();

                //should be moved somewhere else
                buttonSeeForms.Enabled = true;
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
                ManageModifyButton();
                ManageSaveAndRevertButtons();
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

        public void FormatTempStatusColumn()
        {
            DataGridViewColumn dgvc = PrincipalDataGridView.Columns[PrincipalDataGridView.Columns["TempChar"].Index]; 
            dgvc.DisplayIndex = 0;
            dgvc.Width = 25;
            dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvc.ToolTipText = LOC_STRINGS["TEMPCHAR_TOOLTIP"];
            dgvc.CellTemplate.ToolTipText = LOC_STRINGS["TEMPCHAR_TOOLTIP"];

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
                if ((filePathReturned = FormUtils.ReturnPathFromOFD(OFD)) != null)
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

            if (DB.GetBackupList().Count > 0 | DB.IsThereAnyTempUser())
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


        private void ManageModifyButton()
        {
            if (PrincipalDataGridView.SelectedRows.Count == 1)
            {
                buttonModify.Enabled = true;
            }
            else
            {
                buttonModify.Enabled = false;
            }

        }
        
        private void ManageSaveAndRevertButtons()
        {
            //this has crashed before for no real reason.
            Boolean exitCond = false;
            object obj;

            for (int i = 0; i < PrincipalDataGridView.SelectedRows.Count; i++)
            {
                obj = PrincipalDataGridView.SelectedRows[i].DataBoundItem;
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
                DB.RestoreFromBackupAndEmptyBackup(DB.GetBindingList());
            }
        }


        private void SaveSelectedObjectButton_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_SaveConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    object ob = row.DataBoundItem;
                    DB.SaveObject(ob);
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
                    object ob = row.DataBoundItem;
                    DB.GetBindingList().Remove(ob);
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
            MessageBox.Show("Here were dragons");
        }

        private void New_Menu_Click(object sender, EventArgs e)
        {
            if (DB != null)
            {
                GetFormBasedOnDBType().ShowDialog();
            }
            else
            {
                DialogResult d = LocalizationText.ERR_DBNotInitialized();
                d = DialogResult.None;
            }
        }

        /// <summary>
        /// Opens a form to create an object of the corresponding database
        /// </summary>
        /// <returns></returns>
        private Form GetFormBasedOnDBType()
        {
            Form NewObjectForm = null;
            switch (DB.GetDBObjectType().Name)
            {
                case nameof(Empleado):
                    NewObjectForm = new FormCreateEmployee(this, false, DB);
                    break;
                case nameof(Producto):
                    NewObjectForm = new FormCreateProduct(this, false, DB);
                    break;
                  
            }
            return NewObjectForm;
        }

        /// <summary>
        /// Opens a Form to edit an object objectToEdit
        /// </summary>
        /// <param name="objectToEdit"></param>
        /// <returns></returns>
        private Form GetFormBasedOnDBType(object objectToEdit)
        {
            Form NewObjectForm = null;
            switch (DB.GetDBObjectType().Name)
            {
                case nameof(Empleado):
                    NewObjectForm = new FormCreateEmployee(this, objectToEdit, false, DB);
                    break;
                case nameof(Producto):
                    NewObjectForm = new FormCreateProduct(this, objectToEdit, false, DB);
                    break;

            }
            return NewObjectForm;
        }

        private void Exit_Menu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormsPrint_Menu_Click(object sender, EventArgs e)
        {
            if (DB != null)
            {
                Form reportForm = new ReportForm(DB.GetBindingList(), DB.GetDBObjectType());
                reportForm.ShowDialog();
            } else
            {
                LocalizationText.ERR_DBNotInitialized();
            }
        }

        private void ButtonModifyObject_Click(object sender, EventArgs e)
        {
            object objectToEdit = PrincipalDataGridView.SelectedRows[0].DataBoundItem;
            DB.ModifyObject(objectToEdit, this, GetFormBasedOnDBType(objectToEdit), DB);
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
                    object ObjectToRevert = row.DataBoundItem;
                    DB.RevertSingleObject(ObjectToRevert);
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this is an if(!null) in c#
            DB?.PreventClosingWithUncommittedChanges(e); 
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }

        private void ButtonSaveToFile_Click(object sender, EventArgs e)
        {
            string path;
            if ((path = FormUtils.GetFilePathFromSaveFileDialog()) != null)
            {
                switch (Path.GetExtension(path))
                {
                    case ".xml":
                        CustomXMLParser.TurnIntoXMLFile(DB.GetBindingList().ToList<object>(), path);
                        break;
                    case ".json":
                        CustomJSONParser.TurnIntoJSONFile(DB.GetBindingList().ToList<object>(), path);
                        break;
                }
            }
        }

        private void buttonSeeForms_Click(object sender, EventArgs e)
        {
            FormsPrint_Menu_Click(null, null);
        }
    }
}
