using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class GameObjectCompoment : CompomentData
    {
        public GameObjectCompoment(GameObject charactorObject)
        {
            this.CharactorGameObject = charactorObject;

            this.DelayTimer = new ARPGTimer(4.0f);
        }

        public GameObject CharactorGameObject = null;

        public ARPGTimer DelayTimer = null;
    }
}