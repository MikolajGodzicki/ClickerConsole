using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class KeyHandler {

        public const ConsoleKey PressKey = ConsoleKey.N;
        public const ConsoleKey UpgradesKey = ConsoleKey.U;
        public const ConsoleKey RebirthKey = ConsoleKey.R;

        public delegate void KeyAction();

        public Dictionary<KeyType, KeyAction> KeyActions;

        public KeyHandler() { 
            KeyActions = new Dictionary<KeyType, KeyAction>();

            initKeyActions();
        }

        private void initKeyActions() {
            KeyActions.Add(KeyType.Press, null);
            KeyActions.Add(KeyType.Upgrades, null);
            KeyActions.Add(KeyType.Rebirth, null);
            KeyActions.Add(KeyType.None, null);
        }

        public KeyType GetKey(ConsoleKey key) {
            switch (key) {
                case PressKey:
                    return KeyType.Press;
                case UpgradesKey:
                    return KeyType.Upgrades;
                case RebirthKey:
                    return KeyType.Rebirth;

                default:
                    return KeyType.None;
            }
        }


    }

    enum KeyType {
        None,
        Press,
        Upgrades,
        Rebirth
    }
}


