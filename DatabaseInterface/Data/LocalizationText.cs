using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DatabaseInterface.Controller
{
    internal class LocalizationText
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

        public static DialogResult ExitWithoutSaving()
        {
            return MessageBox.Show("¿Salir sin guardar?", "Advertencia", MessageBoxButtons.YesNo);
        }

        public static void WARN_UncommittedChanges()
        {
            DialogResult d = MessageBox.Show("Por favor confirma o revierte todos los cambios antes de salir", "Advertencia");
            d = DialogResult.None;
        }

        public static DialogResult WARN_FillAllData()
        {
            return MessageBox.Show("Por favor rellena todos los campos", "Advertencia");
        }

        public static string INFO_DatabaseNotInitialized = "Selecciona un tipo de datos o carga un archivo";
        public static string LABEL_DataType = "Tipo de Dato";
        public static string LABEL_File = "Archivo";
        
        public static DialogResult ERR_DBNotInitialized()
        {
            return MessageBox.Show("NO HAY UNA BASE DE DATOS INICIADA", "ERROR");
        }
    }


}
