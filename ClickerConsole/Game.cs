using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class Game {
        private KeyHandler _keyHandler;

        private bool UpgradesDialog;
        private bool RebirthDialog;

        private RebirthDialog _rebirthDialog;
        private UpgradesDialog _upgradesDialog;


        public Game() {
            /*
            ContinueText("Welcome! This is very simple clicker console game!");
            ContinueText("You need to click setted click in options to gain points!");
            ContinueText("Buy upgrades to get more points per click.");
            ContinueText("Make rebirths to get more and more multiplier!");
            */

            _keyHandler = new KeyHandler();

            _rebirthDialog = new RebirthDialog(60, 10);
            _upgradesDialog = new UpgradesDialog(60, 5);

            init();
            MainLoop();
        }
        private void init() {
            UpgradesDialog = false;
            RebirthDialog = false;

            _keyHandler.KeyActions[KeyType.Press] = PointManager.Instance.AddPoint;
            _keyHandler.KeyActions[KeyType.UpgradesDialog] = ToggleUpgradesDialog;
            _keyHandler.KeyActions[KeyType.RebirthDialog] = ToggleRebirthDialog;
            _keyHandler.KeyActions[KeyType.Rebirth] = PointManager.Instance.Rebirth;

            _keyHandler.UpgradeKeyActions[UpgradeKeyType.Upgrade1] = () => PointManager.Instance.BuyUpgrade(0);
            _keyHandler.UpgradeKeyActions[UpgradeKeyType.Upgrade2] = () => PointManager.Instance.BuyUpgrade(1);
            _keyHandler.UpgradeKeyActions[UpgradeKeyType.Upgrade3] = () => PointManager.Instance.BuyUpgrade(2);
            _keyHandler.UpgradeKeyActions[UpgradeKeyType.Upgrade4] = () => PointManager.Instance.BuyUpgrade(3);
        }

        private void MainLoop() {
            while (true) {
                if (UpgradesDialog || RebirthDialog) {
                    return;
                }

                Console.Clear();

                Console.WriteLine($"Points: {PointManager.Instance.Points}");

                Console.WriteLine("[N] - Gather points");
                Console.WriteLine("[R] - Open rebirth windows");
                Console.WriteLine("[C] - Perform rebirth");
                Console.WriteLine("[U] - Open upgrades windows");


                KeyType inputKey = _keyHandler.GetKey(Console.ReadKey().Key);
                _keyHandler.KeyActions[inputKey]?.Invoke();

                Console.Clear();
            }
        }

        private void ToggleUpgradesDialog() {
            if (UpgradesDialog) {
                CloseUpgradesDialog();
                return;
            }

            CloseRebirthDialog();
            OpenUpgradesDialog();
        }

        private void OpenUpgradesDialog() {
            UpgradesDialog = true;

            while (UpgradesDialog) {
                Console.Clear();

                _upgradesDialog.RenderDialog();

                ConsoleKey consoleKey = Console.ReadKey().Key;
                ValidateInputKey(KeyType.UpgradesDialog, consoleKey);

                UpgradeKeyType inputKey = _keyHandler.GetUpgradeKey(consoleKey);
                _keyHandler.UpgradeKeyActions[inputKey]?.Invoke();

                Console.Clear();
            }
        }

        private void CloseUpgradesDialog() {
            UpgradesDialog = false;
            Console.Clear();
        }

        private void ToggleRebirthDialog() {
            if (RebirthDialog) {
                CloseRebirthDialog();
                return;
            }

            CloseUpgradesDialog();
            OpenRebirthDialog();
        }

        private void OpenRebirthDialog() {
            RebirthDialog = true;

            while (RebirthDialog) {
                Console.Clear();

                _rebirthDialog.RenderDialog();

                ConsoleKey consoleKey = Console.ReadKey().Key;
                ValidateInputKey(KeyType.RebirthDialog, consoleKey);

                Console.Clear();
            }
        }

        private void CloseRebirthDialog() {
            RebirthDialog = false;
            Console.Clear();
        }

        private bool ValidateInputKey(KeyType keyType, ConsoleKey key) {
            KeyType inputKey = _keyHandler.GetKey(key);
            _keyHandler.KeyActions[inputKey]?.Invoke();

            if (inputKey == keyType) return true;

            return false;
        }

        private void ContinueText(string text) {
            Console.Write(text);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
