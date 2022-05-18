using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates
{
    public class CHGroundState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);
            
            var animEventComp   = GetCompomentData<BattleAnimEventCompoment>(entity);
            animEventComp.AttackOn = false;
            animEventComp.InvincibleOn = false;
            animEventComp.StiffnessOn = false;
        }

        public override void ExecuteOnFixedUpdate(ARPGEntity entity)
        {
            base.ExecuteOnFixedUpdate(entity);
                        
            var pInput = PlayerSignalCompoment.Singlcomp;         
            var charProComp     = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var rigidComp       = GetCompomentData<RigidBodyCompoment>(entity);          
            var naviComp        = GetCompomentData<NavigateCompoment>(entity);        

            {
                var momentum = pInput.dMagnitude * (pInput.RunSignal ? 3 : 1);

                var navigationalForward = naviComp.Navigator.forward;
                var navigationalRight   = naviComp.Navigator.right;
                var navigationalUp      = naviComp.Navigator.up;
                var motionForward       = pInput.dVector.x * navigationalRight
                                               + pInput.dVector.y * navigationalUp
                                               + pInput.dVector.z * navigationalForward;
             
                var velocity = rigidComp.RigidBody.velocity;
                velocity  = Vector3.up * velocity.y;
                velocity += motionForward * momentum * charProComp.Speed;
                rigidComp.RigidBody.velocity = velocity;
            }
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var timeComp        = GameTimeVelocityComponent.Singlcomp;                
            var pInput = PlayerSignalCompoment.Singlcomp;                             
            var modelComp       = GetCompomentData<ModelCompoment>(entity);         
            var naviComp        = GetCompomentData<NavigateCompoment>(entity);        
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            var targetComp      = GetCompomentData<TargetLockCompoment>(entity);

            if (pInput.NormalAttackSignal)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.NormalAttack);
                if (targetComp.target != null)
                {
                    var forward = targetComp.target.position - modelComp.Model.position;
                    forward = ARPGMath.CorrectVectorNormalize(forward);
                    modelComp.Model.forward = forward;
                }
            }
            else if (pInput.HardAttackSignal)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.HardAttack);
                if (targetComp.target != null)
                {
                    var forward = targetComp.target.position - modelComp.Model.position;
                    forward = ARPGMath.CorrectVectorNormalize(forward);
                    modelComp.Model.forward = forward;
                }
            }
            else if (pInput.DodgeSignal)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.Dodge);
            }
            else
            {
                var momentum = pInput.dMagnitude * (pInput.RunSignal ? 3 : 1);

                animtorComp.Animator.SetFloat(
                    AnimationPropertiesCompoment.MotionVelocity,
                    Mathf.Lerp(
                        animtorComp.Animator.GetFloat(AnimationPropertiesCompoment.MotionVelocity),
                        momentum,
                        timeComp.TimeVelocity * 0.2f
                    )
                );

                var navigationalForward = naviComp.Navigator.forward;
                var navigationalRight = naviComp.Navigator.right;
                var navigationalUp = naviComp.Navigator.up;
                var motionForward = pInput.dVector.x * navigationalRight
                                         + pInput.dVector.y * navigationalUp
                                         + pInput.dVector.z * navigationalForward;

                var model = modelComp.Model;
                model.forward = Vector3.Slerp(model.forward, motionForward.normalized, timeComp.TimeVelocity * 0.2f);
            }
        }
    }
}