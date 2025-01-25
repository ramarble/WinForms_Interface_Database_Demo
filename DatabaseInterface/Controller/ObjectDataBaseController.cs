using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.View;

namespace DatabaseInterfaceDemo.Controller
{
    public class ObjectDataBaseController<T> where T : class

    {

        //I don't think I should ever use this constructor, but it works
        public ObjectDataBaseController(string primary_key)
        {
            PRIMARY_KEY = primary_key;
            OBJ_TYPE = Utils.TypeDictionary().FirstOrDefault(x => x.Value == primary_key).Key;

        }
        public ObjectDataBaseController(Type type)
        {
            PRIMARY_KEY = Utils.TypeDictionary()[type];
            OBJ_TYPE = type;
        }

        static Type OBJ_TYPE;
        static string tempStatus = "tempStatus";
        static string tempChar = "tempChar";
        static string PRIMARY_KEY;
        static List<object> ObjectBackupList = new List<object>();
        static BindingList<object> ObjectBindingList = new BindingList<object>();


        public Type GetDBObjectType()
        {
            return OBJ_TYPE;
        }

        public void SetObjectBindingList(List<object> list)
        {
            ObjectBindingList = new BindingList<object>(list);
        }
        public void SetObjectBindingList(BindingList<object> list)
        {
            ObjectBindingList = list;
            ObjectBindingList.ResetBindings();
        }

        public object getKey(object obj)
        {
            var result = obj.GetType().GetProperty(PRIMARY_KEY);
            return result.GetValue(obj);

        }

        //This works for now :D
        public Boolean IsObjectPresentInList(BindingList<object> listToParse, object ob1)
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

        public void AddObjectToList(BindingList<object> listToAppendTo, object userToAdd, Boolean editMode)
        {
            Type typeOfList = GetDBObjectType();
            MessageBox.Show(listToAppendTo.Count.ToString());
            //I'm pretty sure this part of code isn't needed in the current architecture
            /*
             * if (listToAppendTo.Count == 0)
            {
                typeOfList = userToAdd.GetType();
            }
            else
            {
                typeOfList = listToAppendTo[0].GetType();
            }
            */

            if (typeOfList == userToAdd.GetType())
            {
                //In any of these 3 cases the if will trigger

                if (listToAppendTo.Count == 0 || !IsObjectPresentInList(listToAppendTo, userToAdd) || editMode)
                 {
                    listToAppendTo.Add(userToAdd);
                    ObjectBindingList.ResetBindings();
                }
                else
                {
                    DialogResult d = LocalizationText.ERR_ObjPresent(PRIMARY_KEY, getKey(userToAdd).ToString());
                    d = DialogResult.None;
                }
            }
        }



        public BindingList<object> GetBindingList()
        {
            return ObjectBindingList;
        }

        public List<object> GetBackupList()
        {
            return ObjectBackupList;
        }

        public Boolean GetTempStatus(object ob)
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

        public void SetTempStatus(object ob, Boolean b)
        {
            var tempbool = ob.GetType().GetProperty(tempStatus);
            var tempchar = ob.GetType().GetProperty(tempChar);
            tempbool.SetValue(ob, b);
            char visualTempFlag = '\0';
            if (b)
            {
                visualTempFlag = '*';
            }
            tempchar.SetValue(ob, visualTempFlag);
        }

        public void TurnTempIntoPermanent(BindingList<object> list)
        {
            //TODO: check for deletions later

            foreach (object ob in list)
            {
                if (GetTempStatus(ob))
                {
                    GetBackupList().Remove(GetBackupList().Find(it => getKey(it) == getKey(it)));
                    SetTempStatus(ob, false);
                    list.ResetBindings();
                }
            }
        }

        public List<object> GetSlicedListWithTempUsers(BindingList<object> userList)
        {
            List<object> tempList = new List<object>();
            foreach (object ob in userList)
            {
                if (GetTempStatus(ob))
                {
                    tempList.Add(ob);
                }
            }
            return tempList;
        }

        public void restoreFromBackupAndEmptyBackup(BindingList<object> objectList)
        {
            List<object> tempUsers = GetSlicedListWithTempUsers(objectList);
            foreach (object utemp in tempUsers)
            {
                revertSingleObject(utemp, GetBindingList());
            }
            GetBackupList().Clear();
            GetBindingList().ResetBindings();
        }

        public object fetchUserByKey(List<object> listToSearch, object key)
        {
            return listToSearch.SingleOrDefault(ob => getKey(ob) == key);
        }

        public Boolean isObjectRevertable(object ob)
        {
            return !(fetchUserByKey(GetBackupList(), getKey(ob)) == null);
        }

        //I'm SHOCKED beyond relief that this worked first try.

        public void revertSingleObject(object objectToRevert, BindingList<object> listToUpdate)
        {
            if (isObjectRevertable(objectToRevert))
            {
                object sameUserInBackup = fetchUserByKey(GetBackupList(), getKey(objectToRevert));
                listToUpdate.Remove(objectToRevert);
                listToUpdate.Add(sameUserInBackup);
                GetBackupList().Remove(sameUserInBackup);
            }
            else
            {
                listToUpdate.Remove(objectToRevert);
            }

            listToUpdate.ResetBindings();

        }

        public void modifyObject(object objectToEdit, BindingList<object> objectList, Form SourceForm, ObjectDataBaseController<object> db)
        {
            GetBackupList().Add(objectToEdit);
            objectList.Remove(objectToEdit);

            //This form is the responsible for adding the new user to the list.
            FormUser f = new FormUser(SourceForm, objectToEdit, true, db);
            SourceForm.Hide();
            f.ShowDialog();


            //In case the form exited abruptly
            if (!objectList.Any(u => getKey(u) == getKey(objectToEdit)))
            {
                objectList.Add(objectToEdit);
                GetBackupList().Remove(objectToEdit);
                MessageBox.Show("Form exited without any changes");
            }

        }

        public void saveObject(object obj)
        {
            object sameObjectInBackup = fetchUserByKey(GetBackupList(), getKey(obj));
            GetBackupList().Remove(sameObjectInBackup);
            SetTempStatus(obj, false);
        }

        public Boolean isThereAnyTempUser()
        {
            return (GetBackupList().Count > 0 |
                (GetSlicedListWithTempUsers(GetBindingList()).Count > 0));
        }


        public void PreventClosingWithUncommittedChanges(FormClosingEventArgs e)
        {
            if (isThereAnyTempUser())
            {
                LocalizationText.WARN_UncommittedChanges();
                e.Cancel = true;
            }
        }

    }
}
