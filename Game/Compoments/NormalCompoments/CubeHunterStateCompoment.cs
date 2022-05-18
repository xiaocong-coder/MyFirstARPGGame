using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class CubeHunterStateCompoment : CompomentData
    {
        public CubeHunterStateCompoment(GameObject charactor)
        {
            this.States = new Dictionary<Type, ARPGSystemInState>()
            {
                { typeof(CHNoAwakeState) , new CHNoAwakeState()},
                { typeof(CHGroundState ) , new CHGroundState()},
                { typeof(CHAttackState ) , new CHAttackState()},
                { typeof(CHHitState    ) , new CHHitState()},
                { typeof(CHDodgeState  ) , new CHDodgeState()},
                { typeof(CHDeadState   ) , new CHDeadState()}
            };

            this.CurrentState = States[typeof(CHNoAwakeState)];
            
            var model = FindGameObject.GetTransformInChildByName("Model", charactor.transform);
            this.CubeHunterStateAnimEvent = model.AddComponent<CubeHunterStateAnimEvent>();
            this.CubeHunterStateAnimEvent.ParentCompoment = this;
        }

        public CubeHunterStateAnimEvent CubeHunterStateAnimEvent;
        
        public Dictionary<Type, ARPGSystemInState> States;
        public ARPGSystemInState CurrentState;
    }

    public class CubeHunterStateAnimEvent : MonoBehaviour
    {
        public CubeHunterStateCompoment ParentCompoment;
        
        void EnterGround()
        {
            var nextState = ParentCompoment.States[typeof(CHGroundState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterAttack()
        {
            var nextState = ParentCompoment.States[typeof(CHAttackState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterDodge()
        {
            var nextState = ParentCompoment.States[typeof(CHDodgeState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterHit()
        {
            var nextState = ParentCompoment.States[typeof(CHHitState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }

        void EnterDead()
        {
            var nextState = ParentCompoment.States[typeof(CHDeadState)];
            var entity = WorldGod.Singleton.CurrentWorld.EntitiesList[ParentCompoment.OwnerID];
            ARPGSystemInState.ChangeState(ref ParentCompoment.CurrentState, nextState, entity);
        }
    }
}