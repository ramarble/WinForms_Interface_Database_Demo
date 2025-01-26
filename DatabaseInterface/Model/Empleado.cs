using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DatabaseInterfaceDemo.Model
{
    /*
     * IN ORDER FOR AN ATTRIBUTE TO BE SERIALIZABLE IT HAS TO HAVE A SETTER
     */
    [Serializable]
    [XmlRoot("Empleado")]
    public class Empleado : TEMPLATE_Class
    {

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Apellido #1")]
        public string Surname1 { get; set; }

        [DisplayName("Apellido #2")]
        public string Surname2 { get; set; }

        [DisplayName("Salario")]
        public decimal Salary { get; set; }

        [DisplayName("NIF")]
        public Int32 NIF { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateTime Birthdate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Empleado user &&
                   TempChar == user.TempChar &&
                   Name == user.Name &&
                   Surname1 == user.Surname1 &&
                   Surname2 == user.Surname2 &&
                   Salary == user.Salary &&
                   NIF == user.NIF &&
                   Birthdate == user.Birthdate &&
                   TempStatus == user.TempStatus;
        }

        
        public Empleado() { }
        public Empleado(Boolean tempStatus, string nombre, string apellido1, string apellido2, decimal salario, DateTime birthdate, Int32 nif)
        {
            this.TempStatus = tempStatus;

            //This is a read-only attribute for display in spreadsheet format,
            //also probably unnecessary if I did things a different way
            this.TempChar = tempStatus ? '*' : '\0';

            this.Name = nombre;
            this.Salary = salario;
            this.Surname1 = apellido1 == "" ? "<empty>" : apellido1;
            this.Surname2 = apellido2 == "" ? "<empty>" : apellido2;
            this.NIF = nif;
            this.Birthdate = birthdate;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 610695206;
            hashCode = hashCode * -1521134295 + TempChar.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname1);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname2);
            hashCode = hashCode * -1521134295 + Salary.GetHashCode();
            hashCode = hashCode * -1521134295 + NIF.GetHashCode();
            hashCode = hashCode * -1521134295 + Birthdate.GetHashCode();
            hashCode = hashCode * -1521134295 + TempStatus.GetHashCode();
            return hashCode;
        }
    }
}
