using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class PausingSystem : ARPGSystemInFrame
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
                        timeComp.TimeVelocity = timeComp.LateTimeVelocity;
                        timeComp.LateTimeVelocity = timeComp.TimeVelocity;
                        
                        var allAnimators = AllEngineItemCompoment.Singlcomp.AllAnimators;
                        foreach (var animator in allAnimators)
                        {
                            animator.speed = 1;
                        }

                        var allRigidBody = AllEngineItemCompoment.Singlcomp.AllRigidBodys;
                        foreach (var rigidbody in allRigidBody)
                        {
                            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                        }

                        var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LPlayState)];
                        ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);
                    }   
                }
                
                timeComp.ChangeDelayTimer.Tick();
            }
        }
    }
}