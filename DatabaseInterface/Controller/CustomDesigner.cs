using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;


namespace DatabaseInterfaceDemo.Controller
{
    internal class CustomDesigner
    {
        /// <summary>
        /// Hardcoded Padding values.
        /// </summary>
        public enum PADDING : int
        {
            LEFT = 12,
            RIGHT = 32,
            BOTTOM = 8,
            TOP = 8,
            BUTTONS = 112
        }
        /// <summary>
        /// Placing a control below another
        /// </summary>
        /// <param name="ControlToPlace"></param>
        /// <param name="ControlReference"></param>
        public static void PlaceControlBelow(Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X,
                ControlReference.Location.Y + (int)PADDING.BOTTOM + ControlReference.Height);
        }

        /// <summary>
        /// Placing a control aligned at the Bottom Leftmost corner of the form view.</summary>
        /// <param name="ParentForm">Form in which the object is being placed</param>
        /// <param name="ControlToPlace">Object being placed</param>
        public static void PlaceControlBottomLeftCorner(Form ParentForm, Control ControlToPlace)
        {
            ControlToPlace.Location = new Point(
                (int)PADDING.LEFT,
                ParentForm.ClientRectangle.Height - ((int)PADDING.BOTTOM + ControlToPlace.Height));
        }

        /// <summary>
        /// Placing a control aligned at the Bottom Rightmost corner of the form view.
        /// </summary>
        /// <param name="ParentForm"></param>
        /// <param name="ControlToPlace"></param>
        public static void PlaceControlBottomRightCorner(Form ParentForm, Control ControlToPlace)
        {
            ControlToPlace.Location = new Point(
                ParentForm.ClientRectangle.Width - ((int)PADDING.RIGHT + ControlToPlace.Width),
                ParentForm.ClientRectangle.Height - (ControlToPlace.Height + (int)PADDING.BOTTOM));
            
        }


        /// <summary>
        /// Placing a control aligned at the Bottom Right corner of another object (With padding)
        /// </summary>
        /// <param name="ControlToPlace"></param>
        /// <param name="ControlReference"></param>
        public static void PlaceControlBottomRightOf(Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X + ControlReference.Width + (int)PADDING.LEFT,
                ControlReference.Location.Y + ControlReference.Height - ControlToPlace.Height);
        }

        /// <summary>
        /// Placing a control on top of another.
        /// </summary>
        /// <param name="ControlToPlace"></param>
        /// <param name="ControlReference"></param>
        public static void PlaceControlOnTopOf(Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X,
                ControlReference.Location.Y - (int)PADDING.BOTTOM - ControlToPlace.Height);
        }
        /// <summary>
        /// Placing a control aligned at the Top Leftmost corner of the form view.
        /// </summary>
        /// <param name="ControlToPlace"></param>
        public static void PlaceControlTopLeft(Control ControlToPlace)
        {
            ControlToPlace.Location = new Point(
                (int)PADDING.LEFT, (int)PADDING.TOP);
        }


        /// <summary>
        /// Placing a control aligned at the Bottom Right corner of another object (With padding)
        /// </summary>
        /// <param name="ControlToPlace"></param>
        /// <param name="ControlReference"></param>
        public static void PlaceControlTopRightOf(Control ControlToPlace, Control ControlReference)
        {
            ControlToPlace.Location = new Point(
                ControlReference.Location.X + ControlReference.Width + (int)PADDING.LEFT,
                ControlReference.Location.Y);
        }
    }
}
