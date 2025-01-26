using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Controller
{
    internal abstract class CustomXMLParser
    {

        public static void TurnIntoXMLFile(List<object> lista, string path)
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
                Type objType = FindTypeFromParsedXMLFile(xml);
                
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
                MessageBox.Show("Error leyendo xml. Puede estar vacío o mal formateado. \n" + e.StackTrace + "\n " + e.InnerException);
                return null;
            }
        }

        public static Type FindTypeFromParsedXMLFile(string[] readLines)
        {
            Dictionary<Type,string> dict = Utils.TypeDictionary();


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


            Type typeFound = dict.FirstOrDefault(c => offendingLine.Contains(c.Key.Name)).Key;

            return typeFound;

        }

    }

}

