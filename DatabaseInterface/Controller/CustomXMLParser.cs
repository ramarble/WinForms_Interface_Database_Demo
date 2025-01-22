using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using DatabaseInterface.Model;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace DatabaseInterfaceDemo.Controller
{
    internal class CustomXMLParser
    {
        public static List<object> XMLReadObjects(Type type, string path)
        { 
            Type objType = type;
            Type listType = (new List<object>()).GetType();
            List<object> parsedObjList;
            try
            {
                string xml = File.ReadAllText(path);
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(listType, new Type[] {objType});
                    parsedObjList= (List<object>) serializer.Deserialize(reader);
                }
                return parsedObjList;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.StackTrace + " " + e.InnerException);
            }
            throw new Exception("Xml File was empty, probably");
        }

        public static void turnIntoXMLFile(List<object> lista, string path)
        {

            XmlSerializer serializer = new XmlSerializer(lista.GetType(), new Type[] { lista[0].GetType() });

            using (StreamWriter writer = new StreamWriter(path))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, lista, ns);
            }
        }
    }

}

