using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class TranslateCompoment : CompomentData
    {
        public TranslateCompoment(GameObject gameObject)
        {
            this.transform = gameObject.transform;
            this.MapGridX = 0;
            this.MapGridY = 0;
        }
        
        public Transform transform;
        public int MapGridX = 0;
        public int MapGridY = 0;
    }
}