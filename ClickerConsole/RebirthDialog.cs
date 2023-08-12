using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class RebirthDialog : BaseDialog {

        public RebirthDialog(int width, int height) : base (width, height)
        {
            
        }

        public void RenderDialog() {
            DrawHorizontalLine();
            DrawVerticalLine();
            DrawHorizontalLine();


            DrawElement(2, 2, $"Current rebirth: {PointManager.Instance.CurrentRebirth}");
            DrawElement(2 + 25, 2, $"Current multiplier: {PointManager.Instance.RebirthMultiplier}");

            DrawElement(2, 5, $"Rebirth cost: {PointManager.Instance.RebirthCost}");

            DrawElement(2, 7, "Rebirth progress: ");
            DrawProgressBar(25, 7);

            Console.SetCursorPosition(0, height + 1);
        }

        private void DrawProgressBar(int x, int y) {
            Console.SetCursorPosition(x, y);
            uint points = PointManager.Instance.Points;
            uint rebirthCost = PointManager.Instance.RebirthCost;

            float progress = (float) points / rebirthCost * 10;

            string text = "[";
            for (int i = 1; i <= 10; i++) {
                if (progress >= i) {
                    text += "*";
                } else {
                    text += "-";
                }
            }
            int percent = (int)(progress * 10);

            if (percent > 100) {
                percent = 100;
            }


            text += $"] {percent}%";

            Console.Write(text);
        } 
    }
}
