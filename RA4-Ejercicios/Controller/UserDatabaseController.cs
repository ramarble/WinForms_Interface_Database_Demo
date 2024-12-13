using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace RA4_Ejercicios.Controller
{
    public static class UserDatabaseController
    {
        static List<User> userList = createUserList();

        static BindingList<User> userBindingList = new BindingList<User>(userList);
        private static List<User> createUserList() 
        {
            List<User> userList = new List<User>();
            String[] listaNombres = { "Mrsha", "Lyonette", "Numbtongue", "Erin", "Bird"};
            String[] listaApellido1 = { "du", "du", "Redfang", "Summer", "" };
            String[] listaApellido2 = { "Marquin", "Marquin", "Solstice", "Solstice", "" };
            DateTime[] listaFechasNacimiento =
                {
                new DateTime(2016,12,10),
                new DateTime(2004, 8, 30),
                new DateTime(2016, 2, 23),
                new DateTime(2003, 6, 21),
                new DateTime(2020, 4,4)
                };
            int[] listaNIF = { 01234567, 99999999, 00000001, 00000000, 87665443 };

            for (int i  = 0;  i < listaNIF.Length; i++)
            {
                userList.Add(
                   new User(
                    false,
                    listaNombres[i],
                    listaApellido1[i],
                    listaApellido2[i],
                    listaFechasNacimiento[i],
                    listaNIF[i]));
        }
            turnIntoXMLFile(userList);
            return userList;
        }

        public static void turnIntoXMLFile(List<User> lista)
        {

            XmlSerializer serializer = new XmlSerializer(lista.GetType());
            using (StreamWriter writer = new StreamWriter("../../Data/listaUsuarios.xml"))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, lista, ns);
            }
        }

        public static Boolean isNIFPresentInList(List<User> userList, User us1)
        {
            foreach (User user in userList)
            {
                if (us1.getNif().Equals(user.getNif()))
                {
                    return true;
                }

            }
            return false;
        }


        public static void userReceived(object sender, EventSendUser e)
        {
            addUser(getUserList(), e.getUsuario(), e.getEditMode());
        }


        public static void addUser(List<User> userList, User us1, Boolean editMode)
        {
            if (!isNIFPresentInList(userList, us1) | editMode)
            {
                userList.Add(us1);
                userBindingList.ResetBindings();
            }
            else
            {
                //this could/should be a global message
                MessageBox.Show("Ya hay un usuario con ese NIF presente.");
            }
        }

        public static BindingList<User> getUserBindingList()
        {
            return userBindingList;
        }
        public static List<User> getUserList()
        {
            return userList;
        }

        public static void saveChanges(List<User> userList)
        {
            //TODO: check for deletions later
            foreach (User u in userList)
            {
                if (u.getTempStatus())
                {
                    u.setTempStatus(false);
                    userBindingList.ResetBindings();
                }
            }
        }

        public static void revertChanges(List<User> userList)
        {
            //O(n) + O(n) with low memory footprint
            LinkedList<User> tempUsers = new LinkedList<User>();
            foreach (User u in userList)
            {
                if (u.getTempStatus())
                {
                    tempUsers.AddLast(u);
                }
            }

            foreach (User u in tempUsers)
            {
                userList.Remove(u);
            }
            userBindingList.ResetBindings();
        }
    }
}
