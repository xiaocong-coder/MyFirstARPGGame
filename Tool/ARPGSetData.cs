using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using UnityEngine;

namespace AssetsPackage.Scripts.Tool
{
    public static class ARPGSetData
    {
        public static void SetAnimMotionVelocity(Animator animator, float momentum, float timeVelocity)
        {
            animator.SetFloat(
                AnimationPropertiesCompoment.MotionVelocity,
                Mathf.Lerp(
                    animator.GetFloat(AnimationPropertiesCompoment.MotionVelocity),
                    momentum,
                    timeVelocity * 0.2f
                )
            );
        }

        public static void SetRigidBodyVelocity(Rigidbody rigidbody, Vector3 motionForward, float momentum, float speed)
        {
            var velocity = rigidbody.velocity;
            velocity  = Vector3.up * velocity.y;
            velocity += motionForward * momentum * speed;
            rigidbody.velocity = velocity;
        }
    }
}