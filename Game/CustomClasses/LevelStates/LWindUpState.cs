using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.LevelStates
{
    public class LWindUpState : ARPGState
    {
        public LWindUpState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new SettleScoreSystem()
            };
        }

        public override void Enter()
        {
            base.Enter();
            
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(WindUpUI));
            
            var scoreComp = ScoreCountCompoment.Singlcomp;
            if (scoreComp.IsPlayerWin)
            {
                var index = PlayerPrefs.GetInt(WorldGod.Singleton.CurrentWorld.name + "Index") + 1; 
                var nextLevel = "GameLevel" + index;

                if (PlayerPrefs.HasKey(nextLevel))
                {
                    GameDataSetter.LevelAccess(nextLevel);   
                }
            }
        }
    }
}