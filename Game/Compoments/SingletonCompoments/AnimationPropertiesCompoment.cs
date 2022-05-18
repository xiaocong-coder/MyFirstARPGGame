using System.Collections.Generic;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class AnimationPropertiesCompoment : SingletonCompoment<AnimationPropertiesCompoment>
    {
        public static readonly int Attack         = Animator.StringToHash("Attack");
        public static readonly int Dodge          = Animator.StringToHash("Dodge");
        public static readonly int Hit            = Animator.StringToHash("Hit");
        public static readonly int Dead           = Animator.StringToHash("Dead");
        public static readonly int NormalAttack   = Animator.StringToHash("NormalAttack");
        public static readonly int HardAttack     = Animator.StringToHash("HardAttack");
        public static readonly int MotionVelocity = Animator.StringToHash("MotionVelocity");
    }
}