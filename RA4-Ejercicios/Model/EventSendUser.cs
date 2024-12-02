using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RA4_Ejercicios.View;

namespace RA4_Ejercicios.Model
    {
    public class EventSendUser : EventArgs
    {
        User u { get; set; }
        public User getUsuario()
        {
            return this.u;
        }
        public EventSendUser(Boolean temp, String nom, String ape1, String ape2, DateTime date, Int32 nif)
        {
             this.u = new User(temp, nom, ape1, ape2, date, nif);
        }
    }
}
