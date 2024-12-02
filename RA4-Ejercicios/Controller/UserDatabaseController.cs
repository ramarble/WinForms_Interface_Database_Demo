using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RA4_Ejercicios.Controller
{
    public static class UserDatabaseController
    {
        static BindingList<User> userBindingList = createUserBindingList();
        private static BindingList<User> createUserBindingList() 
        {
            BindingList<User> userBindingList = new BindingList<User>();
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
                userBindingList.Add(
                   new User(
                    false,
                    listaNombres[i],
                    listaApellido1[i],
                    listaApellido2[i],
                    listaFechasNacimiento[i],
                    listaNIF[i]));
        }
            return userBindingList;
        }

        public static Boolean isNIFPresentInList(BindingList<User> userBindingList, User us1)
        {
            foreach (User user in userBindingList)
            {
                if (us1.getNif().Equals(user.getNif()))
                {
                    return true;
                }

            }
            return false;
        }

        public static void addNewUser(BindingList<User> userBindingList, User us1)
        {
            if (!isNIFPresentInList(userBindingList, us1))
            {
                userBindingList.Add(us1);
            }
            else
            {
                //this could/should be a global message
                MessageBox.Show("Ya hay un usuario con ese NIF presente.");
            }
        }

        public static BindingList<User> getUserList()
        {
            return userBindingList;
        }

        public static void commitChanges(BindingList<User> userList)
        {
            //TODO: check for deletions later
            foreach (User u in userList)
            {
                if (u.getTempStatus())
                {
                    u.setTempStatus(false);
                    userList.ResetBindings();
                }
            }
        }
    }
}
