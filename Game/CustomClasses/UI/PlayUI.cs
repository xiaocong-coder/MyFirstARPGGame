using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class PlayUI : ARPGUI
    {
        public PlayUI(Transform uiContainer, GameObject uiObj) : base(uiContainer, uiObj)
        {
            var trans = uiObj.transform;

            this.CharactorImage      = FindGameObject.GetTransformInChildByName("CharactorImage", trans).GetComponent<Image>();
            this.CharactorProperties = FindGameObject.GetTransformInChildByName("CharactorProperties", trans).GetComponent<Image>();
            this.DoubleHitBackground = FindGameObject.GetTransformInChildByName("BackGround", trans).GetComponent<Image>();
            this.DoubleHit           = FindGameObject.GetTransformInChildByName("DoubleHitCount", trans).GetComponent<Text>();
            this.HpMaterial          = FindGameObject.GetTransformInChildByName("HP", trans).GetComponent<Image>().material;
        }

        public Image CharactorImage;
        public Image CharactorProperties;
        public Image DoubleHitBackground;
        public Text  DoubleHit;

        public Material HpMaterial;
    }
}