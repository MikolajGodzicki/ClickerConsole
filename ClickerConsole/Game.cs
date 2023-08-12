using System;
using System.Collections.Generic;
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

            init();
            MainLoop();
        }
        private void init() {
            UpgradesDialog = false;
            RebirthDialog = false;

            _keyHandler = new KeyHandler();

            _keyHandler.KeyActions[KeyType.Press] = PointManager.Instance.AddPoint;
            _keyHandler.KeyActions[KeyType.UpgradesDialog] = ToggleUpgradesDialog;
            _keyHandler.KeyActions[KeyType.RebirthDialog] = ToggleRebirthDialog;
            _keyHandler.KeyActions[KeyType.Rebirth] = PointManager.Instance.Rebirth;

            _rebirthDialog = new RebirthDialog(60, 10);
            _upgradesDialog = new UpgradesDialog(60, 20);
        }

        private void MainLoop() {
            while (true) {
                if (UpgradesDialog || RebirthDialog) {
                    return;
                }

                Console.Clear();

                Console.WriteLine($"Points: {PointManager.Instance.Points}");
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

            OpenUpgradesDialog();
        }

        private void OpenUpgradesDialog() {
            if (UpgradesDialog) {
                return;
            }

            UpgradesDialog = true;

            while (true) {
                Console.Clear();

                _upgradesDialog.RenderDialog();

                if (ValidateInputKey(KeyType.UpgradesDialog)) break;

                Console.Clear();
            }
        }

        private void CloseUpgradesDialog() {
            UpgradesDialog = false;
        }

        private void ToggleRebirthDialog() {
            if (RebirthDialog) { 
                CloseRebirthDialog();
                return;
            }

            UpgradesDialog = false;
            OpenRebirthDialog();
        }

        private void OpenRebirthDialog() {
            if (RebirthDialog) {
                return;
            }

            RebirthDialog = true;

            while (true) {
                Console.Clear();

                _rebirthDialog.RenderDialog();

                if (ValidateInputKey(KeyType.RebirthDialog)) break;

                Console.Clear();
            }
        }

        private void CloseRebirthDialog() {
            RebirthDialog = false;
        }

        private bool ValidateInputKey(KeyType keyType) {
            KeyType inputKey = _keyHandler.GetKey(Console.ReadKey().Key);
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
