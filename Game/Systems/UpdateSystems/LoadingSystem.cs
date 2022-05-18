using System;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class LoadingSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var entities = WorldGod.Singleton.BackGroundWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContainComp = GetCompomentData<UIContainCompoment>(entity);

                var loadingUI = uiContainComp.UIContainer[typeof(LoadingUI)] as LoadingUI;

                if (loadingUI != null)
                {
                    var tipLen = loadingUI.TipString.Count;
                    var loadLen = loadingUI.LoadingString.Count;

                    if (loadingUI.TipRefreshTimerCountor.IsOver)
                    {
                        loadingUI.TipIndex = (loadingUI.TipIndex + 1) % tipLen;
                        var tipString = loadingUI.TipString[loadingUI.TipIndex];
                        loadingUI.TipText.text = tipString;

                        loadingUI.TipRefreshTimerCountor.Go();
                    }
                    
                    if (loadingUI.LoadingRefreshTimerCountor.IsOver)
                    {
                        loadingUI.LoadingIndex = (loadingUI.LoadingIndex + 1) % loadLen;
                        var loadingString = loadingUI.LoadingString[loadingUI.LoadingIndex];
                        loadingUI.LoadingText.text = loadingString;
                        
                        loadingUI.LoadingRefreshTimerCountor.Go();
                    }
                }
            });
        }
    }
}