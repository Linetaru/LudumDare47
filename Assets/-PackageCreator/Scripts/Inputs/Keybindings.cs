using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackageCreator.Inputs
{
    //[CreateAssetMenu(fileName = "Keybindings", menuName = "PackageCreator/Inputs/Keybindings")]
    public class Keybindings : ScriptableObject
    {

        // [Header("Movement")]
        // public KeyCode name;
        // private const string s_name = "name";

        ///<summary> 
        ///Return KeyCode of the key you want to check.
        ///</summary>
        public virtual KeyCode CheckKey(string key)
        {
            //switch(key)
            //{
            //    case "inputName":
            //        return inputName;
            //    default:
            //        return KeyCode.None;
            //}
            return KeyCode.None;
        }

        ///<summary> 
        ///Assign new Key in Keybinding Scriptable.
        ///</summary>
        public virtual void AssignNewKey(string key, KeyCode newKeyCode)
        {
            //switch(key)
            //{
            //    case "inputName":
            //          inputName = newKeyCode
            //        break;
            //
            //    default:
            //        break;
            //
            //}
        }
    }
}
