using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Game.Systems.UpdateSystems;
using AssetsPackage.Scripts.Utils;
using Unity.VisualScripting;

namespace AssetsPackage.Scripts.Game.CustomClasses.MainStates
{
    public class MStartupState : ARPGState
    {
        public MStartupState()
        {
            this.SystemList = new ARPGSystemInFrame[]
            {
                new DialogueWindowSystem(),
            };
        }
    }
}