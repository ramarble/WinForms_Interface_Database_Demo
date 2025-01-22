using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DatabaseInterface.Model
{
    /*
     * IN ORDER FOR AN ATTRIBUTE TO BE SERIALIZABLE IT HAS TO HAVE A SETTER
     */
    [Serializable]
    [DataContract(Namespace ="")]
    [KnownType(typeof(Empleado))]
    [XmlRoot("Empleado")]
    public class Empleado
    {
        [DisplayName("*")]
        [XmlIgnore]
        public char tempChar { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

        [DisplayName("Apellido #1")]
        public string surname1 { get; set; }

        [DisplayName("Apellido #2")]
        public string surname2 { get; set; }

        [DisplayName("Salario")]
        public decimal salary { get; set; }

        [DisplayName("NIF")]
        public Int32 nif { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime birthdate { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public Boolean tempStatus { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Empleado user &&
                   tempChar == user.tempChar &&
                   name == user.name &&
                   surname1 == user.surname1 &&
                   surname2 == user.surname2 &&
                   salary == user.salary &&
                   nif == user.nif &&
                   birthdate == user.birthdate &&
                   tempStatus == user.tempStatus;
        }

        

        public Empleado() { }
        public Empleado(Boolean temp, string nombre, string apellido1, string apellido2, decimal salario, DateTime birthdate, Int32 nif)
        {
            this.tempStatus = temp;

            //This is a read-only attribute for display in spreadsheet format,
            //also probably unnecessary if I did things a different way
            this.tempChar = temp ? '*' : '\0';

            this.name = nombre;
            this.salary = salario;
            this.surname1 = apellido1 == "" ? "<empty>" : apellido1;
            this.surname2 = apellido2 == "" ? "<empty>" : apellido2;
            this.nif = nif;
            this.birthdate = birthdate;
        }

        //This is a needed reverse-engineered recreation of a generic
        public Empleado(List<object> l)
        {

        }

        public void setTempStatus(Boolean temp)
        {
            this.tempStatus = temp;
            this.tempChar = temp ? '*' : '\0';
        }
        public Boolean getTempStatus() { return this.tempStatus; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
