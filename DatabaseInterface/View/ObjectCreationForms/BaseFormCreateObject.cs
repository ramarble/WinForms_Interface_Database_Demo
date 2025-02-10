using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Lang;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{

    public partial class BaseFormCreateObject : Form
    {
        public BaseFormCreateObject()
        {
            InitializeComponent();
        }
        static readonly Dictionary<string, string> LOC_STRINGS = Lang.LangClass.LangDictionary;

        public Form parentForm;
        public Boolean EditMode;
        public ObjectDataBaseController<object> DB;
        public Type TypeBeingModified;
        public TextBoxBase PrimaryKeyControl;


        public void InitializePrimaryKeyTextBox(Control c)
        {
            if (typeof(TextBoxBase).IsAssignableFrom(c.GetType()))
            {
                PrimaryKeyControl = c as TextBoxBase;
            }
            else if (c.GetType() == typeof(NumericUpDown))
            {
                PrimaryKeyControl = FormUtils.GetTextBoxFromNumericUpDown(c as NumericUpDown);
            }
            else
            {
                throw new FieldAccessException("The Primary Key field was not assigned or it's of an incorrect type");
            }

        } 

        public BaseFormCreateObject(Form sender, Boolean editMode, ObjectDataBaseController<object> db)
        {
            InitializeComponent();

            parentForm = sender;
            this.DB = db;
            this.TypeBeingModified = db.GetDBObjectType();

            //Constructor used by ADD NEW mode
            this.EditMode = editMode;
        }

        public BaseFormCreateObject(Form sender, object ob, Boolean editMode, ObjectDataBaseController<object> db)
        {
            InitializeComponent();
            this.parentForm = sender;
            this.DB = db;
            this.TypeBeingModified = db.GetDBObjectType();

            //Constructor used by Edit mode
            this.Text = "DO THE THING WITH THE LOCALIZATION";
            this.EditMode = editMode;

        }



        public void LoadListenersForTextBoxes()
        {
            foreach (TextBoxBase t in FormUtils.ListOfTextBoxesInForm(this))
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
            foreach (TextBoxBase t in FormUtils.ListOfTextBoxesInForm(this))
            {
                if (String.IsNullOrWhiteSpace(t.Text.ToString()))
                {
                    t.BackColor = System.Drawing.Color.Beige;
                }
            }
        }

        public virtual void SaveUserAsTemp(object sender, EventArgs e)
        {
        }

        public void LateLoadBaseFormDesign()
        {
            KeyPreview = true;
            LoadListenersForTextBoxes();
            //For edit mode you're editing an existing user, and can't change its primary key
            if (EditMode)
            {
                PrimaryKeyControl.ReadOnly = true;
            }
            else
            {
                PrimaryKeyControl.ReadOnly = false;
            }


            buttonClear.Click += ClearAllTextBoxes;

            buttonClose.Click += ButtonClose_Click;
            cortarToolStripMenuItem.Click += CortarToolStripMenuItem_Click;
            cortarContextStripMenuItem.Click += CortarToolStripMenuItem_Click;
            pegarToolStripMenuItem.Click += PegarToolStripMenuItem_Click;
            pegarContextStripMenuItem.Click += PegarToolStripMenuItem_Click;
            copiarToolStripMenuItem.Click += CopiarToolStripMenuItem_Click;
            copiarContextStripMenuItem.Click += CopiarToolStripMenuItem_Click;
            acercaDeToolStripMenuItem.Click += AcercaDeToolStripMenuItem_Click;
            buttonSave.Click += SaveUserAsTemp;
            buttonSave.DialogResult = DialogResult.None;
        }


        public virtual void ClearAllTextBoxes(object sender, EventArgs e)
        {
            foreach (TextBoxBase t in FormUtils.ListOfTextBoxesInForm(this))
            {
                if (!t.ReadOnly)
                {
                    t.Text = "";
                }

            }
            DialogResult = DialogResult.None;

        }

        public virtual void ButtonClose_Click(object sender, EventArgs e)
        {
            BaseFormCreateObject_FormClosing(null, null);
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
            FormUtils.CutText(FormUtils.TextBoxBaseFromControl(this.ActiveControl));
        }

        public virtual void PegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtils.TextBoxBaseFromControl(this.ActiveControl).Paste();
        }

        public virtual void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        public virtual void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }

        public virtual void OnBaseFormClosed(object sender, EventArgs e)
        {
            parentForm.Show();
            base.OnClosed(e);
        }

        public virtual void BaseFormCreateObject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!FormUtils.IsAnyTextBoxEmptyInForm(this))
            {
                if (Lang.LangClass.WARN_ExitWithoutSaving() != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
