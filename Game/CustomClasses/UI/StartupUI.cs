using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class StartupUI : ARPGUI
    {
        public StartupUI(Transform uiContainer, GameObject startupUI) : base(uiContainer, startupUI)
        {
            // startupUI.transform.parent = uiContainer;
            // var ui = startupUI.GetComponent<Canvas>(); 
            // ui.enabled = true;
            // this.UI = ui;
            
            var enterButton   = startupUI.transform.Find("StartButton").GetComponent<Button>();
            var existButton   = startupUI.transform.Find("ExistButton").GetComponent<Button>();
            var optionButton  = startupUI.transform.Find("OptionButton").GetComponent<Button>();

            enterButton.onClick.AddListener(EnterGameLevelSelect);
            existButton.onClick.AddListener(ExistGame);
            optionButton.onClick.AddListener(EnterOption);
        }
        
        public void EnterGameLevelSelect()
        {
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(GameLevelSelectUI));
        }
        
        public void ExistGame()
        {
            Debug.Log("exist");
        }
        
        public void EnterOption()
        {
            UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(OptionUI));
        }
    }
}