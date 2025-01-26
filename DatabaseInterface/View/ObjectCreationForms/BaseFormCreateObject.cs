using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{

    public partial class BaseFormCreateObject : Form
    {
        public BaseFormCreateObject()
        {
            InitializeComponent();
        }
        static readonly Dictionary<string, string> LOC_STRINGS = LocalizationText.localizedStrings;

        public Form parent;
        public Boolean editMode;
        public ObjectDataBaseController<object> db;
        public Type TypeBeingModified;
        public TextBoxBase PrimaryKeyControl;

        //wtf was I cooking here 
        object objectBeingModified = new Empleado(true, "debug", "debug", "debug", 123.0M, DateTime.Today, 1234556);



        public void InitializePrimaryKeyTextBox(Control c)
        {
            if (typeof(TextBoxBase).IsAssignableFrom(c.GetType()))
            {
                PrimaryKeyControl = c as TextBoxBase;
            }
            else if (c.GetType() == typeof(NumericUpDown))
            {
                PrimaryKeyControl = Utils.GetTextBoxFromNumericUpDown(c as NumericUpDown);
            }
            else
            {
                throw new FieldAccessException("The Primary Key field was not assigned or it's of an incorrect type");
            }
        } 

        public BaseFormCreateObject(Form sender, Boolean editMode, ObjectDataBaseController<object> db)
        {
            InitializeComponent();

            parent = sender;
            this.db = db;
            this.TypeBeingModified = db.GetDBObjectType();

            //Constructor used by ADD NEW mode
            this.editMode = editMode;
            //UserFormInitialize(sender);
        }

        public BaseFormCreateObject(Form sender, object ob, Boolean editMode, ObjectDataBaseController<object> db)
        {
            InitializeComponent();
            this.parent = sender;
            this.db = db;
            this.TypeBeingModified = db.GetDBObjectType();

            //Constructor used by Edit mode
            this.Text = "DO THE THING WITH THE LOCALIZATION";
            this.editMode = editMode;


            //iN THIS FORM WE HAVE TO PULL THE DATA FROM THE OBJECT BEING MODIFIED
            //UserFormInitialize(sender);
            /*
             * userReference = ob;
            tbNombre.Text = ob.name;
            tbApe1.Text = ob.surname1;
            tbApe2.Text = ob.surname2;
            numSalary.Text = ob.salary.ToString();
            tbNIF.Text = ob.nif.ToString();
            dtpFechaNacimiento.Value = ob.birthdate;
            */
        }


        protected override void OnClosed(EventArgs e)
        {
            this.parent.Show();
            base.OnClosed(e);
        }


        public void LoadListenersForTextBoxes()
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {
                t.ContextMenuStrip = contextMenuStrip1;
                t.Enter += ResetColorToDefault;
                t.Enter += OnEnterHighlightAllText;
            }
        }

        public void ResetColorToDefault(object sender, EventArgs e)
        {
            (sender as TextBoxBase).BackColor = System.Drawing.Color.White;
        }

        public void HighlightEmptyTextBoxes()
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {
                if (String.IsNullOrWhiteSpace(t.Text.ToString()))
                {
                    t.BackColor = System.Drawing.Color.Beige;
                }
            }
        }

        public virtual void SaveUserAsTemp(object sender, EventArgs e)
        {
            if (Utils.IsAnyTextBoxEmptyInForm(this))
            {
                LocalizationText.WARN_FillAllData();
                this.DialogResult = DialogResult.None; //Why the frick is this how it has to work
                HighlightEmptyTextBoxes();

            }
            else
            {
                /*
                usernif = Int32.Parse(tbNIF.Text.ToString().Replace(" ", ""));
                Empleado u = new Empleado(
                    objectBeingModified.GetTempStatus(),
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(), NumberStyles.Any),
                    dtpFechaNacimiento.Value,
                    usernif);
                if (u.Equals(objectBeingModified))
                {
                    db.SetTempStatus(u, objectBeingModified.TempStatus);
                    db.GetBackupList().Remove(objectBeingModified);
                }
                else
                {
                    db.SetTempStatus(u, true);
                };
                db.AddObjectToList(db.GetBindingList(), u, editMode);
                */
            }

        }

        public void LateLoadBaseFormDesign()
        {
            KeyPreview = true;
            LoadListenersForTextBoxes();
            //For edit mode you're editing an existing user, and can't change its primary key
            if (editMode)
            {
                PrimaryKeyControl.ReadOnly = true;
            }
            else
            {
                PrimaryKeyControl.ReadOnly = false;
            }


            buttonClear.Click += ButtonClear_Click;

            buttonClose.Click += ButtonClose_Click;
            cortarToolStripMenuItem.Click += CortarToolStripMenuItem_Click;
            cortarContextStripMenuItem.Click += CortarToolStripMenuItem_Click;
            pegarToolStripMenuItem.Click += PegarToolStripMenuItem_Click;
            pegarContextStripMenuItem.Click += PegarToolStripMenuItem_Click;
            copiarToolStripMenuItem.Click += CopiarToolStripMenuItem_Click;
            copiarContextStripMenuItem.Click += CopiarToolStripMenuItem_Click;
            acercaDeToolStripMenuItem.Click += AcercaDeToolStripMenuItem_Click;
        }

        public virtual void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();
        }

        public virtual void ButtonClear_Click(object sender, EventArgs e)
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {

                if (!t.ReadOnly)
                {
                    t.Text = "";
                }

            }
            this.DialogResult = DialogResult.None;

        }

        public virtual void ButtonClose_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_ExitWithoutSaving() == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public virtual void OnEnterHighlightAllText(object sender, EventArgs e)
        {
            TextBoxBase textBox = sender as TextBoxBase;
            if (textBox.Text.ToString() != "")
            {
                textBox.Select(0, textBox.Text.Length);
            }
        }

        public virtual void CortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.CutText(Utils.TextBoxBaseFromControl(this.ActiveControl));
        }

        public virtual void PegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Paste();
        }


        public virtual void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        public virtual void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }
    }
}
