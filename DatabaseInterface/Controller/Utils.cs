using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Model;


namespace DatabaseInterfaceDemo.Controller
{
    /*List of methods that I assume are going to be accessed from
     * multiple files. If this turns out to not be the case I'll refactor
     * them somewhere else
    */
    internal abstract class Utils
    {
        public static void CutText(TextBoxBase tbb)
        {
            if (tbb.SelectedText != "")
            {
                tbb.Cut();
            }
        }

        public static Dictionary<Type, string> TypeDictionary()
        {
            Dictionary<Type, string> dict = new Dictionary<Type, string>
            {
                { typeof(Empleado), "NIF" },
                { typeof(Producto), "ID" }
            };

            return dict;
        } 


        public static OpenFileDialog FormattedOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "<--Abrir Archivo-->";
            ofd.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json|All Files|*.*";

            return ofd;
        }

        public static string ReturnPathFromOFD(OpenFileDialog ofd)
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
                return GetTextBoxFromNumericUpDown(c as NumericUpDown);
            }
            return null;

        }

        public static TextBox GetTextBoxFromNumericUpDown(NumericUpDown nud)
        {
            return nud.Controls.OfType<TextBox>().FirstOrDefault() as TextBox;
        }

        public static List<TextBoxBase> ListOfTextBoxesInForm(Form sender)
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
                    ListOfTextBoxBases.Add((GetTextBoxFromNumericUpDown(o as NumericUpDown)));
                }
            }
            return ListOfTextBoxBases;
        }
        public static Boolean IsAnyTextBoxEmptyInForm(Form sender)
        {
            return ListOfTextBoxesInForm(sender).Any(x => x.Text.ToString() == "");
        }
    }
}
