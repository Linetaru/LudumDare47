using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackageCreator.Inputs
{
    public class InputManager : MonoBehaviour
    {
        [Header("InputManager settings")]
        public static InputManager instance;

        public Keybindings keybindings;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != null)
                Destroy(this);

            DontDestroyOnLoad(this);
        }
        
        ///<summary> 
        ///Return true if the frame of input down is same at the input keyCode you wanted. 
        ///</summary>
        public bool GetKeydown(string key)
        {
            //Check for key

            if (Input.GetKeyDown(keybindings.CheckKey(key)))
                return true;
            else
                return false;
        }

        ///<summary> 
        ///Return true if the input down is same at the input keyCode you wanted. 
        ///</summary>
        public bool GetKey(string key)
        {
            if (Input.GetKey(keybindings.CheckKey(key)))
                return true;
            else
                return false;
        }

        ///<summary> 
        ///Return true if the frame of input Up is same at the input keyCode you wanted. 
        ///</summary>
        public bool GetKeyUp(string key)
        {
            if (Input.GetKeyUp(keybindings.CheckKey(key)))
                return true;
            else
                return false;
        }

        public void SetNewKey(string key, KeyCode newKey)
        {
            keybindings.AssignNewKey(key, newKey);
        }
    }
}
