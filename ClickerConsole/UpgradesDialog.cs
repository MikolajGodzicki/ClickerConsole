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
            DrawHorizontalLine();
            DrawVerticalLine();
            DrawHorizontalLine();

            Console.SetCursorPosition(0, height + 1);
        }
    }
}
