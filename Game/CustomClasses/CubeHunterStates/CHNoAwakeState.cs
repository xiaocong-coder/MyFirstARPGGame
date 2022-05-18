using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates
{
    public class CHNoAwakeState : ARPGSystemInState
    {
        public override void ExecuteOnLateUpdate(ARPGEntity entity)
        {
            base.ExecuteOnLateUpdate(entity);
            
            var stateComp       = GetCompomentData<CubeHunterStateCompoment>(entity); 
            
            var nextState = stateComp.States[typeof(CHGroundState)];
            ChangeState(ref stateComp.CurrentState, nextState, entity);
        }
    }
}