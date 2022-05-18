using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class AnimatorCompoment : CompomentData
    {
        public AnimatorCompoment(GameObject gameObject)
        {
            this.Animator = gameObject.transform.GetComponentInChildren<Animator>();
            
            AllEngineItemCompoment.Singlcomp.AllAnimators.Add(this.Animator);
        }

        public Animator Animator  = null;
    }
}