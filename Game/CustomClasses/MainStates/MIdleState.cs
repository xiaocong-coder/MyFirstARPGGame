using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.MainStates
{
    public class MIdleState : ARPGState
    {
        public MIdleState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new CheckMainResourceSystem()
            };
        }
        
        public override void Enter()
        {
            base.Enter();

            var mainResourceComp = MainResourceCacheCompoment.Singlcomp;
            mainResourceComp.DelayTimeCountor.Go();
        }
    }
}