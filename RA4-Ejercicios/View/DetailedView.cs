using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;

namespace RA4_Ejercicios.View
{
    public partial class DetailedView : Form
    {
        List<User> tempEditedUsers = new List<User>();
        BindingList<User> userList;

        Form owner;
        public DetailedView(BindingList<User> userList, Form sender) 
        {
            InitializeComponent();
            this.userList = userList;
            listBox1.DataSource = this.userList;
            listBox1.ValueMember = "NIF";
            listBox1.DisplayMember = "Name";
            listBox1.SelectedValue = listBox1.Items[0];
            listBox1.SelectedValueChanged += UpdateObjectView;
            listBox1.SelectionMode = SelectionMode.One;
            this.owner = sender;
            sender.Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
         //   listBox1.
            base.OnShown(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            owner.Visible = true;
            SUEC.UserSaved += userSent;
            base.OnClosed(e);
        }

        private void userSent(object sender, EventSendUser e)
        {
            U_DB_C.addUser(U_DB_C.getUserList(), e.getUsuario(), e.getEditMode());
        }

        private void UpdateObjectView(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = listBox1.SelectedItem;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.DataSource = this.userList.Where(
                user => user.name.ToLower().Contains(
                textBox1.Text.ToLower())).ToList();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userEdited = (User)propertyGrid1.SelectedObject;
            tempEditedUsers.Add(userEdited);
            UserForm f = new UserForm(this, userEdited, true);
            f.Show();
        }
    }
}
