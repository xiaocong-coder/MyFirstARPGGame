using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class LookAtTargetCompoment : CompomentData
    {
        public LookAtTargetCompoment(GameObject gameObject)
        {
            this.LookAtTarget =
                FindGameObject.GetTransformInChildByName(
                    "LookAtPos",
                    gameObject.transform
                ); 
        }
        
        public Transform LookAtTarget = null;
        
        public float RotationWithXAxis = 0;
        public float VerticalSpeed = 20;
    }
}