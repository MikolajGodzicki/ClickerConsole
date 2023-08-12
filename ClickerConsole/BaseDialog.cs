using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class BaseDialog {
        private char BorderChar = '#';

        protected int width;
        protected int height;

        public BaseDialog(int width, int height) {
            this.width = width;
            this.height = height;
        }

        protected void DrawHorizontalLine() {
            for (int i = 0; i < width; i++) {
                Console.Write(BorderChar);
            }
        }

        protected void DrawVerticalLine() {
            for (int i = 1; i < height + 1; i++) {
                Console.SetCursorPosition(0, i);
                Console.Write(BorderChar);
                Console.SetCursorPosition(width - 1, i);
                Console.Write(BorderChar);
                Console.SetCursorPosition(0, height);
            }
        }

        protected void DrawElement(int x, int y, string text) {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
