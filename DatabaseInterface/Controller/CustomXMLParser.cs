using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using DatabaseInterface.Model;

namespace DatabaseInterfaceDemo.Controller
{
    internal class CustomXMLParser
    {

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

        public static List<object> XMLReadObjects(string path)
        {
            List<object> parsedObjList;
            try
            {
                string[] xml = File.ReadAllLines(path);
                Type objType = findTypeFromParsedXMLFile(xml);
                
                Type listType = (new List<object>()).GetType();

                string fullThing = String.Concat(xml);
                using (var reader = new StringReader(fullThing))
                {
                    XmlSerializer serializer = new XmlSerializer(listType, new Type[] { objType });
                    parsedObjList = (List<object>)serializer.Deserialize(reader);
                }
                return parsedObjList;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.StackTrace + " " + e.InnerException);
            }
            throw new Exception("XML File was empty, probably");
        }

        public static Type findTypeFromParsedXMLFile(string[] readLines)
        {
            //TODO:
            //This should be outside and fetched at program start
            List<Type> classes = new List<Type>{typeof(Empleado)};
            string offendingLine = null;
            for (int i = 0; i < 10; i++)
            {
                if (readLines[i].Contains("type=")) {
                    offendingLine = readLines[i];
                    break;
                }
            }
            if (offendingLine == null)
            {
                throw new Exception("XML Data did not include a matching class to deserialize");
            }

            Type typeFound = classes.FirstOrDefault(c => offendingLine.Contains(c.Name));
            return typeFound;

        }

    }

}

