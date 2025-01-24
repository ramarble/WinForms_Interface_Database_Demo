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
     * in the current implementation of the databaseinterface, we need 2 values to be hardcoded
     * those being tempChar and tempStatus, which will be ignored by the xmlserialization
     * tempChar will be visible in the datagridview
     */
    [Serializable]
    [XmlRoot("Template")]
    public class TEMPLATE_Class
    {
        [DisplayName("*")]
        [XmlIgnore]
        public char tempChar { get; set; }

        [DisplayName("Primary Key")]
        public string primaryKey { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public Boolean tempStatus { get; set; }

        public TEMPLATE_Class() {
            throw new MemberAccessException("This is a template class");
        }


        //This is (will?) be needed reverse-engineered recreation of a generic
        public TEMPLATE_Class(List<object> l)
        {}

        public void setTempStatus(Boolean temp)
        {
            this.tempStatus = temp;
            this.tempChar = temp ? '*' : '\0';
        }
        public Boolean getTempStatus() { return this.tempStatus; }
        public override string ToString()
        {
            return "THIS IS A TEMPLATE CLASS AND SHOULDN'T BE INSTANCED";
        }
    }
}
