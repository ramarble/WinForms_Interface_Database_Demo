using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DatabaseInterfaceDemo.Model
{
    public enum Category
    {
        FOOD_DRINK,
        CLOTHING,
        FURNITURE
    }

    public enum Unit_Type
    {
        Per_100g,
        Per_Unit,
        Per_100ml,
    }

    /*
     * IN ORDER FOR AN ATTRIBUTE TO BE SERIALIZABLE IT HAS TO HAVE A SETTER
     */
    [Serializable]
    [XmlRoot("Producto")]
    public class Producto
    {
        [DisplayName("*")]
        [XmlIgnore]
        public char tempChar { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

        [DisplayName("Categoría")]
        public Category category { get; set; }

        [DisplayName("Price/unit")]
        public int pricePerUnit { get; set; }

        [DisplayName("Unit Type")]
        public Unit_Type unitType { get; set; }

        [DisplayName("Stock")]
        public Int32 Stock { get; set; }

        [DisplayName("Product ID")]
        public Int32 ID { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public Boolean tempStatus { get; set; }

        public Producto() { }
        

        //This is (will?) be needed reverse-engineered recreation of a generic
        public Producto(List<object> l)
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

        public override bool Equals(object obj)
        {
            return obj is Producto producto &&
                   tempChar == producto.tempChar &&
                   name == producto.name &&
                   category == producto.category &&
                   pricePerUnit == producto.pricePerUnit &&
                   unitType == producto.unitType &&
                   Stock == producto.Stock &&
                   ID == producto.ID &&
                   tempStatus == producto.tempStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = 19390550;
            hashCode = hashCode * -1521134295 + tempChar.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + category.GetHashCode();
            hashCode = hashCode * -1521134295 + pricePerUnit.GetHashCode();
            hashCode = hashCode * -1521134295 + unitType.GetHashCode();
            hashCode = hashCode * -1521134295 + Stock.GetHashCode();
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + tempStatus.GetHashCode();
            return hashCode;
        }

        public Producto(char tempChar, string name, Category category, int pricePerUnit, Unit_Type unitType, int stock, int iD, bool tempStatus)
        {
            this.tempChar = tempStatus ? '*' : '\0';
            this.name = name;
            this.category = category;
            this.pricePerUnit = pricePerUnit;
            this.unitType = unitType;
            Stock = stock;
            ID = iD;
            this.tempStatus = tempStatus;
        }


    }
}
