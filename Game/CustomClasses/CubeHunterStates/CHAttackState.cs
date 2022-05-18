using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates
{
    public class CHAttackState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);

            var targetComp  = GetCompomentData<TargetLockCompoment>(entity);
            var rigidComp   = GetCompomentData<RigidBodyCompoment>(entity);
            var charProComp = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var modelComp   = GetCompomentData<ModelCompoment>(entity);

            rigidComp.RigidBody.velocity = new Vector3(0, rigidComp.RigidBody.velocity.y, 0);
            
            if (targetComp.target != null)
            {
                var vector = targetComp.target.position - rigidComp.RigidBody.position;
                var distance = vector.magnitude;

                if (distance >= charProComp.AttackDistance)
                {
                    var forward = ARPGMath.CorrectVectorNormalize(vector);
                    rigidComp.RigidBody.velocity += forward * 5;

                    modelComp.Model.forward = forward;
                }
            }
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var pInput = PlayerSignalCompoment.Singlcomp;
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            
            if (pInput.NormalAttackSignal)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.NormalAttack);
            }
            else if (pInput.HardAttackSignal)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.HardAttack);
            }
        }
    }
}