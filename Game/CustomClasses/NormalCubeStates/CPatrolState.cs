using System;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CPatrolState : ARPGSystemInState
    {
        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var timeComp        = GameTimeVelocityComponent.Singlcomp;
            var randomPosComp   = RandomPosCompoment.Singlcomp;
            var charProComp     = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var stateComp       = GetCompomentData<CubeStateCompoment>(entity);
            var transComp       = GetCompomentData<TranslateCompoment>(entity);
            var modelComp       = GetCompomentData<ModelCompoment>(entity);
            var targetComp      = GetCompomentData<TargetLockCompoment>(entity);
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            var rigidComp       = GetCompomentData<RigidBodyCompoment>(entity);
            
            var self = modelComp.Model;
            var viewDistance = charProComp.ViewDistance;
            var viewAngle = charProComp.ViewAngle;

            // Patrol
            {
                var targetPos = randomPosComp.RandomPosList[entity.EntityID];
                var selfPos   = self.position;
                targetPos = new Vector3(targetPos.x, selfPos.y, targetPos.z);
                if ((selfPos - targetPos).magnitude <= 1.0f)
                {
                    var nextState = stateComp.States[typeof(CIdleState)];    
                    ChangeState(ref stateComp.CurrentState, nextState, entity);
                }
                else
                {
                    var currentForward = ARPGMath.CorrectVectorNormalize(self.forward);
                    var targetForward  = ARPGMath.CorrectVectorNormalize(targetPos - selfPos);
                    modelComp.Model.forward = targetForward;//Vector3.Slerp(currentForward, targetForward, 0.3f);
                    var momentum = 1;
                
                    ARPGSetData.SetAnimMotionVelocity(animtorComp.Animator, momentum, timeComp.TimeVelocity);
                    ARPGSetData.SetRigidBodyVelocity(rigidComp.RigidBody, targetForward, momentum, charProComp.Speed);   
                }
            }
            
            // Get Target
            {
                var getTarget = TrySetTarget(targetComp, self, viewDistance, viewAngle);
                if (getTarget)
                {
                    var nextState = stateComp.States[typeof(CFollowUpState)];
                    ChangeState(ref stateComp.CurrentState, nextState, entity);
                }
            }
        }
        
        private bool TrySetTarget(TargetLockCompoment targetComp, Transform self, float viewDistance, float viewAngle)
        {
            var targetComfirmedList = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeHunterGroupID];
            for (int i = 0; i < targetComfirmedList.Count; i++)
            {
                var targetNotComfirmed = GetCompomentData<TranslateCompoment>(targetComfirmedList[i]).transform;
                if (ARPGMath.CheckInArea(targetNotComfirmed, self, viewDistance, viewAngle))
                {
                    targetComp.target = targetNotComfirmed;
                    return true;
                }
            }

            return false;
        }
    }
}