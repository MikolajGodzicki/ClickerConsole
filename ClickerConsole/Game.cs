using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class Game {
        private KeyHandler _keyHandler;

        private bool UpgradesDialog;

        public Game() {
            ContinueText("Welcome! This is very simple clicker console game!");
            ContinueText("You need to click setted click in options to gain points!");
            ContinueText("Buy upgrades to get more points per click.");
            ContinueText("Make rebirths to get more and more multiplier!");

            init();
            MainLoop();
        }
        private void init() {
            UpgradesDialog = false;

            _keyHandler = new KeyHandler();

            _keyHandler.KeyActions[KeyType.Press] = PointManager.Instance.AddPoint;
            _keyHandler.KeyActions[KeyType.Upgrades] = OpenUpgradesDialog;
            _keyHandler.KeyActions[KeyType.Rebirth] = PointManager.Instance.Rebirth;
        }

        private void MainLoop() {
            while (true) {
                Console.WriteLine($"Points: {PointManager.Instance.Points}");
                Console.WriteLine($"Current Rebirth: {PointManager.Instance.CurrentRebirth}");
                Console.WriteLine($"Rebirth Cost: {PointManager.Instance.RebirthCost}");
                KeyType inputKey = _keyHandler.GetKey(Console.ReadKey().Key);
                _keyHandler.KeyActions[inputKey]?.Invoke();

                Console.Clear();
            }
        }

        private void OpenUpgradesDialog() {
            if (UpgradesDialog) {
                return;
            }
        }

        private void ContinueText(string text) {
            Console.Write(text);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
