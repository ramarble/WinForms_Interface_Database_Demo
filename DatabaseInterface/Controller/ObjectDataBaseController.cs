using DatabaseInterfaceDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.Controller
{
    /// <summary>
    /// Controller for every object handled during program execution, this mimics a database interface while being loaded entirely in memory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectDataBaseController<T> where T : class

    {

        /// <summary>
        /// !!!Unused, functional constructor!!! Instantiates a DataBaseController using Reflection based on its Primary Key by checking it against a Type Dictionary found in <see cref="FormUtils"/>
        /// </summary>
        /// <param name="primary_key"></param>
        public ObjectDataBaseController(string primary_key)
        {
            PRIMARY_KEY = primary_key;
            OBJ_TYPE = FormUtils.TypeDictionary().FirstOrDefault(x => x.Value == primary_key).Key;
        }


        /// <summary>
        /// Instantiates a DataBaseController based on its type by checking it against a Type Dictionary found in <see cref="FormUtils"/>
        /// </summary>
        /// <param name="type"></param>
        public ObjectDataBaseController(Type type)
        {
            PRIMARY_KEY = FormUtils.TypeDictionary()[type];
            OBJ_TYPE = type;
        }

        static Type OBJ_TYPE;
        static readonly string TempStatus = "TempStatus";
        static readonly string TempChar = "TempChar";
        static string PRIMARY_KEY;
        static readonly BindingList<object> ObjectBackupList = new BindingList<object>();
        static BindingList<object> ObjectBindingList = new BindingList<object>();

        /// <summary>
        /// Returns the <see cref="Type"/> handled by the ObjectDatabaseController instance
        /// </summary>
        /// <returns></returns>
        public Type GetDBObjectType()
        {
            return OBJ_TYPE;
        }

        /// <summary>
        /// Updates and overwrites the <see cref="ObjectBindingList"/> handled.
        /// </summary>
        /// <param name="list">List that will overwrite the current <see cref="ObjectBindingList"/></param>
        public void SetObjectBindingList(List<object> list)
        {
            ObjectBindingList = new BindingList<object>(list);
        }

        /// <summary>
        /// Updates and overwrites the <see cref="ObjectBindingList"/> handled.
        /// </summary>
        /// <param name="list">List that will overwrite the current <see cref="ObjectBindingList"/></param>
        public void SetObjectBindingList(BindingList<object> list)
        {
            ObjectBindingList = list;
            ObjectBindingList.ResetBindings();
        }
        /// <summary>
        /// Gets the primary key of an object, could be re-factored outside of this file.
        /// The object must have a parameter called "PRIMARY_KEY", which should be the case if it's a Child of <see cref="BASE_DATABASE_OBJECT"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object GetPrimaryKey(object obj)
        {
            var result = obj.GetType().GetProperty(PRIMARY_KEY);
            return result.GetValue(obj);

        }

        /// <summary>
        /// Gets the TempStatus value of an object, could be re-factored outside of this file.
        /// The object must have a parameter called "TempStatus", which should be the case if it's a Child of <see cref="BASE_DATABASE_OBJECT"/>
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public Boolean GetTempStatus(object ob)
        {
            Boolean b = (Boolean)ob.GetType().GetProperty("TempStatus").GetValue(ob);

            if (b == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the TempStatus and TempChar value of an object
        /// The object must have a parameter called "TempStatus", which should be the case if it's a Child of <see cref="BASE_DATABASE_OBJECT"/>
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="b"></param>
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

        /// <summary>
        /// Attempts to find an object in a BindingList. Could be re-factored outside of this file.
        /// </summary>
        /// <param name="listToParse"></param>
        /// <param name="ob1"></param>
        /// <returns>true if present, false otherwise</returns>
        public Boolean IsObjectPresentInList(BindingList<object> listToParse, object ob1)
        {
            foreach (object ob2 in listToParse)
            {
                if (GetPrimaryKey(ob2).Equals(GetPrimaryKey(ob1)))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Attempts to add an object to a BindingList. The object will be added if the object isn't found in the list or if the object is being added as an addition through editMode.
        /// </summary>
        /// <param name="listToAppendTo"></param>
        /// <param name="userToAdd"></param>
        /// <param name="editMode"></param>
        /// <returns>true if the object was added, false otherwise</returns>
        /// <exception cref="ArrayTypeMismatchException">Thrown if the object added is of a different type as the BindingList</exception>
        public Boolean AddObjectToList(BindingList<object> listToAppendTo, object userToAdd, Boolean editMode)
        {
            Type typeOfList = GetDBObjectType();

            if (typeOfList == userToAdd.GetType())
            {
                //In any of these 2 cases the if will trigger

                if (!IsObjectPresentInList(listToAppendTo, userToAdd) || editMode)
                 {
                    listToAppendTo.Add(userToAdd);
                    ObjectBindingList.ResetBindings();
                    return true;
                }
                else
                {
                    DialogResult d = Lang.LangClass.ERR_ObjPresent(PRIMARY_KEY, GetPrimaryKey(userToAdd).ToString());
                    d = DialogResult.None;
                    return false;
                }
            }
            throw new ArrayTypeMismatchException("The Database and Object added were not of the same type.");
        }

        /// <summary>
        /// Returns the BindingList being used in the current <see cref="ObjectDataBaseController{T}"/> instance
        /// </summary>
        /// <returns></returns>
        public BindingList<object> GetBindingList()
        {
            return ObjectBindingList;
        }

        /// <summary>
        /// Returns the BindingList that contains the current uncommitted changes as a backup in the current <see cref="ObjectDataBaseController{T}"/> instance
        /// </summary>
        /// <returns></returns>
        public BindingList<object> GetBackupList()
        {
            return ObjectBackupList;
        }


        /// <summary>
        /// Turns an object's TempStatus and TempChar values to false and removes the backup from the BackupList.
        /// The object must have a parameter called "TempStatus" which should be the case if it's a Child of <see cref="BASE_DATABASE_OBJECT"/>
        /// </summary>
        /// <param name="list"></param>
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

        /// <summary>
        /// Returns a list of every user found in the BindingList userList that has TempStatus set to true
        /// </summary>
        /// <param name="userList"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Reverts every object to their own instance as found in the backup list. The backup is then cleared.
        /// </summary>
        /// <param name="objectList"></param>
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

        /// <summary>
        /// Returns an object by its PRIMARY_KEY value
        /// </summary>
        /// <param name="listToSearch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public object FetchObjectByKey(BindingList<object> listToSearch, object key)
        {
            if (listToSearch.Count > 0)
            {
                return listToSearch.First(ob => GetPrimaryKey(ob).Equals(key));
            }
            return null;
        }

        /// <summary>
        /// Returns if the object is present (As represented by its PRIMARY_KEY) in the BackupList
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public Boolean IsObjectInBackupList(object ob)
        {
            return !(FetchObjectByKey(GetBackupList(), GetPrimaryKey(ob)) == null);
        }

        /// <summary>
        /// Reverts a single object by fetching its backup from the backup List as matched by its PRIMARY_KEY
        /// </summary>
        /// <param name="objectToRevert"></param>
        public void RevertSingleObject(object objectToRevert)
        {
            if (IsObjectInBackupList(objectToRevert))
            {
                object sameUserInBackup = FetchObjectByKey(GetBackupList(), GetPrimaryKey(objectToRevert));
                
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

        /// <summary>
        /// Initiates a Form editForm to edit the values of an Object 
        /// </summary>
        /// <param name="objectToEdit"></param>
        /// <param name="SourceForm"></param>
        /// <param name="editForm"></param>
        /// <param name="db"></param>
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
        
        /// <summary>
        /// Saves an object to the Primary List, removes its backup and sets its TempStatus to false.
        /// </summary>
        /// <param name="obj"></param>
        public void SaveObject(object obj)
        {
            if (IsObjectInBackupList(obj))
            {
                object sameObjectInBackup = FetchObjectByKey(GetBackupList(), GetPrimaryKey(obj));
                GetBackupList().Remove(sameObjectInBackup);
            }
            SetTempStatus(obj, false);
        }

        /// <summary>
        /// Returns whether there is any user with the flag TempStatus set to True or if there is any user present in the backup
        /// </summary>
        /// <returns>true if there is any user with TempStatus set to true or if there is any user in the backup list</returns>
        public Boolean IsThereAnyTempUser()
        {
            return (GetBackupList().Count > 0 |
                (GetSlicedListWithTempUsers(GetBindingList()).Count > 0));
        }

        /// <summary>
        /// Prevents closing the form with uncommitted changes.
        /// </summary>
        /// <param name="e"></param>
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
