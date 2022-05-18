using System;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.InitizeSystems
{
    public class UISystem : ARPGSystemMethodSet<UISystem>
    {
        public void InitUI<T>(ARPGWorld world, T ui) where T : ARPGUI
        {
            var entities = world.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = GetCompomentData<UIContainCompoment>(entity);
                uiContComp.UIContainer.Add(typeof(T), ui);

                ui.UI.enabled = false;
            });            
        }

        public void ShowUIAndHideOther(ARPGWorld world, Type type)
        {
            var entities = world.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);
                var target = type;
                foreach (var ui in uiContComp.UIContainer.Values)
                {
                    ui.UI.enabled = false;
                }
                uiContComp.UIContainer[target].UI.enabled = true; 
            });
        }
        
        public void ShowUIAndDontHideOther(ARPGWorld world, Type type)
        {
            var entities = world.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);
                var target = type;
                uiContComp.UIContainer[target].UI.enabled = true; 
            });
        }

        public void CloseUI(ARPGWorld world, Type type)
        {
            var entities = world.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);
                var target = type;
                uiContComp.UIContainer[target].UI.enabled = false; 
            });
        }

        public T GetUI<T>(ARPGWorld world) where T : ARPGUI
        {
            T ui = null;
            
            var entities = world.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);
                var target = typeof(T);
                ui = uiContComp.UIContainer[target] as T; 
            });

            return ui;
        }
    }
}