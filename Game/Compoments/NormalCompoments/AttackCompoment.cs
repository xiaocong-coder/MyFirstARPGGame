using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class AttackCompoment : CompomentData
    {
        public AttackCompoment(GameObject gameObject, float duration)
        {
            var AttackArea = gameObject.transform.Find("Model").Find("AttackArea");
            //AttackArea.gameObject.layer = LayerMask.NameToLayer("Attacker");
            this.AttackTrigger = AttackArea.AddComponent<AttackTrigger>();
            this.AttackTrigger.ParentCompoment = this;
            
            this.Trigger = AttackArea.GetComponent<Collider>();
            this.Trigger.enabled = false;

            this.DelayActionTimer = new ARPGTimer(duration);
        }

        public Collider Trigger = null;
        public AttackTrigger AttackTrigger = null;

        public ARPGTimer DelayActionTimer = null;
    }

    public class AttackTrigger : MonoBehaviour
    {
        public AttackCompoment ParentCompoment;
    }
}