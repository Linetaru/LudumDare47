using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackageCreator.Inputs
{
    [CreateAssetMenu(fileName = "RPGKeybindings", menuName = "PackageCreator/Inputs/RPGKeybindings")]
    public class RPGKeybindings : Keybindings
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

        [Header("Special Movement")]
        public KeyCode walk;
        private const string s_walk = "walk";
        public KeyCode sprint;
        private const string s_sprint = "sprint";
        public KeyCode jump;
        private const string s_jump = "jump";

        [Header("UI")]
        public KeyCode inventory;
        private const string s_inventory = "inventory";
        public KeyCode pause;
        private const string s_pause = "pause";

        [Header("Interaction")]
        public KeyCode interact;
        private const string s_interact = "interact";
        public KeyCode drop;
        private const string s_drop = "drop";
        public KeyCode attack;
        private const string s_attack = "attack";

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

                case s_walk:
                    return walk;

                case s_sprint:
                    return sprint;

                case s_jump:
                    return jump;

                case s_inventory:
                    return inventory;

                case s_pause:
                    return pause;

                case s_interact:
                    return interact;

                case s_drop:
                    return drop;

                case s_attack:
                    return attack;

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

                case s_moveback:
                    moveback = newKeyCode;
                    break;

                case s_moveleft:
                    moveleft = newKeyCode;
                    break;

                case s_moveright:
                    moveright = newKeyCode;
                    break;

                case s_walk:
                    walk = newKeyCode;
                    break;

                case s_sprint:
                    sprint = newKeyCode;
                    break;

                case s_jump:
                    jump = newKeyCode;
                    break;

                case s_inventory:
                    inventory = newKeyCode;
                    break;

                case s_pause:
                    pause = newKeyCode;
                    break;

                case s_interact:
                    interact = newKeyCode;
                    break;

                case s_drop:
                    drop = newKeyCode;
                    break;

                case s_attack:
                    attack = newKeyCode;
                    break;

                default:
                    break;

            }
        }
    }
}
