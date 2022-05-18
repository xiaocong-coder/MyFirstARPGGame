using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CIdleState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);

            var autoMoveComp    = GetCompomentData<AutoMoveCompoment>(entity);
            var viewAreaComp    = GetCompomentData<ViewAreaCompoment>(entity);
            
            // Timer go
            {
                autoMoveComp.DelayTimer.Go();
            }

            // View Area on
            {
                viewAreaComp.ViewRender.enabled = true;
            }
            
        }

        public override void ExecuteOnFixedUpdate(ARPGEntity entity)
        {
            base.ExecuteOnFixedUpdate(entity);
            
            var timeComp        = GameTimeVelocityComponent.Singlcomp;
            var animtorComp     = GetCompomentData<AnimatorCompoment>(entity);
            
            var momentum = 0;
            ARPGSetData.SetAnimMotionVelocity(animtorComp.Animator, momentum, timeComp.TimeVelocity);
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var randomPosComp   = RandomPosCompoment.Singlcomp;
            var charProComp     = GetCompomentData<CharactorPorpertiesCompment>(entity);
            var stateComp       = GetCompomentData<CubeStateCompoment>(entity);
            var transComp       = GetCompomentData<TranslateCompoment>(entity);
            var modelComp       = GetCompomentData<ModelCompoment>(entity);
            var targetComp      = GetCompomentData<TargetLockCompoment>(entity);
            var autoMoveComp    = GetCompomentData<AutoMoveCompoment>(entity);
            
            var self = modelComp.Model;
            var viewDistance = charProComp.ViewDistance;
            var viewAngle = charProComp.ViewAngle;
            
            autoMoveComp.DelayTimer.Tick();

            if (targetComp.target != null)
            {
                var nextState = stateComp.States[typeof(CFollowUpState)];
                ChangeState(ref stateComp.CurrentState, nextState, entity);
            }
            else if (targetComp.target == null)
            {
                if (autoMoveComp.DelayTimer.state == ARPGTimer.STATE.FINISHED)
                {
                    if (randomPosComp.RandomPosList.ContainsKey(entity.EntityID))
                    {
                        var nextState = stateComp.States[typeof(CPatrolState)];
                        ChangeState(ref stateComp.CurrentState, nextState, entity);
                        
                        autoMoveComp.DelayTimer.Reset();
                        return;
                    }
                }

                TrySetTarget(targetComp, self, viewDistance, viewAngle);
            }
        }

        public override void ExecuteOnLateUpdate(ARPGEntity entity)
        {
            base.ExecuteOnLateUpdate(entity);
            
            var randomPosComp = RandomPosCompoment.Singlcomp;
            randomPosComp.DelayTimer.Tick();
            
            if (randomPosComp.DelayTimer.state == ARPGTimer.STATE.IDLE)
            {
                randomPosComp.DelayTimer.Go();
                
                var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeGroupID];
                entities.ForEach(entity =>
                {
                    var randPos = randomPosComp.ActionArea.SpawnPoint;
                    
                    var id = entity.EntityID;
                    if (!randomPosComp.RandomPosList.ContainsKey(id))
                    {
                        randomPosComp.RandomPosList.Add(id, randPos);     
                    }
                    else
                    {
                        randomPosComp.RandomPosList[id] = randPos;
                    }
                });       
            }
        }

        public override void Exist(ARPGEntity entity)
        {
            base.Exist(entity);
            
            var randomPosComp = RandomPosCompoment.Singlcomp;
            randomPosComp.DelayTimer.Reset();
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