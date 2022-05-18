using UnityEngine;

namespace AssetsPackage.Scripts.SceneModel
{
    public class CubeSpawnZone : SpawnZone
    {
        public override Vector3 SpawnPoint
        {
            get
            {
                Vector3 p;
                p.x = Random.Range(-0.5f, 0.5f) * transform.localScale.x;
                p.y = Random.Range(-0.5f, 0.5f) * transform.localScale.y;
                p.z = Random.Range(-0.5f, 0.5f) * transform.localScale.z;

                return p + transform.position;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
