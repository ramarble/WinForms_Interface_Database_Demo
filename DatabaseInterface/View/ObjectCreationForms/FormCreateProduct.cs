using System;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{

    public partial class FormCreateProduct : BaseFormCreateObject
    {
        
        public FormCreateProduct() : base()
        {
            InitializeComponent();
        }
        object objectBeingModified = (Producto)Activator.CreateInstance(typeof(Producto));

        public FormCreateProduct(Form sender, bool editMode, ObjectDataBaseController<object> db) : base(sender, editMode, db)
        {
            InitializeComponent();
            InitializeComboBoxes();
            DB.SetTempStatus(objectBeingModified, true);
            InitializePrimaryKeyTextBox(nudID);
            LateLoadBaseFormDesign();

        }

        public FormCreateProduct(Form sender, object ob, bool editMode, ObjectDataBaseController<object> db) : base(sender, ob, editMode, db)
        {
            InitializeComponent();
            InitializeComboBoxes();

            InitializePrimaryKeyTextBox(nudID);
            objectBeingModified = (Producto)ob;
            LateLoadBaseFormDesign();
            LoadValuesFromObject(ob);

        }

        private void InitializeComboBoxes()
        {
            comboBoxCategory.DataSource = Enum.GetValues(typeof(Category));
            comboBoxUnitType.DataSource = Enum.GetValues(typeof(Unit_Type));
        }

        private void LoadValuesFromObject(object obj)
        {
            var ob = obj as Producto;
            tbNombre.Text = ob.Name;
            comboBoxCategory.Text = ob.Category.ToString();
            comboBoxUnitType.SelectedValue = ob.UnitType.ToString();
            nudPricePerUnit.Value = ob.PricePerUnit;
            nudID.Value = ob.ID;

        }

        public override void SaveUserAsTemp(object sender, EventArgs e)
        {
            if (Utils.IsAnyTextBoxEmptyInForm(this))
            {
                LocalizationText.WARN_FillAllData();
                this.DialogResult = DialogResult.None; //Why the frick is this how it has to work
                HighlightEmptyTextBoxes();

            }
            else
            {
                Category cat;
                Unit_Type ud_type;
                Enum.TryParse<Category>(comboBoxCategory.SelectedItem.ToString(), out cat);
                Enum.TryParse<Unit_Type>(comboBoxUnitType.SelectedItem.ToString(), out ud_type);
                Producto ob = new Producto(
                    DB.GetTempStatus(objectBeingModified),
                    tbNombre.Text.ToString(),
                    cat, 
                    nudPricePerUnit.Value,
                    ud_type,
                    int.Parse(nudStock.Value.ToString()),
                    int.Parse(nudID.Value.ToString()));

                if (DB.AddObjectToList(DB.GetBindingList(), ob, EditMode))
                {
                    LocalizationText.INFO_ObjectAddedToList();
                    ClearAllTextBoxes(null, null);

                    //These 3 lines of code are holding the weight of the entire program
                    if (EditMode)
                    {
                        DB.SetTempStatus(ob, true);
                        this.Close();
                    }
                };
            }

        }
    }
}
