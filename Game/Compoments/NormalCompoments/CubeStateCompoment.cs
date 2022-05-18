using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Game.CustomClasses.CubeStates;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class CubeStateCompoment : CompomentData
    {
        public CubeStateCompoment(GameObject charactor)
        {
            this.States = new Dictionary<Type, ARPGSystemInState>()
            {
                { typeof(CNoAwakeState)     , new CNoAwakeState()},
                { typeof(CIdleState)        , new CIdleState()},
                { typeof(CPatrolState)      , new CPatrolState()},
                { typeof(CFollowUpState)    , new CFollowUpState()},
                { typeof(CAttackState)      , new CAttackState()},
                { typeof(CHitState)         , new CHitState()},
                { typeof(CDeadState)        , new CDeadState()}
            };
            this.CurrentState = this.States[typeof(CNoAwakeState)];
            
            var model = FindGameObject.GetTransformInChildByName("Model", charactor.transform);
            this.CubeStateAnimEvent = model.AddComponent<CubeStateAnimEvent>();
            this.CubeStateAnimEvent.ParentCompoment = this;
        }
        
        public CubeStateAnimEvent CubeStateAnimEvent;
        
        public Dictionary<Type, ARPGSystemInState> States;
        public ARPGSystemInState CurrentState;
    }

    public class CubeStateAnimEvent : MonoBehaviour
    {
        public CubeStateCompoment ParentCompoment;
        
        void EnterGround()
        {
            var nextState = ParentCompoment.States[typeof(CIdleState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterAttack()
        {
            // Debug.Log("Enter Attack");
            // var nextState = ParentCompoment.States[typeof(CAttackState)];
            // var entity = ARPGWorld.World.EntitiesList[ParentCompoment.OwnerID];
            // ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterHit()
        {
            var nextState = ParentCompoment.States[typeof(CHitState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterDead()
        {
            var nextState = ParentCompoment.States[typeof(CDeadState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }
    }
}