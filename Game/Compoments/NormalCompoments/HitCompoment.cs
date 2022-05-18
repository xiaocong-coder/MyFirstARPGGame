using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class HitCompoment : CompomentData
    {
        public HitCompoment(GameObject gameObject)
        {
            var HitArea = FindGameObject.GetTransformInChildByName("HitArea", gameObject.transform);
            //HitArea.gameObject.layer = LayerMask.NameToLayer("Hiter");
            this.HitTrigger = HitArea.AddComponent<HitTrigger>();
            this.HitTrigger.ParentCompoment = this;
            
            this.Trigger = HitArea.GetComponent<Collider>();
            this.Trigger.enabled = true;
        }
        
        public Collider Trigger;
        public HitTrigger HitTrigger;
    }

    public class HitTrigger : MonoBehaviour
    {
        public HitCompoment ParentCompoment;

        private void OnTriggerEnter(Collider other)
        {
            var attacker = other.GetComponent<AttackTrigger>();
            if (attacker != null)
            {
                var attackId = attacker.ParentCompoment.OwnerID;
                var hitId = ParentCompoment.OwnerID;

                if (attackId != hitId)
                {
                    var battleInfo = new BattleInfo
                    {
                        attackId = attackId,
                        hitId = hitId,
                        attackForward = attacker.transform.forward
                    };
             
                    SendBattleInfo(battleInfo);   
                }
            }
        }

        private void SendBattleInfo(BattleInfo battleInfo)
        {
            if (BattleInfoQueueCompoment.Singlcomp.BattleInfo == null)
            {
                BattleInfoQueueCompoment.Singlcomp.BattleInfo = battleInfo;
            }
            else
            {
                var id = BattleInfoQueueCompoment.Singlcomp.BattleInfo.attackId;
                var list = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeHunterGroupID];
                list.ForEach(entity =>
                {
                    if (entity.EntityID == id)
                    {
                        BattleInfoQueueCompoment.Singlcomp.BattleInfo = battleInfo;
                    }
                });
            }
        }
    }
}