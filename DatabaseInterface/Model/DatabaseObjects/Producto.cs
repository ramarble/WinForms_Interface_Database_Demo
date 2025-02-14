using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DatabaseInterfaceDemo.Model
{
    public enum Category
    {
        FOOD_DRINK = 0,
        CLOTHING = 1,
        FURNITURE = 2
    }

    public enum Unit_Type
    {
        Per_100g = 0,
        Per_Unit = 1,
        Per_100ml = 2,
    }

    /*
     * IN ORDER FOR AN ATTRIBUTE TO BE SERIALIZABLE IT HAS TO HAVE A SETTER
     */
    [Serializable]
    [XmlRoot("Producto")]
    public class Producto : BASE_DATABASE_OBJECT
    {

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Categoría")]
        public Category Category { get; set; }

        [DisplayName("Price/unit")]
        public decimal PricePerUnit { get; set; }

        [DisplayName("Unit Type")]
        public Unit_Type UnitType { get; set; }

        [DisplayName("Stock")]
        public Int32 Stock { get; set; }

        [DisplayName("Product ID")]
        public Int32 ID { get; set; }

        public Producto() { }
        
        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Producto producto &&
                   TempChar == producto.TempChar &&
                   Name == producto.Name &&
                   Category == producto.Category &&
                   PricePerUnit == producto.PricePerUnit &&
                   UnitType == producto.UnitType &&
                   Stock == producto.Stock &&
                   ID == producto.ID &&
                   TempStatus == producto.TempStatus;
        }

        public override int GetHashCode()
        {
            int hashCode = 19390550;
            hashCode = hashCode * -1521134295 + TempChar.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            hashCode = hashCode * -1521134295 + PricePerUnit.GetHashCode();
            hashCode = hashCode * -1521134295 + UnitType.GetHashCode();
            hashCode = hashCode * -1521134295 + Stock.GetHashCode();
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + TempStatus.GetHashCode();
            return hashCode;
        }

        public Producto(Boolean tempStatus, string name, Category category, decimal pricePerUnit, Unit_Type unitType, int stock, int ID)
        {
            this.TempChar = tempStatus ? '*' : '\0';
            this.Name = name;
            this.Category = category;
            this.PricePerUnit = pricePerUnit;
            this.UnitType = unitType;
            Stock = stock;
            this.ID = ID;
            this.TempStatus = tempStatus;
        }


    }
}
