using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios.Controller
{
    internal class DialogBoxes
    {
        public static DialogResult RevertConfirm()
        {
            return MessageBox.Show("¿Revertir cambios? ", "Advertencia", MessageBoxButtons.YesNo);
        }
        public static DialogResult SaveConfirm()
        {
            return MessageBox.Show("¿Guardar Cambios? ", "Info", MessageBoxButtons.YesNo);
        }

        public static DialogResult DeleteConfirm()
        {
            return MessageBox.Show("¿Borrar Seleccionado?", "Advertencia", MessageBoxButtons.YesNo);
        }
    }


}
