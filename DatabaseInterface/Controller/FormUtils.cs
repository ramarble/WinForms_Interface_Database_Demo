using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Model;


namespace DatabaseInterfaceDemo.Controller
{
    /*List of methods that I assume are going to be accessed from
     * multiple files. If this turns out to not be the case I'll refactor
     * them somewhere else
    */
    abstract class FormUtils
    {

        public enum PADDING : int
        {
            LEFT = 12,
            RIGHT = 32,
            BOTTOM = 42,
            TOP = 12,
            BUTTONS = 112
        }

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

        public static void PlaceControlAtBottomMostLeft(Form ParentForm, Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X + ControlReference.Width + (int)PADDING.LEFT,
                ParentForm.Size.Height - (int)PADDING.BOTTOM - ControlToPlace.Height);
        }

        /// <summary>
        /// Overload for placing an object at the bottomleftmost of a Form</summary>
        /// <param name="ParentForm">Form in which the object is being placed</param>
        /// <param name="ControlToPlace">Object being placed</param>
        public static void PlaceControlAtBottomMostLeft(Form ParentForm, Control ControlToPlace)
        {
            ControlToPlace.Location = new Point(
                (int)PADDING.LEFT,
                ParentForm.Height - (int)PADDING.BOTTOM - ControlToPlace.Height);
        }

        public static void PlaceControlOnTopOf(Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X,
                ControlReference.Location.Y - (int)PADDING.BOTTOM + ControlToPlace.Height);
        }
        public static void PlaceControlAtBottomMostRight(Form ParentForm, Control ControlToPlace)
        {
            ControlToPlace.Location = new Point(
                ParentForm.Width - ((int)PADDING.RIGHT + ControlToPlace.Width),
                ParentForm.Height - (ControlToPlace.Height + (int)PADDING.BOTTOM));
        }
    }
}
