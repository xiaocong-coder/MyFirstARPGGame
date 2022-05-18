using UnityEngine;

namespace AssetsPackage.Scripts.Tool
{
    public static class FindGameObject
    {
        public static Transform GetTransformInChildByName(string name, Transform transform)
        {
            var list = transform.GetComponentsInChildren<Transform>();
        
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].name == name)
                {
                    return list[i];
                }
            }

            return null;
        }
    }
}