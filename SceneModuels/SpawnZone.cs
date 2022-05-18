using UnityEngine;

namespace AssetsPackage.Scripts.SceneModel
{
    public abstract class SpawnZone : MonoBehaviour
    {
        public abstract Vector3 SpawnPoint { get; }

        // private void OnEnable()
        // {
        //     Destroy(this.gameObject);
        // }
    }
}
