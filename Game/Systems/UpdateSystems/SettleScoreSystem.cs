using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class SettleScoreSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var scoreComp = ScoreCountCompoment.Singlcomp;

            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContainComp = GetCompomentData<UIContainCompoment>(entity);
                var windupUI = uiContainComp.UIContainer[typeof(WindUpUI)] as WindUpUI;

                if (windupUI != null)
                {
                    windupUI.IsWinText.text = "You " + (scoreComp.IsPlayerWin ? "Win" : "Lose");
                    windupUI.MaxDoubleHitText.text = "The Max DoubleHit：\n" + scoreComp.MaxDoubleHit;
                }
            });
        }
    }
}