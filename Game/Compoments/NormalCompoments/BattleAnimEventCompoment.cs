using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class BattleAnimEventCompoment : CompomentData
    {
        public float AttackMagnification = 0;
        
        public bool AttackOn     = false;
        public bool InvincibleOn = false;
        public bool StiffnessOn  = false;

        public BattleAnimEvent BattleAnimEvent;
        
        public BattleAnimEventCompoment(GameObject charactor)
        {
            var model = FindGameObject.GetTransformInChildByName("Model", charactor.transform);
            this.BattleAnimEvent = model.AddComponent<BattleAnimEvent>();
            this.BattleAnimEvent.ParentCompomnet = this;
        }
    }

    public class BattleAnimEvent : MonoBehaviour
    {
        public BattleAnimEventCompoment ParentCompomnet;
        
        void DamageOn(float attackMagnification)
        {
            ParentCompomnet.AttackOn = true;
            ParentCompomnet.AttackMagnification = attackMagnification;
        }
        
        void DamageOff()
        {
            ParentCompomnet.AttackOn = false;
            ParentCompomnet.AttackMagnification = 0;
        }

        void InvincibleOn()
        {
            ParentCompomnet.InvincibleOn = true;
        }
        
        void InvincibleOff()
        {
            ParentCompomnet.InvincibleOn = false;
        }
    }
}