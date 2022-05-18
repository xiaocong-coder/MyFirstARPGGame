using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class CameraFollowCompoment : CompomentData
    {
        public CameraFollowCompoment(GameObject gameObject)
        {
            this.FollowTransform =
                FindGameObject.GetTransformInChildByName("CameraPos", gameObject.transform);
        }

        public Transform FollowTransform;
    }
}