using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class ModelCompoment : CompomentData
    {
        public ModelCompoment(GameObject gameObject)
        {
            this.Model = FindGameObject.GetTransformInChildByName("Model", gameObject.transform);
        }

        public Transform Model;
    }
}