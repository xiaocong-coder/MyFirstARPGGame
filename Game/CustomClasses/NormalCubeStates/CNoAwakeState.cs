using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CNoAwakeState : ARPGSystemInState
    {
        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var stateComp       = GetCompomentData<CubeStateCompoment>(entity); 
            
            var nextState = stateComp.States[typeof(CIdleState)];
            ChangeState(ref stateComp.CurrentState, nextState, entity);
        }
    }
}