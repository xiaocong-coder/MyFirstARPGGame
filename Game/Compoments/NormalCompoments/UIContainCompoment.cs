using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class UIContainCompoment : CompomentData
    {
        public UIContainCompoment()
        {
            this.UIContainer = new Dictionary<Type, ARPGUI>();
        }
        
        public Dictionary<Type, ARPGUI> UIContainer;
    }
}