using DatabaseInterface.Controller;
using DatabaseInterface.Model;
using DatabaseInterface.View;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace DatabaseInterface
{
    public partial class formPrincipal : Form
    {

        public formPrincipal()
        {
            InitializeComponent();
        }

        static ObjectDataBaseController<object> DB = new ObjectDataBaseController<object>(typeof(Empleado), "nif");

        static List<string> GLOBAL_PATHS_FILES = new List<string>();

        static OpenFileDialog OFD = Utils.formattedOpenFileDialog();


        private void formPrincipal_Load(object sender, EventArgs e)
        {

            initializeComboBox();
            DB.getBindingList().ListChanged += onListChangeUpdateButtons;
            DB.getBindingList().ListChanged += firstTimeLoadEvent;
            PrincipalDataGridView.DataSourceChanged += onListChangeUpdateButtons;


            //CustomXMLParser.turnIntoXMLFile(db.getBindingList().ToList<object>(), path);

        }

        //This button will only be up when there's 2+ entries to select from
        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            //There's a memory leak somewhere here :D
            DB.getBindingList().ResetBindings();
            //Flush it all away
            DB.getBindingList().Clear();
            DB.setObjectBindingList(CustomXMLParser.XMLReadObjects(GLOBAL_PATHS_FILES[comboBoxCargarDatos.SelectedIndex]));

            initializeDataGridViewWithObjects(DB.getBindingList());

        }

        //This listener removes itself and reacts to an edge case where you add an item and the datagridview wouldn't have been populated
        public void firstTimeLoadEvent(object sender, EventArgs e)
        {
            if (DB.getBindingList().Count == 1)
            {
                initializeDataGridViewWithObjects(DB.getBindingList());
            }
            DB.getBindingList().ListChanged -= firstTimeLoadEvent;
        }


        public void initializeDataGridViewWithObjects(BindingList<object> list)
        {
            this.PrincipalDataGridView.DataSource = list;

            if (list.Count > 0)
            {
                initializeDataGridViewStyling();
            }
            else
            {
                throw new Exception("wow, empty table");
            }

        }

        //This is specific to Empleado
        //This should check for tempStatus whenever loading and put it at the first possible column
        public void initializeDataGridViewStyling()
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
                PrincipalDataGridView.SelectionChanged += onListChangeUpdateButtons;
                PrincipalDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                formatTableDateTime(DB.getBindingList()[0]);
                //Doesn't work yet but what I want is that when the form changes visibility the buttons update
                VisibleChanged += onListChangeUpdateButtons;

            }
         }

        
        //Enables or disables the buttons
        private void onListChangeUpdateButtons(object sender, EventArgs e)
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


        //Checks the object of the list to see if it contains a DateTime, formats it accordingly.
        public void formatTableDateTime(object obj)
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
            this.comboBoxCargarDatos.Items.Add(OFD.Title);
            comboBoxCargarDatos.DrawItem += StyleTextBox;
            comboBoxCargarDatos.DrawItem += CenterComboBoxTextBox;
            comboBoxCargarDatos.ForeColor = System.Drawing.Color.Black;
            comboBoxCargarDatos.SelectionChangeCommitted += manageComboBoxEntries;
            comboBoxCargarDatos.SelectedIndexChanged += checkLoadButtonEligibility;
        }

        //This event starts an OpenFileDialog if you select its entry, and adds the according file returned to the list
        private void manageComboBoxEntries(object sender, EventArgs e)
        {
            if (comboBoxCargarDatos.SelectedIndex == comboBoxCargarDatos.Items.Count - 1)
            {
                string filePathReturned;
                if ((filePathReturned = Utils.returnPathFromOFD(OFD)) != null)
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

        private void checkLoadButtonEligibility(object sender, EventArgs e)
        {
            if (comboBoxCargarDatos.Items.Count > 1 && comboBoxCargarDatos.SelectedIndex != -1)
            {
                buttonLoadData.Enabled = true;
            } else
            {
                buttonLoadData.Enabled = false;
            }
        }

        private void enableSaveAndRevertAllButtonsIfNeeded()
        {
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
        
        //Why am I sending the global dgv as a parameter? it's a mystery.
        private void OneOrManySaveOrRevertButtons(DataGridView dgv)
        {
            //this is kinda very gorey

            Boolean exitCond = false;
            object obj;
            //huh? int i = 0 crashed all of a sudden,but 1 didn't
            for (int i = 1; i < dgv.SelectedRows.Count; i++)
            {
                obj = dgv.SelectedRows[i].DataBoundItem;
                if (DB.getTempStatus(obj))
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
                DB.TurnTempIntoPermanent(DB.getBindingList());
            }
        }

        private void buttonRevertAll_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.RevertConfirm() == DialogResult.Yes)
            {
                DB.restoreFromBackupAndEmptyBackup(DB.getBindingList());
            }
        }


        private void saveSelectedButton_Click(object sender, EventArgs e)
        {
            if (DialogBoxes.SaveConfirm() == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PrincipalDataGridView.SelectedRows)
                {
                    Empleado u = row.DataBoundItem as Empleado;
                    DB.saveObject(u);
                }
                DB.getBindingList().ResetBindings();
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
                    DB.getBindingList().Remove(u);
                }
                DB.getBindingList().ResetBindings();
            }
        }

        private void saveAll_Menu_Click(object sender, EventArgs e)
        {
            if (DB.getBackupList().Count > 0)
            {
                buttonSaveAll_Click(sender, e);
            }
        }

        private void Search_Menu_Click(object sender, EventArgs e)
        {
            Form DetailedView = new FormBuscarUser(this, DB);
            DetailedView.ShowDialog(this);
        }

        private void New_Menu_Click(object sender, EventArgs e)
        {
            Form newUserForm = new FormUser(this, false, DB);
            newUserForm.ShowDialog(this);
        }

        private void Exit_Menu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Print_Menu_Click(object sender, EventArgs e)
        {
            Form reportForm = new ReportForm(DB.getBindingList());
            reportForm.ShowDialog();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            object userToEdit = PrincipalDataGridView.SelectedRows[0].DataBoundItem;
            DB.modifyObject(userToEdit, DB.getBindingList(), this, DB);
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
                    DB.revertSingleObject(userToRevert, DB.getBindingList());
                }
            }
        }

        private void formPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.preventClosingWithUncommittedChanges(e);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }


    }
}
