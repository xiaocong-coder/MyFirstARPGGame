using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class ColliderCompoment : CompomentData
    {
        public ColliderCompoment(GameObject gameObject)
        {
            this.SelfCollider = gameObject.transform.GetComponent<Collider>();
        }

        public Collider SelfCollider = null;
    }
}