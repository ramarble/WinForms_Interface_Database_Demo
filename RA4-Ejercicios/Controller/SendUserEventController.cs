using System;
using RA4_Ejercicios.Model;

namespace RA4_Ejercicios.Controller
{
    public class SendUserEventController
    {
        public static event EventHandler<EventSendUser> UserSaved;
        public static void UserSavedTrigger(Object sender, EventSendUser e)
        {
            UserSaved.Invoke(sender, e);
        }
    }
}
