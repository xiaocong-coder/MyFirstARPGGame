using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class AutoMoveCompoment : CompomentData
    {
        public AutoMoveCompoment()
        {
            this.DelayTimer = new ARPGTimer(5);
        }

        public ARPGTimer DelayTimer;
    }
}