using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DatabaseInterfaceDemo.Model
{

    /*
     * IN ORDER FOR AN ATTRIBUTE TO BE SERIALIZABLE IT HAS TO HAVE A SETTER
     * in the current implementation of the databaseinterface, we need 2 values to be hardcoded
     * those being tempChar and tempStatus, which will be ignored by the xmlserialization
     * tempChar will be visible in the datagridview
     * EVERY CLASS WE'LL BE USING WILL IMPLEMENT THIS CLASS
     */
    [Serializable]
    [XmlRoot("Template")]
    public abstract class TEMPLATE_Class
    {
        [DisplayName("*")]
        [XmlIgnore]
        [JsonIgnore]
        public char TempChar { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        [JsonIgnore]
        public Boolean TempStatus { get; set; }

        public TEMPLATE_Class() {
        }

        public void SetTempStatus(Boolean temp)
        {
            this.TempStatus = temp;
            this.TempChar = temp ? '*' : '\0';
        }
        public Boolean GetTempStatus() { return this.TempStatus; }
        public override string ToString()
        {
            return "THIS METHOD'S TOSTRING SHOULD BE OVERWRITTEN";
        }
    }
}
