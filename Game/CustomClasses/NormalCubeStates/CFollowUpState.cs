using System;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CFollowUpState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);
            
            var aroundComp     = GetCompomentData<AroundTargetCompoment>(entity);
            var viewAreaComp   = GetCompomentData<ViewAreaCompoment>(entity);

            // Random Round
            {
                aroundComp.Direaction = Random.Range(-1.0f, 1.0f) <= 0 ? -1 : 1;
            }
            
            // View Area On
            {
                viewAreaComp.ViewRender.enabled = false;
            }
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var timeComp        = GameTimeVelocityComponent.Singlcomp;
            var charProComp     = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var transComp       = GetCompomentData<TranslateCompoment>(entity);
            var modelComp       = GetCompomentData<ModelCompoment>(entity);
            var rigidComp       = GetCompomentData<RigidBodyCompoment>(entity);
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            var targetComp      = GetCompomentData<TargetLockCompoment>(entity);
            var stateComp       = GetCompomentData<CubeStateCompoment>(entity);
            var aroundComp      = GetCompomentData<AroundTargetCompoment>(entity);

            var target = targetComp.target;
            var self = modelComp.Model;
            var viewDistance = charProComp.ViewDistance;
            var attackDistance = charProComp.AttackDistance;
            
            if (ARPGMath.CheckInDistance(target, self, viewDistance))
            {
                var targetPos = target.position;
                var selfPos   = self.position;
                var currentForward = ARPGMath.CorrectVectorNormalize(self.forward);
                var targetForward  = ARPGMath.CorrectVectorNormalize(targetPos - selfPos);

                if (ARPGMath.CheckInDistance(target, self, attackDistance))
                {
                    var nextState = stateComp.States[typeof(CAttackState)];
                    ChangeState(ref stateComp.CurrentState, nextState, entity);
                }
                else
                {
                    var roundForward = Vector3.Cross(Vector3.up, targetForward) * aroundComp.Direaction;
                    var finalForward = Vector3.Normalize(targetForward + roundForward);
                    var momentum = 2;

                    modelComp.Model.forward = targetForward;
                    ARPGSetData.SetAnimMotionVelocity(animtorComp.Animator, momentum, timeComp.TimeVelocity);
                    ARPGSetData.SetRigidBodyVelocity(rigidComp.RigidBody, finalForward, momentum, charProComp.Speed);
                }
            }
            else
            {
                targetComp.target = null;
                var nextState = stateComp.States[typeof(CIdleState)];
                ChangeState(ref stateComp.CurrentState, nextState, entity);
                ARPGSetData.SetAnimMotionVelocity(animtorComp.Animator, 0, timeComp.TimeVelocity);
            }
        }
    }
}