using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates
{
    public class CHDodgeState : ARPGSystemInState
    {
        public override void ExecuteOnFixedUpdate(ARPGEntity entity)
        {
            base.ExecuteOnFixedUpdate(entity);

            var playSignalComp              = PlayerSignalCompoment.Singlcomp;
            var rigidComp                   = GetCompomentData<RigidBodyCompoment>(entity);
            var modelComp                   = GetCompomentData<ModelCompoment>(entity);
            var charProComp                 = GetCompomentData<CharactorPorpertiesCompment>(entity);
                                            
            var forward = modelComp.Model.forward;
            var speed = charProComp.Speed * (playSignalComp.RunSignal ? 3 : 1);
            var velocity = new Vector3();
            velocity = forward * speed;
            velocity.y = rigidComp.RigidBody.velocity.y;
            
            rigidComp.RigidBody.velocity = velocity;
        }
    }
}