using System;
using System.Collections.Generic;
using System.Text;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class LoadingUI : ARPGUI
    {
        public LoadingUI(Transform uiContainer, GameObject uiObj) : base(uiContainer, uiObj)
        {
            this.TipRefreshTimerCountor = new ARPGTimeCountor(2f);
            this.LoadingRefreshTimerCountor = new ARPGTimeCountor(0.2f);

            this.TipText = FindGameObject.GetTransformInChildByName("TipText", uiObj.transform).GetComponent<Text>();
            this.LoadingText = FindGameObject.GetTransformInChildByName("LoadingText", uiObj.transform).GetComponent<Text>();

            this.TipText.text = this.TipString[TipIndex];
            this.LoadingText.text = this.LoadingString[LoadingIndex];
        }

        public Text TipText;
        public Text LoadingText;
        
        public ARPGTimeCountor TipRefreshTimerCountor;
        public int TipIndex = 0;
        public List<String> TipString = new List<String>()
        {
            "Don't Close to enemy when you contain low HP, try to make it done one by one.",
            "After you access level, the next level will be unlocked.",
            "You can reset game data in option interface.",
            "More double hit, More score gets."
        };

        public ARPGTimeCountor LoadingRefreshTimerCountor;
        public int LoadingIndex = 0;
        public List<String> LoadingString = new List<String>()
        {
            "Loading",
            "Loading.",
            "Loading..",
            "Loading...",
        };
    }
}