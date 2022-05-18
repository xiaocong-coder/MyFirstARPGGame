using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class StoryUI : ARPGUI
    {
        public StoryUI(Transform uiContainer, GameObject uiObj) : base(uiContainer, uiObj)
        {
            var trans = uiObj.transform;
            
            this.StoryText = FindGameObject.GetTransformInChildByName("StoryText", trans).GetComponent<Text>();
        }

        public Text StoryText;
    }
}