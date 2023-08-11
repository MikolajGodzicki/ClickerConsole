using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerConsole {
    internal class PointManager {
        private static PointManager? instance = null;
        public static PointManager Instance {
            get {
                if (instance == null) {
                    instance = new PointManager();
                }

                return instance;
            }
        }

        public uint CurrentRebirth { get; private set; }
        public uint RebirthCost { get; private set; }

        public uint UpgradesMultiplier { get; private set; }
        public uint RebirthMultiplier { get; private set; }

        public uint Points { get; private set; }

        public PointManager() {
            Points = 0;
            CurrentRebirth = 0;
            RebirthCost = 128;
            UpgradesMultiplier = 1;
            RebirthMultiplier = 1;
        }

        public void AddPoint() {
            Points += 1 * UpgradesMultiplier * RebirthMultiplier;
        }

        public void RemovePoint() {
            if (Points == 0) return;

            Points--;
        }

        public void Rebirth() {
            if (Points < RebirthCost) return;


            Points = 0;
            CurrentRebirth++;
            RebirthCost *= 2;
            RebirthMultiplier *= 2;
        }
    }
}
