using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class RigidBodyCompoment : ARPGCompoment
    {
        public RigidBodyCompoment(GameObject gameObject)
        {
            this.RigidBody = gameObject.transform.GetComponent<Rigidbody>();
            
            AllEngineItemCompoment.Singlcomp.AllRigidBodys.Add(this.RigidBody);
        }
        public Rigidbody RigidBody;
    }
}