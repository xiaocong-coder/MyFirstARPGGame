using System.Collections.Generic;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class AllEngineItemCompoment : SingletonCompoment<AllEngineItemCompoment>
    {
        public AllEngineItemCompoment()
        {
            Singlcomp = this;

            this.AllAnimators = new List<Animator>();
            this.AllRigidBodys = new List<Rigidbody>();
        }
        public List<Animator>  AllAnimators;
        public List<Rigidbody> AllRigidBodys;
    }
}