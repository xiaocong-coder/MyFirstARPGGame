using AssetsPackage._2._Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.LevelStates
{
    public class LStoryState : ARPGState
    {
        public LStoryState()
        {
            this.SystemList = new[]
            {
                new StoryPlaySystem()
            };
        }

        public override void Enter()
        {
            base.Enter();
            
            var storyCacheComp = StoryCacheCompoment.Singlcomp;
            storyCacheComp.RefreshTextTimerCounter.Go();
            
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(StoryUI));
        }
    }
}