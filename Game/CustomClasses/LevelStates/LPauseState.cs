using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.LevelStates
{
    public class LPauseState : ARPGState
    {
        public LPauseState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new PausingSystem()
            };
        }

        public override void Enter()
        {
            base.Enter();
            
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(PauseUI));
        }
    }
}