using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGEntity
    {
        public int EntityID;
        public Dictionary<Type, ARPGCompoment> CompomentsList;

        public GameObject EntityObject = null;

        public ARPGEntity(GameObject entityObject)
        {
            this.EntityID = GetHashCode();
            this.EntityObject   = entityObject;
        }

        public void SetCompoments(Dictionary<Type, ARPGCompoment> compoments)
        {
            this.CompomentsList = compoments;
        }
    }
}