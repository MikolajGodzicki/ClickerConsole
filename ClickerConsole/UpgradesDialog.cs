using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class UpgradesDialog : BaseDialog {
        public UpgradesDialog(int width, int height) : base(width, height) {

        }

        public void RenderDialog() {
            int upgradesCount = PointManager.Instance.Upgrades.Count;
            for (int i = 0; i < upgradesCount; i++) {
                RenderUpgrade(i);
            }
            Console.SetCursorPosition(0, height * upgradesCount);
        }

        private void RenderUpgrade(int iteration) {
            DrawHorizontalLine(height * iteration);
            DrawVerticalLine(iteration);
            RenderUpgradeStats(iteration);
            DrawHorizontalLine(height * iteration + height - 1);
        }

        private void RenderUpgradeStats(int iteration) {
            Upgrade upgrade = PointManager.Instance.Upgrades[iteration];
            Console.SetCursorPosition(2, height * iteration + 2);
            Console.Write($"{iteration + 1}.");
            Console.SetCursorPosition(5, height * iteration + 2);
            Console.Write($"Count: {upgrade.Count}");
            Console.SetCursorPosition(17, height * iteration + 2);
            Console.Write($"Multiplier: {upgrade.Multiplier}");
            Console.SetCursorPosition(34, height * iteration + 2);
            Console.Write($"Cost: {upgrade.Cost}");
        }

        protected void DrawHorizontalLine(int posY) {
            for (int i = 0; i < width; i++) {
                Console.SetCursorPosition(i, posY);
                Console.Write(BorderChar);
            }
        }

        private void DrawVerticalLine(int iteration) {
            for (int i = 0; i < height; i++) {
                Console.SetCursorPosition(0, i + (height * iteration));
                Console.Write(BorderChar);
                Console.SetCursorPosition(width - 1, i + (height * iteration));
                Console.Write(BorderChar);
            }
        }
    }
}
