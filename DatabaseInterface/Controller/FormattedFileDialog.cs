using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Controller
{
    internal class FormattedFileDialog
    {
        public static OpenFileDialog formattedOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "<--Abrir Archivo-->";
            ofd.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json|All Files|*.*";

            return ofd;

        }
    }
}
