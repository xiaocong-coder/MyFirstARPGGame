using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class NavigateCompoment : CompomentData
    {
        public NavigateCompoment(GameObject gameObject)
        {
            this.Navigator = FindGameObject.GetTransformInChildByName("Navigator", gameObject.transform);
        }

        public Transform Navigator;
        public float HorizontalSpeed = 20;
    }
}