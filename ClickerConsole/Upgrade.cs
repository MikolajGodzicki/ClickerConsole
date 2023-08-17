using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class Upgrade {
        public uint Multiplier { get; set; }
        public uint Cost { get; set; }

        public int Count { get; set; }

        public Upgrade(uint multiplier, uint cost) {
            Multiplier = multiplier;
            Cost = cost;
            Count = 0;
        }

        public void BuyUpgrade() {
            if (PointManager.Instance.Points < Cost) return;

            PointManager.Instance.RemovePoints(Cost);
            PointManager.Instance.UpgradesMultiplier += Multiplier;
            Cost *= 2;
            Count++;
        }
    }
}
