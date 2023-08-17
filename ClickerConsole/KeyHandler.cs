using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class KeyHandler {

        public const ConsoleKey PressKey = ConsoleKey.N;
        public const ConsoleKey UpgradesKey = ConsoleKey.U;
        public const ConsoleKey RebirthDialogKey = ConsoleKey.R;
        public const ConsoleKey RebirthKey = ConsoleKey.C;

        public const ConsoleKey Upgrade1 = ConsoleKey.D1;
        public const ConsoleKey Upgrade2 = ConsoleKey.D2;
        public const ConsoleKey Upgrade3 = ConsoleKey.D3;
        public const ConsoleKey Upgrade4 = ConsoleKey.D4;

        public delegate void KeyAction();
        public Dictionary<KeyType, KeyAction> KeyActions;


        public delegate void UpgradeKeyAction();
        public Dictionary<UpgradeKeyType, UpgradeKeyAction> UpgradeKeyActions;

        public KeyHandler() { 
            KeyActions = new Dictionary<KeyType, KeyAction>();
            UpgradeKeyActions = new Dictionary<UpgradeKeyType, UpgradeKeyAction>();

            initKeyActions();
            initUpgradeKeyActions();
        }

        private void initKeyActions() {
            KeyActions.Add(KeyType.Press, null);
            KeyActions.Add(KeyType.UpgradesDialog, null);
            KeyActions.Add(KeyType.RebirthDialog, null);
            KeyActions.Add(KeyType.Rebirth, null);
            KeyActions.Add(KeyType.None, null);
        }

        private void initUpgradeKeyActions() {
            UpgradeKeyActions.Add(UpgradeKeyType.Upgrade1, null);
            UpgradeKeyActions.Add(UpgradeKeyType.Upgrade2, null);
            UpgradeKeyActions.Add(UpgradeKeyType.Upgrade3, null);
            UpgradeKeyActions.Add(UpgradeKeyType.Upgrade4, null);
            UpgradeKeyActions.Add(UpgradeKeyType.None, null);
        }

        public KeyType GetKey(ConsoleKey key) {
            switch (key) {
                case PressKey:
                    return KeyType.Press;
                case UpgradesKey:
                    return KeyType.UpgradesDialog;
                case RebirthDialogKey:
                    return KeyType.RebirthDialog;
                case RebirthKey:
                    return KeyType.Rebirth;

                default:
                    return KeyType.None;
            }
        }

        public UpgradeKeyType GetUpgradeKey(ConsoleKey key) {
            switch (key) {
                case Upgrade1:
                    return UpgradeKeyType.Upgrade1;
                case Upgrade2:
                    return UpgradeKeyType.Upgrade2;
                case Upgrade3:
                    return UpgradeKeyType.Upgrade3;
                case Upgrade4:
                    return UpgradeKeyType.Upgrade4;

                default:
                    return UpgradeKeyType.None;
            }
        }
    }

    enum KeyType {
        None,
        Press,
        UpgradesDialog,
        RebirthDialog,
        Rebirth
    }

    enum UpgradeKeyType {
        None,
        Upgrade1,
        Upgrade2,
        Upgrade3,
        Upgrade4
    }
}


