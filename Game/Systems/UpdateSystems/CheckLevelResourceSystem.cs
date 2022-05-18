using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class CheckLevelResourceSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();

            var levelResourceComp = LevelResourceCacheCompoment.Singlcomp;
            
            if (levelResourceComp.DelayTimeCountor.IsOver)
            {
                WorldGod.Singleton.CloseLoadingUI();
                
                var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LStoryState)];
                ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);   
            }
        }
    }
}