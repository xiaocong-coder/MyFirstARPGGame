using System;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class ScoreSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnLateUpdate()
        {
            base.ExecuteOnLateUpdate();

            var scoreComp = ScoreCountCompoment.Singlcomp;
            var doubleHitComp = BattleInfoQueueCompoment.Singlcomp;

            scoreComp.MaxDoubleHit = Math.Max(doubleHitComp.DoubieHitCount, scoreComp.MaxDoubleHit);
        }
    }
}