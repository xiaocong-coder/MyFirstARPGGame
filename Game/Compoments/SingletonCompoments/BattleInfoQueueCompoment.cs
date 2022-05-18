using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class BattleInfoQueueCompoment : SingletonCompoment<BattleInfoQueueCompoment>
    {
        public BattleInfoQueueCompoment()
        {
            Singlcomp = this;

            this.BattleInfo = null;
            this.DoubleHitRefreshCountTimer = new ARPGTimer(3f);
            this.SlowDownTimer = new ARPGTimer(0.1f);
        }
        
        public BattleInfo BattleInfo;
        
        public int DoubieHitCount = 0;
        public ARPGTimer DoubleHitRefreshCountTimer;
        public ARPGTimer SlowDownTimer;
    }

    public class BattleInfo
    {
        public int attackId;
        public int hitId;

        public Vector3 attackForward;
    }
}