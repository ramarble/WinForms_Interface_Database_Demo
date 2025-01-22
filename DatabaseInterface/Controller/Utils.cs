using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using contr = DatabaseInterface.Controller;


namespace DatabaseInterface.Controller
{
    internal class Utils
    {
        public static void cutText(TextBoxBase tbb)
        {
            if (tbb.SelectedText != "")
            {
                tbb.Cut();
            }
        }

        public static OpenFileDialog FileLoader()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "<--Abrir Archivo-->";
            ofd.Filter = 
                "JSON (*.json)|*.json|" +
                "XML (*.xml)|*.xml|" +
                "All Files (*.*)|*.*";

            return ofd;
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
