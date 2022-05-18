using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGUI
    {
        public ARPGUI(Transform uiContainer, GameObject uiObj)
        {
            uiObj.transform.parent = uiContainer;
            var ui = uiObj.GetComponent<Canvas>(); 
            ui.enabled = false;
            this.UI = ui;
        }
        
        public Canvas UI;
    }
}