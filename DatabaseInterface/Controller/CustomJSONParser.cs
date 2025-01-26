using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Model;
namespace DatabaseInterfaceDemo.Controller
{
    internal abstract class CustomJSONParser
    {
        public static void TurnIntoJSONFile(List<object> list, string path)
        {
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonString);
        }

        public static List<object> JSONReadObjects(string path)
        {
            try
            {
                string jsonLines = File.ReadAllText(path);
                Type typeParsed = FindTypeFromParsedJSONFile(jsonLines.Substring(0, 100));

                switch (typeParsed.Name)
                {
                    case nameof(Producto):
                        return JsonSerializer.Deserialize<List<Producto>>(jsonLines).Cast<object>().ToList(); ;
                    case nameof(Empleado):
                        return JsonSerializer.Deserialize<List<Empleado>>(jsonLines).Cast<object>().ToList();
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error leyendo JSON. Puede estar vacío o mal formateado. \n" + e.StackTrace + "\n " + e.InnerException);
                return null;
            }


        }
        public static Type FindTypeFromParsedJSONFile(string readObject)
        {
            Dictionary<Type, string> dict = Utils.TypeDictionary();

            foreach (KeyValuePair<Type,string> entry in dict)
            {
                if (readObject.Contains(entry.Value))
                {
                    return entry.Key;
                }

            }
            throw new KeyNotFoundException("the JSON doesn't have a class I understand");
        }

    }
}
