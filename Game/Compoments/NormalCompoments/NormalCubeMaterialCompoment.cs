using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class NormalCubeMaterialCompoment : CompomentData
    {
        public NormalCubeMaterialCompoment()
        {
            this.selfMaterial = WorldGod.Singleton.loadMaterial<Material>("1. Charactor/Enemy/NormalCube/Materials/NormalCube.mat");
        }

        public Material selfMaterial = null;
    }
}