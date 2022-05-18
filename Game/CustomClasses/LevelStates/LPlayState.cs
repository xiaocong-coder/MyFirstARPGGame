using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.LevelStates
{
    public class LPlayState : ARPGState
    {
        public LPlayState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new CheckPlaySystem(),
                new MapGridsRefreshSystem(),
                new TargetSetterSystem(),
                new InputSignalSystem(),
                new PlayerControlSystem(),
                new CameraControlSystem(),
                new EnemyControlSystem(),
                new BattleSystem(),
                new UpdateUISystem(),
                new ScoreSystem()
            };
        }

        public override void Enter()
        {
            base.Enter();
            
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(PlayUI));
        }
    }
}