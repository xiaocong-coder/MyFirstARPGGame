using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Game.CustomClasses.CubeStates;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class BattleSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var battleInfoComp = BattleInfoQueueCompoment.Singlcomp;
            var timeComp   = GameTimeVelocityComponent.Singlcomp; 
            
            // Refresh Double Hit
            {
                battleInfoComp.DoubleHitRefreshCountTimer.Tick();
                if (battleInfoComp.DoubleHitRefreshCountTimer.state != ARPGTimer.STATE.RUN)
                {
                    battleInfoComp.DoubieHitCount = 0;
                }
            }

            // Update UI
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var uiContainComp = GetCompomentData<UIContainCompoment>(entity);

                var playUI = uiContainComp.UIContainer[typeof(PlayUI)] as PlayUI;

                var doubleHit = "Double Hit\n" + battleInfoComp.DoubieHitCount;
                if (playUI != null) 
                    playUI.DoubleHit.text = doubleHit;

                if (battleInfoComp.DoubieHitCount == 0)
                {
                    if (playUI != null)
                    {
                        playUI.DoubleHit.enabled = false;
                        playUI.DoubleHitBackground.enabled = false;
                    }
                }
                else
                {
                    if (playUI != null)
                    {
                        playUI.DoubleHit.enabled = true;
                        playUI.DoubleHitBackground.enabled = true;
                    }
                }
            });
            
            if (battleInfoComp.BattleInfo != null)
            {
                var battleInfo = battleInfoComp.BattleInfo;
                
                var attackEntity = WorldGod.Singleton.CurrentWorld.EntitiesList[battleInfo.attackId];
                var hitEntity    = WorldGod.Singleton.CurrentWorld.EntitiesList[battleInfo.hitId];

                var hitChar    = GetCompomentData<CharactorPorpertiesCompment>(hitEntity);
                var attackChar = GetCompomentData<CharactorPorpertiesCompment>(attackEntity);
                
                if (hitChar.Faction != attackChar.Faction)
                {
                    if (attackChar.Faction == Faction.CubeHunter)
                    {
                        battleInfoComp.DoubleHitRefreshCountTimer.Go();
                        battleInfoComp.DoubieHitCount++;

                        battleInfoComp.SlowDownTimer.Go();
                        timeComp.LateTimeVelocity = timeComp.TimeVelocity;
                        timeComp.TimeVelocity = 0.0f;
                    }

                    if (hitChar.Faction == Faction.Cube)
                    {
                        var transComp  = GetCompomentData<TranslateCompoment>(attackEntity);
                        var targetComp = GetCompomentData<TargetLockCompoment>(hitEntity);

                        targetComp.target = transComp.transform;
                    }
                    
                    // Attack
                    {
                    
                    }
                    
                    // Hit
                    {
                        var attackAnimEventComp = GetCompomentData<BattleAnimEventCompoment>(attackEntity);
                        var animComp            = GetCompomentData<AnimatorCompoment>(hitEntity);
                        var rigidComp           = GetCompomentData<RigidBodyCompoment>(hitEntity);

                        hitChar.HP -= attackChar.Attack * attackAnimEventComp.AttackMagnification;
                        if (hitChar.HP <= 0)
                        {
                            animComp.Animator.SetTrigger(AnimationPropertiesCompoment.Dead);
                        }
                        else
                        {
                            animComp.Animator.SetTrigger(AnimationPropertiesCompoment.Hit);
                            rigidComp.RigidBody.velocity += battleInfo.attackForward * 2;
                        }
                    }   
                }
            }

            // Time Slow Down
            {
                battleInfoComp.SlowDownTimer.Tick();
                if (battleInfoComp.SlowDownTimer.state == ARPGTimer.STATE.FINISHED)
                {
                    timeComp.TimeVelocity = 1.0f;
                }
                
                Debug.Log(timeComp.TimeVelocity);
            }
            
            battleInfoComp.BattleInfo = null;
        }
    }
}