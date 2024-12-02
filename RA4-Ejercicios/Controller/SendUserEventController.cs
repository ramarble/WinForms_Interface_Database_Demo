using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
