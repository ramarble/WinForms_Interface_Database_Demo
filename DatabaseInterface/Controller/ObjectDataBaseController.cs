using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using DatabaseInterface.View;

namespace DatabaseInterface.Controller
{
    public class ObjectDataBaseController<T> where T : class

    {
        public ObjectDataBaseController(Type objType, string primary_key, string tempKey)
        {
            objectReferenceType = objType;
            PRIMARY_KEY = primary_key;
            tempStatus = tempKey;
        }

        static Type objectReferenceType;
        static string tempStatus;
        static string PRIMARY_KEY;
        static List<object> ObjectBackupList = new List<object>();
        static BindingList<object> ObjectBindingList = new BindingList<object>();


        public void setObjectBindingList(List<object> list)
        {
            ObjectBindingList = new BindingList<object>(list);
        }
        public void setObjectBindingList(BindingList<object> list)
        {
            ObjectBindingList = list;
        }

        public List<T> createUserList(object obj)
        {
            List<T> objectList = new List<T>();
            return objectList;
        }

        public object getKey(object obj)
        {
            var result = obj.GetType().GetProperty(PRIMARY_KEY);
            return result.GetValue(obj);

        }


        public void turnIntoXMLFile(List<object> lista)
        {

            XmlSerializer serializer = new XmlSerializer(lista.GetType());
            using (StreamWriter writer = new StreamWriter("../../Data/listaUsuarios.xml"))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, lista, ns);
            }
        }


        //This works for now :D
        public Boolean isObjectPresentInList(BindingList<object> listToParse, object ob1)
        {
            foreach (object ob2 in listToParse)
            {
                if (getKey(ob2).Equals(getKey(ob1)))
                {
                    return true;
                }

            }
            return false;
        }

        public void addObjectToList(BindingList<object> listToAppendTo, object userToAdd, Boolean editMode)
        {
            if (listToAppendTo.Count > 0)
            {
                if (listToAppendTo[0].GetType() == userToAdd.GetType())
                {
                    
                    if (!isObjectPresentInList(listToAppendTo, userToAdd) | editMode)
                    {
                        listToAppendTo.Add((T)userToAdd);
                        ObjectBindingList.ResetBindings();
                    }
                    else
                    {
                        DialogResult d = MessageBox.Show("Ya hay un usuario con ese NIF presente.");
                        d = DialogResult.None;
                    }
                }

            }
        }

        public BindingList<object> getBindingList()
        {
            return ObjectBindingList;
        }

        public List<object> getBackupList()
        {
            return ObjectBackupList;
        }


        public Boolean getTempStatus(object ob)
        {
            Boolean b = (Boolean) ob.GetType().GetProperty("tempStatus").GetValue(ob);

            if (b == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void setTempStatus(object ob, Boolean b)
        {
            var prop = ob.GetType().GetProperty(tempStatus);
            prop.SetValue(ob, b);
        }

        public void TurnTempIntoPermanent(BindingList<object> list)
        {
            //TODO: check for deletions later

            foreach (object ob in list)
            {
                if (getTempStatus(ob))
                {
                    getBackupList().Remove(getBackupList().Find(it => getKey(it) == getKey(it)));
                    setTempStatus(ob, false);
                    ObjectBindingList.ResetBindings();
                }
            }
        }

        public List<object> getSlicedListWithTempUsers(BindingList<object> userList)
        {
            List<object> tempList = new List<object>();
            foreach (object ob in userList)
            {
                if (getTempStatus(ob))
                {
                    tempList.Add(ob);
                }
            }
            return tempList;
        }

        public void restoreFromBackupAndEmptyBackup(BindingList<object> objectList)
        {
            List<object> tempUsers = getSlicedListWithTempUsers(objectList);
            foreach (object utemp in tempUsers)
            {
                revertSingleObject(utemp, getBindingList());
            }
            getBackupList().Clear();
            getBindingList().ResetBindings();
        }

        public object fetchUserByKey(List<object> listToSearch, object key)
        {
            return listToSearch.SingleOrDefault(ob => getKey(ob) == key);
        }

        public Boolean isObjectRevertable(object ob)
        {
            return !(fetchUserByKey(getBackupList(), getKey(ob)) == null);
        }

        //I'm SHOCKED beyond relief that this worked first try.

        public void revertSingleObject(object objectToRevert, BindingList<object> listToUpdate)
        {
            if (isObjectRevertable(objectToRevert))
            {
                object sameUserInBackup = fetchUserByKey(getBackupList(), getKey(objectToRevert));
                listToUpdate.Remove(objectToRevert);
                listToUpdate.Add(sameUserInBackup);
                getBackupList().Remove(sameUserInBackup);
            }
            else
            {
                listToUpdate.Remove(objectToRevert);
            }

            listToUpdate.ResetBindings();

        }

        public void modifyObject(object objectToEdit, BindingList<object> objectList, Form SourceForm, ObjectDataBaseController<object> db)
        {
            getBackupList().Add(objectToEdit);
            objectList.Remove(objectToEdit);

            //This form is the responsible for adding the new user to the list.
            FormUser f = new FormUser(SourceForm, objectToEdit, true, db);
            SourceForm.Hide();
            f.ShowDialog();


            //In case the form exited abruptly
            if (!objectList.Any(u => getKey(u) == getKey(objectToEdit)))
            {
                objectList.Add(objectToEdit);
                getBackupList().Remove(objectToEdit);
                MessageBox.Show("Form exited without any changes");
            }

        }

        public void saveObject(object obj)
        {
            object sameObjectInBackup = fetchUserByKey(getBackupList(), getKey(obj));
            getBackupList().Remove(sameObjectInBackup);
            setTempStatus(obj, false);
        }

        public Boolean isThereAnyTempUser()
        {
            return (getBackupList().Count > 0 |
                (getSlicedListWithTempUsers(getBindingList()).Count > 0));
        }


        public void preventClosingWithUncommittedChanges(FormClosingEventArgs e)
        {
            if (isThereAnyTempUser())
            {
                DialogBoxes.WARN_UncommittedChanges();
                e.Cancel = true;
            }
        }

    }
}
