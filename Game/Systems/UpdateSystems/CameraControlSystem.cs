using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class CameraControlSystem : ARPGSystemInFrame
    {
        public CameraControlSystem()
        {
            this.EntitiesGroupID = ARPGEntitiesGroupID.CameraGroupID;
        }
        
        public override void ExecuteOnFixedUpdate()
        {
            base.ExecuteOnFixedUpdate();

            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach((entity =>
            {
                var timeComp        = GameTimeVelocityComponent.Singlcomp;
                var inputSignalComp = PlayerSignalCompoment.Singlcomp;
                var transComp       = GetCompomentData<TranslateCompoment>(entity);
                var moveComp        = GetCompomentData<MovablePropertiesCompoment>(entity);
                var lookAtComp      = GetCompomentData<LookAtTargetCompoment>(entity);
                var followComp      = GetCompomentData<CameraFollowCompoment>(entity);
                var navigaComp      = GetCompomentData<NavigateCompoment>(entity);

                // Rotate With X Axis
                {
                    var timeVelocity = timeComp.TimeVelocity;
                    
                    lookAtComp.RotationWithXAxis += inputSignalComp.dViewUp * Time.fixedDeltaTime * lookAtComp.VerticalSpeed * timeVelocity;
                    lookAtComp.RotationWithXAxis = Mathf.Clamp(lookAtComp.RotationWithXAxis, -30, 40);
                    var target = lookAtComp.LookAtTarget;
                    target.localEulerAngles = new Vector3(lookAtComp.RotationWithXAxis, 0, 0);
                }
                
                // Rotate With Y Axis
                {
                    var timeVelocity = timeComp.TimeVelocity;
                    var transform = navigaComp.Navigator;
                    var tempModelRotation = transform.rotation;
        
                    transform.Rotate(
                        Vector3.up, 
                        inputSignalComp.dViewRight * Time.fixedDeltaTime * navigaComp.HorizontalSpeed * timeVelocity
                    );
                }

                // Follow
                {
                    var currentPos  = transComp.transform.position;
                    var followPos   = followComp.FollowTransform.position;
                    var targetPos   = lookAtComp.LookAtTarget.position;
                    var speed          = moveComp.MoveSpeed;
                
                    transComp.transform.position = Vector3.Lerp(currentPos, followPos, 0.8f * speed);
                    transComp.transform.LookAt(targetPos);
                }
            }));
        }
    }
}