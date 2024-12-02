using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA4_Ejercicios.Model
{
    [Serializable()]
    public class User 
    {
        public string nombre { get; }
        public string apellido1 { get; }
        public string apellido2 { get; } 
        public Int32 nif {get;}
        public DateTime birthdate { get; }

        public User(string nombre, string apellido1, string apellido2, DateTime birthdate, Int32 nif)
        {
            this.nombre = nombre;
            this.apellido1 = apellido1 == "" ? "<empty>" : apellido1;
            this.apellido2 = apellido2 == "" ? "<empty>" : apellido2;
            this.nif = nif;
            this.birthdate = birthdate;
        }
    }
}
