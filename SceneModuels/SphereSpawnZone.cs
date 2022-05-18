using UnityEngine;

namespace AssetsPackage.Scripts.SceneModel
{
    public class SphereSpawnZone : SpawnZone
    {
        public override Vector3 SpawnPoint
        {
            get
            {
                var p = transform.position;
                p.x += Random.insideUnitSphere.x * transform.localScale.x;
                p.y += Random.insideUnitSphere.y * transform.localScale.y;
                p.z += Random.insideUnitSphere.z * transform.localScale.z;
            
                return p;
            }
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(Vector3.zero, 1f);
        }
    }
}