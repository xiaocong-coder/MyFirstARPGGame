using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class PlayerControlSystem : ARPGSystemInFrame
    {
        public PlayerControlSystem()
        {
            this.EntitiesGroupID = ARPGEntitiesGroupID.CubeHunterGroupID;
        }
        
        public override void ExecuteOnFixedUpdate()
        {
            base.ExecuteOnFixedUpdate();
            
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var stateComp       = GetCompomentData<CubeHunterStateCompoment>(entity);
                var attackComp      = GetCompomentData<AttackCompoment>(entity);
                var hitComp         = GetCompomentData<HitCompoment>(entity);
                var animEventComp   = GetCompomentData<BattleAnimEventCompoment>(entity);

                // State Machine
                {
                    var state = stateComp.CurrentState;
                    state.ExecuteOnFixedUpdate(entity);
                }
                
                // Update battle Trigger
                {
                    if (stateComp.CurrentState != stateComp.States[typeof(CHDeadState)])
                    {
                        attackComp.Trigger.enabled = animEventComp.AttackOn;
                        hitComp.Trigger.enabled = !animEventComp.InvincibleOn;
                    }
                }
            });
        }

        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();

            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var timeComp        = GameTimeVelocityComponent.Singlcomp;
                var animatorComp     = GetCompomentData<AnimatorCompoment>(entity);
                var stateComp       = GetCompomentData<CubeHunterStateCompoment>(entity);

                // Set Speed as TimeVelocity
                {
                    var animator = animatorComp.Animator;
                    animator.speed = timeComp.TimeVelocity;
                }
                
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
                var stateComp = GetCompomentData<CubeHunterStateCompoment>(entity);
                
                // State Machine
                {
                    var state = stateComp.CurrentState;
                    state.ExecuteOnLateUpdate(entity);
                }
            });
        }
    }
}