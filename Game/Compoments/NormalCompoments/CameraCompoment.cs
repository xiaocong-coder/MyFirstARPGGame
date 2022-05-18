using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class CameraCompoment : ARPGCompoment
    {
        public CameraCompoment(Camera camera)
        {
            this.GameCamera = camera;
        }
        
        public Camera GameCamera;
    }
}