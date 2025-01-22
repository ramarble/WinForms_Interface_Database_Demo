using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using DatabaseInterface.Model;
using System.ComponentModel;

namespace DatabaseInterfaceDemo.Controller
{
    internal class CustomXMLParser
    {
        public static void XMLParserEmpleado(BindingList<object> list)
        {

            object objarr;
            try
            {
                string xml = File.ReadAllText("../../Data/listaUsuarios.xml");
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Empleado));
                    objarr = serializer.Deserialize(reader);
                }

                Console.WriteLine(objarr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.Message);
            }
        }
    }

}

