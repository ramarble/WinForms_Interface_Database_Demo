using System;
using DatabaseInterface.Model;

namespace DatabaseInterface.Controller
{
    public class SendUserEventController<T>
    {
        public static event EventHandler<EventSendObject<T>> UserSaved;
        public static void UserSavedTrigger(Object sender, EventSendObject<T> e)
        {
            UserSaved.Invoke(sender, e);
        }
    }
}
