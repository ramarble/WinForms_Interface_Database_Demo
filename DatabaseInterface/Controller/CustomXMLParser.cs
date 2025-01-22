using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using DatabaseInterface.Model;

namespace DatabaseInterfaceDemo.Controller
{
    internal class CustomXMLParser
    {
        public static void test(List<Empleado> list)
        {
            try
            {
                string xml = File.ReadAllText("../../Data/listaUsuarios.xml");
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new
                    XmlSerializer(typeof(Empleado));
                    list = (List<Empleado>)serializer.Deserialize(reader);
                }

                foreach(var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.Message);
            }
        }
    }

}

