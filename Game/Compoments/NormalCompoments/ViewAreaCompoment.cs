using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class ViewAreaCompoment : CompomentData
    {
        public ViewAreaCompoment(GameObject charactorObject)
        {
            this.ViewRender = FindGameObject.GetTransformInChildByName("ViewArea", charactorObject.transform).GetComponent<MeshRenderer>();
        }

        public MeshRenderer ViewRender = null;
    }
}