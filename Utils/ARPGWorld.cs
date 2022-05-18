using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGWorld : MonoBehaviour
    {
        public ARPGEntitiesGroup EntitiesGroup;
        public Dictionary<int, ARPGEntity> EntitiesList;
        
        public Dictionary<Type, ARPGState> AllLevelStates;
        public ARPGState CurrentState;

        public virtual void Awake()
        {
            this.EntitiesGroup = new ARPGEntitiesGroup();
        }
        
        private void FixedUpdate()
        {
            if(CurrentState.SystemList.Length == 0)
                return;
            
            for (int i = 0; i < CurrentState.SystemList.Length; i++)
            {
                var system = CurrentState.SystemList[i];
                system.ExecuteOnFixedUpdate();
            }
        }
        
        private void Update()
        {
            if(CurrentState.SystemList.Length == 0)
                return;
            
            for (int i = 0; i < CurrentState.SystemList.Length; i++)
            {
                var system = CurrentState.SystemList[i];
                system.ExecuteOnUpdate();
            }
        }
        
        private void LateUpdate()
        {
            if(CurrentState.SystemList.Length == 0)
                return;
            
            for (int i = 0; i < CurrentState.SystemList.Length; i++)
            {
                var system = CurrentState.SystemList[i];
                system.ExecuteOnLateUpdate();
            }
        }
    }
}