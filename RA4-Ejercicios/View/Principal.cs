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
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.Columns[0].ToolTipText = "[*] = Temporary\n[ ] = Permanent";
            this.dataGridView1.Columns[0].CellTemplate.ToolTipText = "[*] = Temporary\n[ ] = Permanent";
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
            U_DB_C.addNewUser(U_DB_C.getUserList(), e.getUsuario());
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //useradd takes the sender form as parameters, I should probably delete this
            //I'm not doing anything with it.
            //:man_standing:
            Form newUserForm = new UserAdd(this);
            newUserForm.ShowDialog();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {

            DialogResult = MessageBox.Show("Commit Changes? ", "caption?", MessageBoxButtons.YesNo) ;
            if (DialogResult == DialogResult.Yes)
            {
                U_DB_C.commitChanges(U_DB_C.getUserList());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Revert Changes? ", "REVERT CHANGES", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Unimplemented");
            }
        }
    }
}
