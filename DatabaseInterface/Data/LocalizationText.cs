using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Data
{
    public static class LocalizationText
    {

        //Move this to a json :D
        //add every text in the DialogResults
        public static Dictionary<string, string> localizedStrings = new Dictionary<string, string>()
        {
            {"TEMPCHAR_TOOLTIP", "[*] = Revertible\n[ ] = Guardado Temporal"},
            {"WARNING","Advertencia"},
            {"ERROR", "Error"},
            {"INFO", "Información"},
            {"DATA_TYPE", "Tipo de Dato"},
            {"FILE", "Archivo" },
            {"INFO_DatabaseNotInitialized", "Selecciona un tipo de datos o carga un archivo" },
            {"ERR_ObjPresent", "Ya existe un objeto con la clave primaria: "},
            {"WARN_RevertConfirm", "¿Revertir cambios?"},
            {"WARN_SaveConfirm", "¿Guardar cambios?"},
            {"WARN_DeleteConfirm","¿Borrar Seleccionado?"},
            {"WARN_ExitWithoutSaving", "¿Salir sin guardar?"},
            {"WARN_UncommittedChanges", "Por favor confirma o revierte todos los cambios antes de continuar."},
            {"WARN_FillAllData", "Por favor rellena todos los campos"},
            {"CHOICE_WARN_DatabaseOverwrite", "¿Quieres sobreescribir la base de datos?\nESTO BORRARÁ TODAS LAS ENTRADAS"},
            {"ERR_DBNotInitialized", "NO HAY UNA BASE DE DATOS INICIADA"}


        };
       

        public static DialogResult WARN_RevertConfirm()
        {
            return MessageBox.Show(localizedStrings["WARN_RevertConfirm"], localizedStrings["WARNING"], MessageBoxButtons.YesNo);
        }
        public static DialogResult WARN_SaveConfirm()
        {
            return MessageBox.Show(localizedStrings["WARN_SaveConfirm"], localizedStrings["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_DeleteConfirm()
        {
            return MessageBox.Show(localizedStrings["WARN_DeleteConfirm"], localizedStrings["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_ExitWithoutSaving()
        {
            return MessageBox.Show(localizedStrings["WARN_ExitWithoutSaving"], localizedStrings["WARNING"], MessageBoxButtons.YesNo);
        }

        public static void WARN_UncommittedChanges()
        {
            DialogResult d = MessageBox.Show(localizedStrings["WARN_UncommittedChanges"], localizedStrings["WARNING"]);
            d = DialogResult.None;
        }

        public static DialogResult WARN_FillAllData()
        {
            return MessageBox.Show(localizedStrings["WARN_FillAllData"], localizedStrings["WARNING"]);
        }

        public static DialogResult CHOICE_WARN_DatabaseOverwrite()
        {
            return MessageBox.Show(localizedStrings["CHOICE_WARN_DatabaseOverwrite"], localizedStrings["WARNING"],MessageBoxButtons.YesNo);
        }

        public static DialogResult ERR_ObjPresent(string primaryKey, string keyValue)
        {
            DialogResult d = MessageBox.Show(localizedStrings["ERR_ObjPresent"] + " " + primaryKey + ": " + keyValue);
            return DialogResult.None;
        }
        
        public static DialogResult ERR_DBNotInitialized()
        {
            return MessageBox.Show(localizedStrings["ERR_DBNotInitialized"], localizedStrings["ERROR"]);
        }
    }


}
