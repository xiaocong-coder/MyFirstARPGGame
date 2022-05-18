using AssetsPackage.Scripts.Game.BackState_Moduels;
using Unity.VisualScripting;
using UnityEngine;

namespace AssetsPackage.Scripts
{
    public class GameLaunch : MonoBehaviour
    {
        private void Awake()
        {
            this.name = "WorldGod";
            this.AddComponent<WorldGod>();
        }

        private void OnEnable()
        {
            GameObject.Destroy(this);
        }
    }
}