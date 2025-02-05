using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Data
{
    public static class i18n_spanish
    {

        //Move this to a json :D
        //add every text in the DialogResults
        public static Dictionary<string, string> i18n = new Dictionary<string, string>()
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
            {"ERR_DBNotInitialized", "NO HAY UNA BASE DE DATOS INICIADA"},
            {"INFO_ObjectAddedToList", "Objeto añadido a la lista correctamente."}

        };

        public static DialogResult INFO_ObjectAddedToList()
        {
            return MessageBox.Show(i18n["INFO_ObjectAddedToList"], i18n["INFO"]);

        }

        public static DialogResult WARN_RevertConfirm()
        {
            return MessageBox.Show(i18n["WARN_RevertConfirm"], i18n["WARNING"], MessageBoxButtons.YesNo);
        }
        public static DialogResult WARN_SaveConfirm()
        {
            return MessageBox.Show(i18n["WARN_SaveConfirm"], i18n["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_DeleteConfirm()
        {
            return MessageBox.Show(i18n["WARN_DeleteConfirm"], i18n["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_ExitWithoutSaving()
        {
            return MessageBox.Show(i18n["WARN_ExitWithoutSaving"], i18n["WARNING"], MessageBoxButtons.YesNo);
        }

        public static void WARN_UncommittedChanges()
        {
            DialogResult d = MessageBox.Show(i18n["WARN_UncommittedChanges"], i18n["WARNING"]);
            d = DialogResult.None;
        }

        public static DialogResult WARN_FillAllData()
        {
            return MessageBox.Show(i18n["WARN_FillAllData"], i18n["WARNING"]);
        }

        public static DialogResult CHOICE_WARN_DatabaseOverwrite()
        {
            return MessageBox.Show(i18n["CHOICE_WARN_DatabaseOverwrite"], i18n["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult ERR_ObjPresent(string primaryKey, string keyValue)
        {
            DialogResult d = MessageBox.Show(i18n["ERR_ObjPresent"] + " " + primaryKey + ": " + keyValue);
            return DialogResult.None;
        }

        public static DialogResult ERR_DBNotInitialized()
        {
            return MessageBox.Show(i18n["ERR_DBNotInitialized"], i18n["ERROR"]);
        }
    }


}