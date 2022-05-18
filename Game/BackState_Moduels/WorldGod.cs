using System;
using AssetsPackage.Scripts.Game.CustomClasses.BackGroundState;
using AssetsPackage.Scripts.Game.Worlds;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AssetsPackage.Scripts.Game.BackState_Moduels
{
    public class WorldGod : UnitySingleton<WorldGod>
    {
        public ResourceLoader resourceLoader;

        public ARPGWorld CurrentWorld;
        public ARPGWorld BackGroundWorld;

        public override void Awake()
        {
            base.Awake();
            
            LoadResourceLoader();
            LoadBackGroundWorld();
            EnterMain();
        }

        private void Start()
        {
            ShowLoadingUI();
        }

        public void LoadResourceLoader()
        {
            this.resourceLoader = new ResourceLoader();    
        }
        
        public void LoadBackGroundWorld()
        {
            var path = "4. Map/BackGroundWorld/" + "BackGroundWorld" + ".prefab";
            var backGroundWorld = EnterMap(path);

            this.BackGroundWorld = backGroundWorld.AddComponent<BackGroundWorld>();
        }
        
        public void EnterMain()
        {
            var map = EnterStartupMap("StartupMap");
            var levelIndex = ExcelLoader.Singleton.GetAllLevelNums;
            var levelName = "GameLevel" + Random.Range(1, levelIndex + 1);
            var background = ResourceLoader.Singleton.LoadMap<GameObject>(levelName);
            background.transform.parent = map.transform.Find("BackGround").transform;
            
            var cameraPos = background.transform.Find("LoadMapCenter");
            Camera.main.transform.position = cameraPos.position;
            
            this.CurrentWorld = map.AddComponent<MainMap>();
            ShowLoadingUI();
        }
        
        public void EnterLevel(string levelName)
        {
            var map = EnterGameLevelMap(levelName);
            var mapTransform = map.transform;
        
            var uiContainer = new GameObject("UIContainer");
            uiContainer.transform.parent = mapTransform;

            this.CurrentWorld = map.AddComponent<LevelMap>();
            ShowLoadingUI();
        }
        
        public GameObject EnterGameLevelMap(string levelName)
        {
            var path = "4. Map/LevelMap/" + levelName + ".prefab";
            return this.EnterMap(path);
        }

        public GameObject EnterStartupMap(string loadMapName)
        {
            var path = "4. Map/StartupMap/" + loadMapName + ".prefab";
            return this.EnterMap(path);
        }

        private GameObject EnterMap(string path)
        {
            // Load Map
            GameObject mapPrefab = ResourceLoader.Singleton.GetAssetCache<GameObject>(path);
            GameObject map = GameObject.Instantiate(mapPrefab);
            map.name = mapPrefab.name;
        
            if (map != null)
            {
                DestoryMap();
                return map;
            }
        
            return null;
        }

        public void ShowLoadingUI()
        {
            ARPGState.ChangeState(ref this.BackGroundWorld.CurrentState, this.BackGroundWorld.AllLevelStates[typeof(BGLoadingState)]);
        }
        
        public void CloseLoadingUI()
        {
            ARPGState.ChangeState(ref this.BackGroundWorld.CurrentState, this.BackGroundWorld.AllLevelStates[typeof(BGIdelState)]);
        }
        
        public T LoadEffect<T>(string name) where T : Object
        {
            var path = "6. Effects/" + name + ".prefab";
            GameObject effectPrefab = ResourceLoader.Singleton.GetAssetCache<GameObject>(path);
            GameObject effect = GameObject.Instantiate(effectPrefab);
        
            return effect as T;
        }

        public T LoadMainCharactor<T>(string name) where T : Object
        {
            var path = "1. Charactor/MainCharactor/CubeHunter/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadCharactor<T>(path);
        }
        
        public T LoadEnemy<T>(string name) where T : Object
        {
            var path = "1. Charactor/Enemy/" + name + "/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadCharactor<T>(path);
        }

        public T LoadStartupUI<T>(string name) where T : Object
        {
            var path = "5. GUI/StartupUI/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadUI<T>(path);
        }
        
        public T LoadGameLevelSelectUI<T>(string name) where T : Object
        {
            var path = "5. GUI/GameLevelSelectUI/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadUI<T>(path);
        }
        
        public T LoadMainGameUI<T>(string name) where T : Object
        {
            var path = "5. GUI/GameUI/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadUI<T>(path);
        }

        public T LoadUI<T>(string name) where T : Object
        {
            var path = "5. GUI/" + name + ".prefab";
            return ResourceLoader.Singleton.LoadUI<T>(path);
        }

        public Material loadMaterial<T>(string name) where T : Object
        {
            var path = name;
            return ResourceLoader.Singleton.LoadMaterial(path);
        }

        public void DestoryMap()
        {
            if (CurrentWorld)
            {
                GameObject.Destroy(CurrentWorld.gameObject);   
            }
        }
    }
}