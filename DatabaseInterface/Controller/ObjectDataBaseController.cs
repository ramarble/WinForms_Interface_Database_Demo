using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Lang;
using DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.View.ObjectCreationForms;

namespace DatabaseInterfaceDemo.Controller
{
    public class ObjectDataBaseController<T> where T : class

    {

        //I don't think I should ever use this constructor, but it works
        public ObjectDataBaseController(string primary_key)
        {
            PRIMARY_KEY = primary_key;
            OBJ_TYPE = FormUtils.TypeDictionary().FirstOrDefault(x => x.Value == primary_key).Key;
        }

        
        public ObjectDataBaseController(Type type)
        {
            PRIMARY_KEY = FormUtils.TypeDictionary()[type];
            OBJ_TYPE = type;
        }

        static Type OBJ_TYPE;
        static readonly string TempStatus = "TempStatus";
        static readonly string TempChar = "TempChar";
        static string PRIMARY_KEY;
        static BindingList<object> ObjectBackupList = new BindingList<object>();
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

        public object GetKey(object obj)
        {
            var result = obj.GetType().GetProperty(PRIMARY_KEY);
            return result.GetValue(obj);

        }

        //This works for now :D
        public Boolean IsObjectPresentInList(BindingList<object> listToParse, object ob1)
        {
            foreach (object ob2 in listToParse)
            {
                if (GetKey(ob2).Equals(GetKey(ob1)))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean AddObjectToList(BindingList<object> listToAppendTo, object userToAdd, Boolean editMode)
        {
            Type typeOfList = GetDBObjectType();

            if (typeOfList == userToAdd.GetType())
            {
                //In any of these 3 cases the if will trigger

                if (!IsObjectPresentInList(listToAppendTo, userToAdd) || editMode)
                 {
                    listToAppendTo.Add(userToAdd);
                    ObjectBindingList.ResetBindings();
                    return true;
                }
                else
                {
                    DialogResult d = Lang.LangClass.ERR_ObjPresent(PRIMARY_KEY, GetKey(userToAdd).ToString());
                    d = DialogResult.None;
                    return false;
                }
            }
            throw new Exception("The Database and Object added were not of the same type.");
        }



        public BindingList<object> GetBindingList()
        {
            return ObjectBindingList;
        }

        public BindingList<object> GetBackupList()
        {
            return ObjectBackupList;
        }

        public Boolean GetTempStatus(object ob)
        {
            Boolean b = (Boolean) ob.GetType().GetProperty("TempStatus").GetValue(ob);

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
            var tempbool = ob.GetType().GetProperty(TempStatus);
            var tempchar = ob.GetType().GetProperty(TempChar);
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

            foreach (object ob in list)
            {
                if (GetTempStatus(ob))
                { 
                    GetBackupList().Remove(ob);    
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

        public void RestoreFromBackupAndEmptyBackup(BindingList<object> objectList)
        {
            List<object> tempUsers = GetSlicedListWithTempUsers(objectList);
            foreach (object utemp in tempUsers)
            {
                RevertSingleObject(utemp);
            }
            GetBackupList().Clear();
            GetBindingList().ResetBindings();
        }

        public object FetchUserByKey(BindingList<object> listToSearch, object key)
        {
            if (listToSearch.Count > 0)
            {
                return listToSearch.First(ob => GetKey(ob).Equals(key));
            }
            return null;
        }

        public Boolean IsObjectInBackupList(object ob)
        {
            return !(FetchUserByKey(GetBackupList(), GetKey(ob)) == null);
        }

        //I'm SHOCKED beyond relief that this worked first try.
        //I'm also not shocked it stopped working 3 days later

        public void RevertSingleObject(object objectToRevert)
        {
            if (IsObjectInBackupList(objectToRevert))
            {
                object sameUserInBackup = FetchUserByKey(GetBackupList(), GetKey(objectToRevert));
                
                GetBindingList().Remove(objectToRevert);
                GetBindingList().Add(sameUserInBackup);
                GetBackupList().Remove(sameUserInBackup);
            }
            else
            {
                GetBindingList().Remove(objectToRevert);
            }

            GetBindingList().ResetBindings();

        }

        public void ModifyObject(object objectToEdit, Form SourceForm, Form editForm, ObjectDataBaseController<object> db)
        {
            db.GetBackupList().Add(objectToEdit);

            db.GetBindingList().Remove(objectToEdit);

            //This form is the responsible for adding the new user to the list.
            
            editForm.ShowDialog();


            //In case the form exited abruptly
            if (!IsObjectPresentInList(db.GetBindingList(), objectToEdit))
            {
                db.GetBindingList().Add(objectToEdit);
                db.GetBackupList().Remove(objectToEdit);
                MessageBox.Show("Form exited without any changes MOVE THIS TO THE LOCALIZATION FILE");
            }

        }

        public void SaveObject(object obj)
        {
            if (IsObjectInBackupList(obj))
            {
                object sameObjectInBackup = FetchUserByKey(GetBackupList(), GetKey(obj));
                GetBackupList().Remove(sameObjectInBackup);
            }
            SetTempStatus(obj, false);
        }

        public Boolean IsThereAnyTempUser()
        {
            return (GetBackupList().Count > 0 |
                (GetSlicedListWithTempUsers(GetBindingList()).Count > 0));
        }


        public void PreventClosingWithUncommittedChanges(FormClosingEventArgs e)
        {
            if (IsThereAnyTempUser())
            {
                Lang.LangClass.WARN_UncommittedChanges();
                e.Cancel = true;
            }
        }

    }
}
