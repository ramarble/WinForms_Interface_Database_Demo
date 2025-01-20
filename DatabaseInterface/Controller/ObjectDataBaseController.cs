using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using DatabaseInterface.Model;
using DatabaseInterface.View;

namespace DatabaseInterface.Controller
{
    public abstract class ObjectDataBaseController<T> where T : class

    {
        public ObjectDataBaseController(T obj, string primary_key)
        {
            objectReference = obj;
            PRIMARY_KEY = obj.GetType().GetProperty(primary_key);
            temp = obj.GetType().GetProperty("temp");
        }

        static object objectReference;
        static PropertyInfo temp;
        static PropertyInfo PRIMARY_KEY;
        static List<T> ObjectList = new List<T>();
        static List<T> ObjectBackupList = new List<T>();
        static BindingList<T> ObjectBindingList = new BindingList<T>();


        public static List<T> createUserList<T>(object obj)
        {

            List<T> objectList = new List<T>();
            return objectList;
        }
        
        public static object getKey(object obj)
        {
            for (int i = 0; i < obj.GetType().GetProperties().Length; i++)
            {
                if(Type.Equals(obj.GetType().GetProperties()[i].PropertyType, PRIMARY_KEY))
                {
                    return obj.GetType();
                }
            }
            return null;
        }

        public static void turnIntoXMLFile<T>(List<T> lista)
        {

            XmlSerializer serializer = new XmlSerializer(lista.GetType());
            using (StreamWriter writer = new StreamWriter("../../Data/listaUsuarios.xml"))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, lista, ns);
            }
        }

        public static Boolean isKEYPresentInList(List<T> listToParse, object ob1)
        {
            foreach (T ob2 in listToParse)
            {
                if (getKey(ob2).Equals(getKey(ob1)))
                {
                    return true;
                }

            }
            return false;
        }

        public static void userReceived<T>(object sender, EventSendObject<object> e)
        {
            addUserToList(getList(), e.getObject(), e.getEditMode());
        }


        public static void addUserToList(List<T> listToAppendTo, object userToAdd, Boolean editMode)
        {
            if (listToAppendTo.Count > 0)
            {

                if (listToAppendTo[0].GetType() == userToAdd.GetType())
                {
                    if (!isKEYPresentInList(listToAppendTo, userToAdd) | editMode)
                    {
                        listToAppendTo.Add((T)userToAdd);
                        ObjectBindingList.ResetBindings();
                    }
                    else
                    {
                        //this should NEVER trigger
                        DialogResult d = MessageBox.Show("Ya hay un usuario con ese NIF presente.");
                        d = DialogResult.None;
                    }
                }

            }
        }

        public static BindingList<T> getBindingList()
        {
            return ObjectBindingList;
        }

        public static List<T> getBackupList()
        {
            return ObjectBackupList;
        }
        public static List<T> getList()
        {
            return ObjectList;
        }

        public static void getTempStatus(object ob)
        {
            if (ob.GetType().getT)
        }

        public static void TurnTempIntoPermanent(List<T> list)
        {
            //TODO: check for deletions later

            foreach (T u in list)
            {
                if (u.getTempStatus())
                {
                    getBackupList().Remove(getBackupList().Find(it => getKey(it) == getKey(it)));
                    u.setTempStatus(false);
                    ObjectBindingList.ResetBindings();
                }
            }
        }

        public static List<Empleado> getSlicedListWithTempUsers(List<Empleado> userList)
        {
            List<Empleado> tempUsers = new List<Empleado>();
            foreach (Empleado u in userList)
            {
                if (u.getTempStatus())
                {
                    tempUsers.Add(u);
                }
            }
            return tempUsers;
        }

        public static void restoreAllUsersFromBackupAndEmptyBackup(List<Empleado> userList)
        {
            List<Empleado> tempUsers = getSlicedListWithTempUsers(userList);
            foreach (Empleado utemp in tempUsers)
            {
                revertSingleUser(utemp, getUserBindingList());
            }
            getUsersBackupList().Clear();
            getUserBindingList().ResetBindings();
        }

        public static Empleado fetchUserByNIF(List<Empleado> listToSearch, int nifKey)
        {
            return listToSearch.Find(u => u.nif == nifKey);
        }

        public static Boolean isUserRevertable(Empleado user)
        {
            return !(fetchUserByNIF(getUsersBackupList(), user.nif) == null);
        }

        //I'm SHOCKED beyond relief that this worked first try.

        public static void revertSingleUser(Empleado userToRevert, BindingList<Empleado> listToUpdate)
        {
            if (isUserRevertable(userToRevert))
            {
                Empleado sameUserInBackup = fetchUserByNIF(getUsersBackupList(), userToRevert.nif);
                listToUpdate.Remove(userToRevert);
                listToUpdate.Add(sameUserInBackup);
                getUsersBackupList().Remove(sameUserInBackup);
            }
            else
            {
                listToUpdate.Remove(userToRevert);
            }

            listToUpdate.ResetBindings();

        }

        public static void modifyUser(Empleado userToEdit, BindingList<Empleado> userList, Form SourceForm)
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

        public static void saveUser(Empleado user)
        {
            Empleado sameUserInBackup = fetchUserByNIF(getUsersBackupList(), user.nif);
            getUsersBackupList().Remove(sameUserInBackup);
            user.setTempStatus(false);
        }
    }
}
