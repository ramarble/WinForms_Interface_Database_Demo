using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RA4_Ejercicios.Model
{
    /*
     * IN ORDER TO BE SERIALIZABLE AN ATTRIBUTE HAS TO HAVE A SETTER
     * WHY
     * WHY  
     * WHY
     */
    public class User
    {
        [DisplayName("*")]
        private char tempChar { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

        [DisplayName("Apellido #1")]
        public string surname1 { get; set; }

        [DisplayName("Apellido #2")]
        public string surname2 { get; set; }

        [DisplayName("NIF")]
        public Int32 nif { get; set; }
        public Int32 getNif() { return this.nif; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime birthdate { get; set; }
        private Boolean tempStatus { get; set; }
        public void setTempStatus(Boolean temp) { 
            this.tempStatus = temp;
            this.tempChar = temp ? '*' : '\0';
        }
        public Boolean getTempStatus() { return this.tempStatus; }

        public User() { }
        public User(Boolean temp, string nombre, string apellido1, string apellido2, DateTime birthdate, Int32 nif)
        {
            this.tempStatus = temp;
            this.tempChar = temp ? '*' : '\0';
            this.name = nombre;
            this.surname1 = apellido1 == "" ? "<empty>" : apellido1;
            this.surname2 = apellido2 == "" ? "<empty>" : apellido2;
            this.nif = nif;
            this.birthdate = birthdate;
        }
        
    }
}
