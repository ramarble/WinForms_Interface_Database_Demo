using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using DatabaseInterface.Model;
using contr = DatabaseInterface.Controller;


namespace DatabaseInterface.Controller
{
    internal abstract class Utils
    {
        public static void cutText(TextBoxBase tbb)
        {
            if (tbb.SelectedText != "")
            {
                tbb.Cut();
            }
        }

        public static Dictionary<Type, string> typeDictionary()
        {
            Dictionary<Type, string> dict = new Dictionary<Type, string>();
            dict.Add(typeof(Empleado), "nif");

            return dict;
        } 


        public static OpenFileDialog formattedOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "<--Abrir Archivo-->";
            ofd.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json|All Files|*.*";

            return ofd;
        }

        public static string returnPathFromOFD(OpenFileDialog ofd)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                return ofd.FileName;
            }
            return null;
        }

        public static string GetFilePathFromSaveFileDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != "")
                {
                    return sfd.FileName;
                }
            }
            return null;
        }

        public static TextBoxBase TextBoxBaseFromControl(Control c)
        {
            if (c is TextBoxBase)
            {
                return c as TextBoxBase;
            }
            else if (c is NumericUpDown)
            {
                return getTextBoxFromNumericUpDown(c as NumericUpDown);
            }
            return null;

        }

        public static TextBox getTextBoxFromNumericUpDown(NumericUpDown nud)
        {
            return nud.Controls.OfType<TextBox>().FirstOrDefault() as TextBox;
        }

        public static List<TextBoxBase> listOfTextBoxesInForm(Form sender)
        {
            List<TextBoxBase> ListOfTextBoxBases = new List<TextBoxBase>();
            foreach (Object o in sender.Controls)
            {
                if (o is TextBoxBase)
                {
                    ListOfTextBoxBases.Add((o as TextBoxBase));
                }
                if (o is NumericUpDown)
                {
                    ListOfTextBoxBases.Add((getTextBoxFromNumericUpDown(o as NumericUpDown)));
                }
            }
            return ListOfTextBoxBases;
        }
        public static Boolean isAnyTextBoxEmptyInForm(Form sender)
        {
            return listOfTextBoxesInForm(sender).Any(x => x.Text.ToString() == "");
        }
    }
}
