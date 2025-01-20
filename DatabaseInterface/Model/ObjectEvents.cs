using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace DatabaseInterface.Model
{
    public class ObjectEvents<T> : EventArgs where T : class
    {
        T obj { get; set; }
        Boolean editMode;
        public object getObject()
        {
            return this.obj;
        }
        public Boolean getEditMode()
        {
            return this.editMode;
        }
        public ObjectEvents(T obj, Boolean editMode)
        {
            this.obj = obj;
            this.editMode = editMode;
        }

        public static event SendObjectEvent<T> UserSaved;
        public delegate void SendObjectEvent<T>(object sender, ObjectEvents<T> e) where T : class;
        public static void UserSavedTrigger(object sender, ObjectEvents<T> e)
        {
            UserSaved.Invoke(sender, e);
        }




    }
}
