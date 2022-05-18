using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.BackGroundState
{
    public class BGLoadingState : ARPGState
    {
        public BGLoadingState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new LoadingSystem(),
            };
        }
        
        public override void Enter()
        {
            base.Enter();
            
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.BackGroundWorld, typeof(LoadingUI));
            var entities = WorldGod.Singleton.BackGroundWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContainer = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);

                var loadingUI = uiContainer.UIContainer[typeof(LoadingUI)] as LoadingUI;
                loadingUI.TipRefreshTimerCountor.Go();
                loadingUI.LoadingRefreshTimerCountor.Go();
                loadingUI.UI.enabled = true;
            });
        }

        public override void Exist()
        {
            base.Exist();
            
            UISystem.System.CloseUI(WorldGod.Singleton.BackGroundWorld, typeof(LoadingUI));
            var entities = WorldGod.Singleton.BackGroundWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContainer = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);

                var loadingUI = uiContainer.UIContainer[typeof(LoadingUI)];
                loadingUI.UI.enabled = false;
            });
        }
    }
}