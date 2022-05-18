using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    // public static class ARPGEntitiesGroupID
    // {
    //     public static int MainCharactorGroupID = ARPGEntitiesGroup.GenerateGroupID(
    //         typeof(GameTimeVelocityCompoment),
    //         typeof(TransformCompoment),
    //         typeof(RigidBodyCompoment),
    //         typeof(MovableDataCompoment)
    //     );
    //     
    //     public static int EnemyGroupID = ARPGEntitiesGroup.GenerateGroupID(
    //         typeof(GameTimeVelocityCompoment),
    //         typeof(TransformCompoment),
    //         typeof(RigidBodyCompoment),
    //         typeof(MovableDataCompoment)
    //     );
    //
    //     public static int CameraGroupID = ARPGEntitiesGroup.GenerateGroupID(
    //         typeof(GameTimeVelocityCompoment), 
    //         typeof(TransformCompoment),        
    //         typeof(MovableDataCompoment),      
    //         typeof(CameraCompoment),           
    //         typeof(PlayerSignalCompoment),     
    //         typeof(LookAtTargetCompoment),     
    //         typeof(FollowTargetCompoment)
    //     );
    // }

    public enum ARPGEntitiesGroupID
    {
        UIContainerGroupID,
        SingCompManager,
        CubeHunterGroupID,
        CubeGroupID,
        CameraGroupID
    }
}