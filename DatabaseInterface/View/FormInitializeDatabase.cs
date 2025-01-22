using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseInterface.Controller;

namespace DatabaseInterfaceDemo.View
{
    public partial class FormInitializeDatabase : Form
    {
        public FormInitializeDatabase(ObjectDataBaseController<object> DB)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            warnLabel.Left = (this.ClientSize.Width - warnLabel.Width) / 2;
            warnLabel.Top = (this.ClientSize.Height - warnLabel.Height) / 2;
            warnLabel.Text = LocalizationText.NOTICE_DatabaseNotInitialized;

        }
    }
}
