using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CAttackState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);
            
            var attackComp      = GetCompomentData<AttackCompoment>(entity);
            attackComp.DelayActionTimer.Reset();
            attackComp.DelayActionTimer.Go();
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var timeComp        = GameTimeVelocityComponent.Singlcomp;
            var transComp       = GetCompomentData<TranslateCompoment>(entity);
            var attackComp      = GetCompomentData<AttackCompoment>(entity);
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            var stateComp       = GetCompomentData<CubeStateCompoment>(entity);
            var charProComp     = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var targetComp      = GetCompomentData<TargetLockCompoment>(entity);
            var modelComp       = GetCompomentData<ModelCompoment>(entity);
            
            var target = targetComp.target;
            var self = modelComp.Model;
            var attackDistance = charProComp.AttackDistance;
            
            attackComp.DelayActionTimer.Tick();

            // Set Anim
            {
                var momentum = 0;
                ARPGSetData.SetAnimMotionVelocity(animtorComp.Animator, momentum, timeComp.TimeVelocity);
            }
            
            // Set Forward
            {
                var forward = ARPGMath.CorrectVectorNormalize(target.position - self.position);
                modelComp.Model.forward = forward;
            }
            
            
            if (!ARPGMath.CheckInDistance(target, self, attackDistance))
            {
                var nextState = stateComp.States[typeof(CIdleState)];
                ChangeState(ref stateComp.CurrentState, nextState, entity);
            }
            
            // Delay
            if (attackComp.DelayActionTimer.state != ARPGTimer.STATE.RUN)
            {
                animtorComp.Animator.SetTrigger(AnimationPropertiesCompoment.NormalAttack);
                attackComp.DelayActionTimer.Reset();
                attackComp.DelayActionTimer.Go();
            }
        }
    }
}