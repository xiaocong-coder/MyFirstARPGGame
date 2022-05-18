using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.SceneModel;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class RandomPosCompoment : SingletonCompoment<RandomPosCompoment>
    {
        public RandomPosCompoment(Transform world)
        {
            Singlcomp = this;

            this.RandomPosList = new Dictionary<int, Vector3>();
            this.DelayTimer = new ARPGTimer(5f);

            var actionArea = FindGameObject.GetTransformInChildByName("EnemyActionArea", world);
            this.ActionArea = actionArea.GetComponent<SpawnZone>();
        }
        
        public Dictionary<int, Vector3> RandomPosList;
        public ARPGTimer DelayTimer;
        public SpawnZone ActionArea;
    }
}