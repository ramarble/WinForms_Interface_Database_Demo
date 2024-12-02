using RA4_Ejercicios.Controller;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using RA4_Ejercicios.Model;
using RA4_Ejercicios.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios
{
    public partial class formPrincipal : Form
    {
       
        public formPrincipal()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = U_DB_C.getUserList();
            SUEC.UserSaved += onUserSent;
        }

        private void addListToBindingList(List<User> sourceList, BindingList<User> bindingList)
        {
            foreach (User u in sourceList)
            {
                bindingList.Add(u);
            }
        }

        private void onUserSent(object sender, EventSendUser e)
        {
            U_DB_C.addNewUser(e.getUsuario());
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newUserForm = new UserAdd(this);
            newUserForm.ShowDialog();
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            U_DB_C.addNewUser(new User("a", "b", "c", DateTime.Now, 123));
        }
    }
}
