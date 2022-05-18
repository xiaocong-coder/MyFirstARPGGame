using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.CubeStates;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class EnemyControlSystem : ARPGSystemInFrame
    {
        public EnemyControlSystem()
        {
            this.EntitiesGroupID = ARPGEntitiesGroupID.CubeGroupID;
        }

        public override void ExecuteOnFixedUpdate()
        {
            base.ExecuteOnFixedUpdate();
            
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var timeComp        = GameTimeVelocityComponent.Singlcomp;
                var stateComp       = GetCompomentData<CubeStateCompoment>(entity);
                var attackComp      = GetCompomentData<AttackCompoment>(entity);
                var hitComp         = GetCompomentData<HitCompoment>(entity);
                var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
                var animEventComp   = GetCompomentData<BattleAnimEventCompoment>(entity);
                
                // Set Speed as TimeVelocity
                {
                    var animator = animtorComp.Animator;
                    animator.speed = timeComp.TimeVelocity;
                }

                // State Machine
                {
                    var state = stateComp.CurrentState;
                    state.ExecuteOnFixedUpdate(entity);
                }

                // Update Battle Trigger
                {
                    if (stateComp.CurrentState != stateComp.States[typeof(CDeadState)])
                    {
                        attackComp.Trigger.enabled = animEventComp.AttackOn;
                        hitComp.Trigger.enabled = !animEventComp.InvincibleOn;      
                    }
                }
            });
        }

        public override void ExecuteOnUpdate()
        {
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var stateComp       = GetCompomentData<CubeStateCompoment>(entity);

                // State Machine
                {
                    var state = stateComp.CurrentState;
                    state.ExecuteOnUpdate(entity);
                }
            });
        }

        public override void ExecuteOnLateUpdate()
        {
            base.ExecuteOnLateUpdate();
            
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var stateComp       = GetCompomentData<CubeStateCompoment>(entity);

                // State Machine
                {
                    var state = stateComp.CurrentState;
                    state.ExecuteOnLateUpdate(entity);
                }
            });
        }
    }
}