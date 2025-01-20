using System;

namespace DatabaseInterface.Model
{
    public class EventSendObject<T> : EventArgs
    {
        object obj { get; set; }
        Boolean editMode;
        public object getObject()
        {
            return this.obj;
        }
        public Boolean getEditMode()
        {
            return this.editMode;
        }
        public EventSendObject(object obj, Boolean editMode)
        {
            this.obj = obj;
            this.editMode = editMode;
        }
    }
}
