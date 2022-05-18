using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class WindUpUI : ARPGUI
    {
        public WindUpUI(Transform uiContainer, GameObject uiObj) : base(uiContainer, uiObj)
        {
            var trans = uiObj.transform;
               
            this.IsWinText        = FindGameObject.GetTransformInChildByName("IsWinText", trans).GetComponent<Text>();
            this.MaxDoubleHitText = FindGameObject.GetTransformInChildByName("MaxDoubleHitText", trans).GetComponent<Text>();
            this.LeaveButton      = FindGameObject.GetTransformInChildByName("LeaveButton", trans).GetComponent<Button>();
            
            this.LeaveButton.onClick.AddListener(LeaveLevel);
        }

        public Text IsWinText;
        public Text MaxDoubleHitText;
        public Button LeaveButton;

        public void LeaveLevel()
        {
            WorldGod.Singleton.EnterMain();
        }
    }
}