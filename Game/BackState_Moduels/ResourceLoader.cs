using AssetsPackage.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.BackState_Moduels
{
    public class ResourceLoader : CustomSingleton<ResourceLoader>
    {
        public T GetAssetCache<T>(string name) where T : Object
        {
            string path = "Assets/AssetsPackage/" + name;

            Object target = AssetDatabase.LoadAssetAtPath<T>(path);
            return target as T;
        }
        
        public T LoadCharactor<T>(string path) where T : Object
        {
            GameObject charactorPrefab = ResourceLoader.Singleton.GetAssetCache<GameObject>(path);
            GameObject charactor = GameObject.Instantiate(charactorPrefab);
            charactor.name = charactorPrefab.name;
            
            return charactor as T;
        }
        
        public T LoadUI<T>(string path) where T : Object
        {
            GameObject UIPrefab = GetAssetCache<GameObject>(path);
            GameObject UI = GameObject.Instantiate(UIPrefab);
            UI.name = UIPrefab.name;
        
            return UI as T;
        }
        
        public Material LoadMaterial(string materialName)
        {
            var path = materialName;
            Material material = GetAssetCache<Material>(path);
            return material;
        }

        public T LoadMap<T>(string mapName) where T : Object
        {
            var path = "4. Map/OnlyMap/" + mapName + "Map.prefab";
            GameObject mapPrefab = ResourceLoader.Singleton.GetAssetCache<GameObject>(path);
            GameObject map = GameObject.Instantiate(mapPrefab);
            map.name = mapPrefab.name;
            
            return map as T;
        }
    }
}