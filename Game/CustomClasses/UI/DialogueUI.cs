using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class DialogueUI : ARPGUI
    {
        public DialogueUI(Transform uiContainer, GameObject dialogueUI) : base(uiContainer, dialogueUI)
        {
            this.Text          = FindGameObject.GetTransformInChildByName("ContendText", dialogueUI.transform).GetComponent<Text>();
            this.ConfirmButton = FindGameObject.GetTransformInChildByName("ConfirmButton", dialogueUI.transform).GetComponent<Button>();
            this.CancelButton  = FindGameObject.GetTransformInChildByName("CancelButton", dialogueUI.transform).GetComponent<Button>();
        }
        
        public bool LateEnable = false;
        
        public Text Text;

        public Button ConfirmButton;
        public Button CancelButton;
    }
}