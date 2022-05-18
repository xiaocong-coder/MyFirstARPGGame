using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class GameLevelSelectUI : ARPGUI
    {
        public GameLevelSelectUI(Transform uiContainer, GameObject gameLevelSelectUI) : base(uiContainer, gameLevelSelectUI)
        {
            var levelsContent = FindGameObject.GetTransformInChildByName("Content", gameLevelSelectUI.transform);
            var levelNums = ExcelLoader.Singleton.GetAllLevelNums;
            for (int i = 1; i <= levelNums; i++)
            {
                if (PlayerPrefs.GetInt("GameLevel" + i) != 1)
                {
                    continue;
                }
                
                var gameLevel = WorldGod.Singleton.LoadGameLevelSelectUI<GameObject>("GameLevelSelect");
                gameLevel.name = "GameLevel" + i;
                gameLevel.GetComponentInChildren<Text>().text = gameLevel.name;
                gameLevel.transform.SetParent(levelsContent);
                
                Button button = gameLevel.GetComponent<Button>();
                button.onClick.AddListener(delegate
                {
                    WorldGod.Singleton.EnterLevel(gameLevel.name);
                    WorldGod.Singleton.ShowLoadingUI();
                });
            }

            this.BackButton = FindGameObject.GetTransformInChildByName("BackButton", gameLevelSelectUI.transform).GetComponent<Button>();
            this.BackButton.onClick.AddListener(delegate
            {
                UISystem.System.ShowUIAndHideOther(WorldGod.Singleton.CurrentWorld, typeof(StartupUI));
            });
        }

        public Button BackButton;
    }
}