using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class KeyBoardInputCompoment : SingletonCompoment<KeyBoardInputCompoment>
    {
        public KeyBoardInputCompoment()
        {
            Singlcomp = this;
        }
        
        [Header("====Key Setting====")]
        public string keyUp           = "w";
        public string keyDown         = "s";
        public string keyLeft         = "a";
        public string keyRight        = "d";
        public string keyRun          = "left shift";
        public string keyNormalAttack = "mouse 0";
        public string keyHardAttack   = "mouse 1";
        public string keyViewUp       = "Mouse Y";
        public string keyViewRight    = "Mouse X";
        public string keyDodge        = "f";
    
        [Header("====Mouse Setting====")]
        public float mouseSensityX = 20.0f;
        public float mouseSensityY = 20.0f;
    
        [Header("====Button====")]
        public ARPGButton buttonRun          = new ARPGButton();
        public ARPGButton buttonDodge        = new ARPGButton();
        public ARPGButton buttonNormalAttack = new ARPGButton(0.5f, 0.0f);
        public ARPGButton buttonHardAttack   = new ARPGButton(0.5f, 0.8f);
    }
}