using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.MainStates;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class CheckMainResourceSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();

            var mainResourceComp = MainResourceCacheCompoment.Singlcomp;
            
            if (mainResourceComp.DelayTimeCountor.IsOver)
            {
                WorldGod.Singleton.CloseLoadingUI();
                
                var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(MStartupState)];
                ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);   
            }
        }
    }
}