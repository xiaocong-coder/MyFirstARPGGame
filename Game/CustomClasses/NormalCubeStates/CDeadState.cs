using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeStates
{
    public class CDeadState : ARPGSystemInState
    {
        public override void Enter(ARPGEntity entity)
        {
            base.Enter(entity);

            var attackComp   = GetCompomentData<AttackCompoment>(entity);
            var hitComp      = GetCompomentData<HitCompoment>(entity);
            var colliderComp = GetCompomentData<ColliderCompoment>(entity);
            var rigidComp    = GetCompomentData<RigidBodyCompoment>(entity);
            var gameObjComp  = GetCompomentData<GameObjectCompoment>(entity);
            var transComp    = GetCompomentData<TranslateCompoment>(entity);
            
            gameObjComp.DelayTimer.Go();
            
            rigidComp.RigidBody.useGravity = false;
            colliderComp.SelfCollider.enabled = false;
            attackComp.Trigger.enabled = false;
            hitComp.Trigger.enabled = false;

            // Reset MapGrid
            {
                var mapGridComp = MapGridsCompoment.Singlcomp;
                var x = transComp.MapGridX;
                var y = transComp.MapGridY;
                mapGridComp.MapGrids[x][y] = -1;
            }
        }

        public override void ExecuteOnUpdate(ARPGEntity entity)
        {
            base.ExecuteOnUpdate(entity);
            
            var gameObjComp  = GetCompomentData<GameObjectCompoment>(entity);

            gameObjComp.DelayTimer.Tick();
            if (gameObjComp.DelayTimer.state == ARPGTimer.STATE.FINISHED)
            {
                gameObjComp.CharactorGameObject.SetActive(false);   
            }
        }
    }
}