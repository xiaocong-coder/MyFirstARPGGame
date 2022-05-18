using System;
using System.Collections.Generic;
using AssetsPackage._2._Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public static class ARPGCompomentsGenerator
    {
        // UIContainer
        public static Dictionary<Type, ARPGCompoment> GetUIContainerCompoments(GameObject obj, int id)
        {
            var compoments = new Dictionary<Type, ARPGCompoment>
            {
                {typeof(UIContainCompoment), new UIContainCompoment()}
            };
            
            foreach (var compoment in compoments.Values)
            {
                compoment.OwnerID = id;
            }
            
            return compoments;
        }

        // LoadingSingCompManager
        public static Dictionary<Type, ARPGCompoment> GetLoadingSingCompManagerCompoment()
        {
            return new Dictionary<Type, ARPGCompoment>
            {
            };
        }
        
        // MainSingCompManager
        public static Dictionary<Type, ARPGCompoment> GetMainSingCompManagerCompoment()
        {
            return new Dictionary<Type, ARPGCompoment>
            {
                {typeof(MainResourceCacheCompoment),    new MainResourceCacheCompoment()}
            };
        }
        
        // LevelSingCompManager
        public static Dictionary<Type, ARPGCompoment> GetLevelSingCompManagerCompoment(Transform world)
        {
            return new Dictionary<Type, ARPGCompoment>
            {
                {typeof(GameTimeVelocityComponent),      new GameTimeVelocityComponent()},
                {typeof(LevelResourceCacheCompoment),    new LevelResourceCacheCompoment()},
                {typeof(KeyBoardInputCompoment),         new KeyBoardInputCompoment()},
                {typeof(PlayerSignalCompoment),          new PlayerSignalCompoment()},
                {typeof(AllEngineItemCompoment),         new AllEngineItemCompoment()},
                {typeof(BattleInfoQueueCompoment),       new BattleInfoQueueCompoment()},
                {typeof(ScoreCountCompoment),            new ScoreCountCompoment()},
                {typeof(RandomPosCompoment),             new RandomPosCompoment(world)},
                {typeof(MapGridsCompoment),              new MapGridsCompoment(100)},
                {typeof(StoryCacheCompoment),            new StoryCacheCompoment()},
            };
        }
        
        // MainCharactor
        public static Dictionary<Type, ARPGCompoment> GetCubeHunterCompoments(GameObject charactorObject, int id)
        {
            var compoments = new Dictionary<Type, ARPGCompoment>
            {
                {typeof(GameTimeVelocityComponent),      GameTimeVelocityComponent.Singlcomp},
                {typeof(CubeHunterStateCompoment),       new CubeHunterStateCompoment(charactorObject)},
                {typeof(CharactorPorpertiesCompment),    new CharactorPorpertiesCompment(Faction.CubeHunter)},
                {typeof(ModelCompoment),                 new ModelCompoment(charactorObject)},
                {typeof(BattleAnimEventCompoment),       new BattleAnimEventCompoment(charactorObject)},
                {typeof(TranslateCompoment),             new TranslateCompoment(charactorObject)},
                {typeof(AnimatorCompoment),              new AnimatorCompoment(charactorObject)},
                {typeof(RigidBodyCompoment),             new RigidBodyCompoment(charactorObject)},
                {typeof(NavigateCompoment),              new NavigateCompoment(charactorObject)},
                {typeof(AttackCompoment),                new AttackCompoment(charactorObject, 1f)},
                {typeof(HitCompoment),                   new HitCompoment(charactorObject)},
                {typeof(TargetLockCompoment),            new TargetLockCompoment()}
            };
            
            foreach (var compoment in compoments.Values)
            {
                compoment.OwnerID = id;
            }

            return compoments;
        }
        // End
        
        // Enemy
        public static Dictionary<Type, ARPGCompoment> GetNormalCubeCompoments(GameObject charactorObject, int id)
        {
            var compoments = new Dictionary<Type, ARPGCompoment>
            {
                {typeof(GameTimeVelocityComponent),      GameTimeVelocityComponent.Singlcomp},
                {typeof(GameObjectCompoment),            new GameObjectCompoment(charactorObject)},
                {typeof(CharactorPorpertiesCompment),    new CharactorPorpertiesCompment(Faction.Cube)},
                {typeof(ModelCompoment),                 new ModelCompoment(charactorObject)},
                {typeof(CubeStateCompoment),             new CubeStateCompoment(charactorObject)},
                {typeof(TranslateCompoment),             new TranslateCompoment(charactorObject)},
                {typeof(ColliderCompoment),              new ColliderCompoment(charactorObject)},
                {typeof(RigidBodyCompoment),             new RigidBodyCompoment(charactorObject)},
                {typeof(AttackCompoment),                new AttackCompoment(charactorObject, 3f)},
                {typeof(HitCompoment),                   new HitCompoment(charactorObject)},
                {typeof(AnimatorCompoment),              new AnimatorCompoment(charactorObject)},
                {typeof(BattleAnimEventCompoment),       new BattleAnimEventCompoment(charactorObject)},
                {typeof(TargetLockCompoment),            new TargetLockCompoment()},
                {typeof(AutoMoveCompoment),              new AutoMoveCompoment()},
                {typeof(AroundTargetCompoment),          new AroundTargetCompoment()},
                
                // Render comp
                {typeof(NormalCubeMaterialCompoment),    new NormalCubeMaterialCompoment()},
                {typeof(ViewAreaCompoment),              new ViewAreaCompoment(charactorObject)}
            };

            foreach (var compoment in compoments.Values)
            {
                compoment.OwnerID = id;
            }

            return compoments;
        }
        // End
        
        // Camera
        public static Dictionary<Type, ARPGCompoment> GetMainCameraCompoments(Camera camera, GameObject navigator, int id)
        {
            var compoments = new Dictionary<Type, ARPGCompoment>
            {
                {typeof(GameTimeVelocityComponent),     GameTimeVelocityComponent.Singlcomp},
                {typeof(PlayerSignalCompoment),         PlayerSignalCompoment.Singlcomp},
                {typeof(CameraCompoment),               new CameraCompoment(camera)},
                {typeof(TranslateCompoment),            new TranslateCompoment(camera.gameObject)},
                {typeof(MovablePropertiesCompoment),    new MovablePropertiesCompoment()},
                {typeof(LookAtTargetCompoment),         new LookAtTargetCompoment(navigator)},
                {typeof(CameraFollowCompoment),         new CameraFollowCompoment(navigator)},
                {typeof(NavigateCompoment),             new NavigateCompoment(navigator)}
            };
            foreach (var compoment in compoments.Values)
            {
                compoment.OwnerID = id;
            }

            return compoments;
        }

        public static void SetCompomentID(List<ARPGCompoment> compoments, int id)
        {
            foreach (var compoment in compoments)
            {
                compoment.OwnerID = id;
            }
        }
    }
}