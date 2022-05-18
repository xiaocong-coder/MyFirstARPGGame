using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.LevelStates
{
    public class LLoadState : ARPGState
    {
        public LLoadState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new CheckLevelResourceSystem()
            };
        }

        public override void Enter()
        {
            base.Enter();
            
            var levelResourceComp = LevelResourceCacheCompoment.Singlcomp;
            levelResourceComp.DelayTimeCountor.Go();
        }
    }
}