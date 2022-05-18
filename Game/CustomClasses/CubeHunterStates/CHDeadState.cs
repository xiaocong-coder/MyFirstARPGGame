using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates
{
    public class CHDeadState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);
            
            var attackComp = GetCompomentData<AttackCompoment>(entity);
            var hitComp    = GetCompomentData<HitCompoment>(entity);

            attackComp.Trigger.enabled = false;
            hitComp.Trigger.enabled = false;
        }
    }
}