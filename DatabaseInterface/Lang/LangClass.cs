using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Lang
{
    class LangClass
    {
        //add every text in the DialogResults
        internal class LangFiles
        {
            public const string PATH = "../../Lang/";
            public const string SPANISH = "ES_ES.json";
            public const string ENGLISH = "EN_EN.json";
        }

        public LangClass(string LangFile)
        {
            LangDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(LangFiles.PATH + LangFile));
        }

        public static Dictionary<string, string> LangDictionary { get; set; }

        public static DialogResult INFO_ObjectAddedToList()
        {
            return MessageBox.Show(LangDictionary["INFO_ObjectAddedToList"], LangDictionary["INFO"]);
        }

        public static DialogResult WARN_RevertConfirm()
        {
            return MessageBox.Show(LangDictionary["WARN_RevertConfirm"], LangDictionary["WARNING"], MessageBoxButtons.YesNo);
        }
        public static DialogResult WARN_SaveConfirm()
        {
            return MessageBox.Show(LangDictionary["WARN_SaveConfirm"], LangDictionary["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_DeleteConfirm()
        {
            return MessageBox.Show(LangDictionary["WARN_DeleteConfirm"], LangDictionary["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult WARN_ExitWithoutSaving()
        {
            return MessageBox.Show(LangDictionary["WARN_ExitWithoutSaving"], LangDictionary["WARNING"], MessageBoxButtons.YesNo);
        }

        public static void WARN_UncommittedChanges()
        {
            DialogResult d = MessageBox.Show(LangDictionary["WARN_UncommittedChanges"], LangDictionary["WARNING"]);
            d = DialogResult.None;
        }

        public static DialogResult WARN_FillAllData()
        {
            return MessageBox.Show(LangDictionary["WARN_FillAllData"], LangDictionary["WARNING"]);
        }

        public static DialogResult CHOICE_WARN_DatabaseOverwrite()
        {
            return MessageBox.Show(LangDictionary["CHOICE_WARN_DatabaseOverwrite"], LangDictionary["WARNING"], MessageBoxButtons.YesNo);
        }

        public static DialogResult ERR_ObjPresent(string primaryKey, string keyValue)
        {
            DialogResult d = MessageBox.Show(LangDictionary["ERR_ObjPresent"] + " " + primaryKey + ": " + keyValue);
            return DialogResult.None;
        }

        public static DialogResult ERR_DBNotInitialized()
        {
            return MessageBox.Show(LangDictionary["ERR_DBNotInitialized"], LangDictionary["ERROR"]);
        }
    }


}