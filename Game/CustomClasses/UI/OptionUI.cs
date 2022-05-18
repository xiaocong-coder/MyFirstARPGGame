using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class OptionUI : ARPGUI
    {
        public OptionUI(Transform uiContainer, GameObject optionUI) : base(uiContainer, optionUI)
        {
            var backButton = FindGameObject.GetTransformInChildByName("BackButton", optionUI.transform).GetComponent<Button>();
            var resetDataButton = FindGameObject.GetTransformInChildByName("ResetGameDataButton", optionUI.transform).GetComponent<Button>();
            
            backButton.onClick.AddListener(Back);
            resetDataButton.onClick.AddListener(ResetData);
        }
        
        public void Back()
        {
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContComp = ARPGSystem.GetCompomentData<UIContainCompoment>(entity);
                var target = typeof(StartupUI);
                foreach (var ui in uiContComp.UIContainer.Values)
                {
                    ui.UI.enabled = false;
                }
                uiContComp.UIContainer[target].UI.enabled = true; 
            });
        }

        public void ResetData()
        {
            UISystem.System.ShowUIAndDontHideOther(WorldGod.Singleton.CurrentWorld, typeof(DialogueUI));
            
            var dialogue = UISystem.System.GetUI<DialogueUI>(WorldGod.Singleton.CurrentWorld);
            dialogue.Text.text = "Are you sure reset game data?";
            dialogue.ConfirmButton.onClick.AddListener(delegate
            {
                GameDataSetter.InitLevelDataByOnce();
                dialogue.UI.enabled = false;
                
                WorldGod.Singleton.EnterMain();
            });
            dialogue.CancelButton.onClick.AddListener(delegate
            {
                dialogue.UI.enabled = false;
                Debug.Log("cancel");
            });
        }
    }
}