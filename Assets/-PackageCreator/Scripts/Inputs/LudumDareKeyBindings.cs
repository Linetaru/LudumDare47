using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackageCreator.Inputs
{
    [CreateAssetMenu(fileName = "LudumDareKeyBindings", menuName = "PackageCreator/Inputs/LudumDareKeyBindings")]
    public class LudumDareKeyBindings : Keybindings
    {
        [Header("Movement")]
        public KeyCode moveforward;
        private const string s_moveforward = "moveforward";
        public KeyCode moveback;
        private const string s_moveback = "moveback";
        public KeyCode moveleft;
        private const string s_moveleft = "moveleft";
        public KeyCode moveright;
        private const string s_moveright = "moveright";
        public KeyCode moveforward2;
        private const string s_moveforward2 = "moveforward2";
        public KeyCode moveleft2;
        private const string s_moveleft2 = "moveleft2";

        [Header("Special Movement")]
        public KeyCode walk;
        private const string s_walk = "walk";
        public KeyCode sprint;
        private const string s_sprint = "sprint";
        public KeyCode jump;
        private const string s_jump = "jump";

        [Header("UI")]
        public KeyCode pause;
        private const string s_pause = "pause";

        [Header("Interaction")]
        public KeyCode interact;
        private const string s_interact = "interact";

        public override KeyCode CheckKey(string key)
        {
            switch (key)
            {
                case s_moveforward:
                    return moveforward;

                case s_moveback:
                    return moveback;

                case s_moveleft:
                    return moveleft;

                case s_moveright:
                    return moveright;

                case s_moveforward2:
                    return moveforward2;

                case s_moveleft2:
                    return moveleft2;

                default:
                    return KeyCode.None;

            }
        }

        public override void AssignNewKey(string key, KeyCode newKeyCode)
        {
            switch (key)
            {
                case s_moveforward:
                    moveforward = newKeyCode;
                    break;

                default:
                    break;

            }
        }
    }
}
