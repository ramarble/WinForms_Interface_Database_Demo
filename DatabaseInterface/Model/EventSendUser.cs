using System;

namespace RA4_Ejercicios.Model
{
    public class EventSendUser : EventArgs
    {
        User u { get; set; }
        Boolean editMode;
        public User getUsuario()
        {
            return this.u;
        }
        public Boolean getEditMode()
        {
            return this.editMode;
        }
        public EventSendUser(Boolean temp, String nom, String ape1, String ape2, decimal salary, DateTime date, Int32 nif, Boolean editMode)
        {
            this.u = new User(temp, nom, ape1, ape2, salary, date, nif);
            this.editMode = editMode;
        }
        public EventSendUser(User u, Boolean editMode)
        {
            this.u = u;
            this.editMode = editMode;
        }
    }
}
