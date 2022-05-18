using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Game.CustomClasses.CubeStates;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class CheckPlaySystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var timeComp = GameTimeVelocityComponent.Singlcomp;

            // Check Click Pause
            {
                if (timeComp.ChangeDelayTimer.state != ARPGTimer.STATE.RUN)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        timeComp.LateTimeVelocity = timeComp.TimeVelocity;
                        timeComp.TimeVelocity = 0;
                        timeComp.ChangeDelayTimer.Go();

                        var allAnimators = AllEngineItemCompoment.Singlcomp.AllAnimators;
                        foreach (var animator in allAnimators)
                        {
                            animator.speed = 0;
                        }

                        var allRigidBody = AllEngineItemCompoment.Singlcomp.AllRigidBodys;
                        foreach (var rigidbody in allRigidBody)
                        {
                            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                        }

                        var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LPauseState)];
                        ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);   
                    }
                }
                
                timeComp.ChangeDelayTimer.Tick();
            }
        }

        public override void ExecuteOnLateUpdate()
        {
            base.ExecuteOnLateUpdate();

            var hunterIsDead = true;
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeHunterGroupID];
            entities.ForEach(entity =>
            {
                var stateComp = GetCompomentData<CubeHunterStateCompoment>(entity);

                if (stateComp.CurrentState != stateComp.States[typeof(CHDeadState)])
                {
                    hunterIsDead = false;
                }
            });

            var cubeIsDead = true;
            entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeGroupID];
            entities.ForEach(entity =>
            {
                var stateComp = GetCompomentData<CubeStateCompoment>(entity);

                if (stateComp.CurrentState != stateComp.States[typeof(CDeadState)])
                {
                    cubeIsDead = false;
                }
            });

            if (cubeIsDead)
            {
                ScoreCountCompoment.Singlcomp.IsPlayerWin = true;
                var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LWindUpState)];
                ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);
            }
            else if (hunterIsDead)
            {
                ScoreCountCompoment.Singlcomp.IsPlayerWin = false;
                var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LWindUpState)];
                ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);
            }
        }
    }
    
}