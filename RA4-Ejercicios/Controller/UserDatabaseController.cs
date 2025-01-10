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
using RA4_Ejercicios.View;

namespace RA4_Ejercicios.Controller
{
    public static class UserDatabaseController
    {
        static List<User> UsersBackupList = new List<User>();
        static List<User> userList = createUserList();
        static BindingList<User> userBindingList = new BindingList<User>(userList);
        private static List<User> createUserList() 
        {
            List<User> userList = new List<User>();
            String[] listaNombres = { "Mrsha", "Lyonette", "Numbtongue", "Erin", "Bird"};
            String[] listaApellido1 = { "du", "du", "Redfang", "Summer", "" };
            String[] listaApellido2 = { "Marquin", "Marquin", "Solstice", "Solstice", "" };
            decimal[] listaSalarios = { 1332.30m, 11234.68m, 1134.7m, 1222.66m, 10.80m };
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
                    listaSalarios[i],
                    listaFechasNacimiento[i],
                    listaNIF[i]));
        }

            //TODO: Maybe move this somewhere else
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
        public static Boolean isNIFPresentInList(List<User> userList, int nif)
        {
            foreach (User user in userList)
            {
                if (user.getNif().Equals(nif))
                {
                    return true;
                }

            }
            return false;
        }

        public static void userReceived(object sender, EventSendUser e)
        {
            addUserToList(getUserList(), e.getUsuario(), e.getEditMode());
        }


        public static void addUserToList(List<User> listToAppendTo, User userToAdd, Boolean editMode)
        {
            if (!isNIFPresentInList(listToAppendTo, userToAdd) | editMode)
            {
                listToAppendTo.Add(userToAdd);
                userBindingList.ResetBindings();
            }
            else
            {
                //this should NEVER trigger
                DialogResult d = MessageBox.Show("Ya hay un usuario con ese NIF presente.");
                d = DialogResult.None;
            }
        }

        public static BindingList<User> getUserBindingList()
        {
            return userBindingList;
        }

        public static List<User> getUsersBackupList()
        {
            return UsersBackupList;
        }
        public static List<User> getUserList()
        {
            return userList;
        }

        public static void TurnTempUsersIntoPermanent(List<User> userList)
        {
            //TODO: check for deletions later

            foreach (User u in userList)
            {
                if (u.getTempStatus())
                {
                    getUsersBackupList().Remove(getUsersBackupList().Find(it => it.nif == u.nif));
                    u.setTempStatus(false);
                    userBindingList.ResetBindings();
                }
            }
        }

        public static List<User> getSlicedListWithTempUsers(List<User> userList)
        {
            List<User> tempUsers = new List<User>();
            foreach (User u in userList)
            {
                if (u.getTempStatus())
                {
                    tempUsers.Add(u);
                }
            }
            return tempUsers;
        }

        public static void restoreAllUsersFromBackupAndEmptyBackup(List<User> userList)
        {
            List<User> tempUsers = getSlicedListWithTempUsers(userList);
            foreach (User utemp in tempUsers)
            {
                foreach (User backup in getUsersBackupList())
                {
                    if (utemp.nif == backup.nif)
                    {
                        userList.Remove(utemp);
                        userList.Add(backup);
                    }
                }
            }
            getUsersBackupList().Clear();
            getUserBindingList().ResetBindings();
        }

        public static User fetchUserByNIF(List<User> listToSearch, int nifKey)
        {
            return listToSearch.Find(u => u.nif == nifKey);
        }

        public static void revertSingleUser(User userToRevert, BindingList<User> listToUpdate)
        {
            User sameUserInBackup = fetchUserByNIF(getUsersBackupList(), userToRevert.nif);
            listToUpdate.Remove(userToRevert);
            listToUpdate.Add(sameUserInBackup);
            getUsersBackupList().Remove(sameUserInBackup);

        }

        public static void modifyUser(User userToEdit, BindingList<User> userList, Form SourceForm)
        {
            getUsersBackupList().Add(userToEdit);
            userList.Remove(userToEdit);

            //This form is the responsible for adding the new user to the list.
            FormUser f = new FormUser(SourceForm, userToEdit, true);
            SourceForm.Hide();
            f.ShowDialog();


            //In case the form exited abruptly
            if (!userList.Any(u => u.nif == userToEdit.nif))
            {
                userList.Add(userToEdit);
                getUsersBackupList().Remove(userToEdit);
                MessageBox.Show("Form exited without any changes");
            }

        }

        public static void saveUser(User user)
        {
            User sameUserInBackup = fetchUserByNIF(getUsersBackupList(), user.nif);
            getUsersBackupList().Remove(sameUserInBackup);
            user.setTempStatus(false);
        }
    }
}
