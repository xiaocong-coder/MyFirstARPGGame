using System;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public interface ICompoment{}
    
    public class ARPGCompoment : ICompoment
    {
        public int OwnerID;
    }

    public class CompomentData : ARPGCompoment
    {
        // Only constructor and datas
    }

    public class SingletonCompoment<T> :  ARPGCompoment where T : ARPGCompoment 
    {
        // Singleton
        public static T Singlcomp
        {
            get => _singlcomp;
            set => _singlcomp = value;
        }
        private static T _singlcomp;
    }
}