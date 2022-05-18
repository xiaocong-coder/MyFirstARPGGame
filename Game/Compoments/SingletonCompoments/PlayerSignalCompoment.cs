using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class PlayerSignalCompoment : SingletonCompoment<PlayerSignalCompoment>
    {
        public PlayerSignalCompoment()
        {
            Singlcomp = this;
        }
        
        public float dForward;
        public float dRight;
        public float targetDForward;
        public float targetDRight;
        public float dForwardVelocity;
        public float dRightVelocity;
        public float dMagnitude;
        
        public Vector3 dVector;
        public Vector2 circleVector;
    
        public float dViewUp;
        public float dViewRight;
        
        public bool RunSignal;         
        public bool DodgeSignal;       
        public bool NormalAttackSignal;
        public bool HardAttackSignal;
    }
}