using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public enum CharactorState
    {
        NoAwake,
        Ground,
        Attack,
        Dodge, 
        Hit,   
        Dead  
    }
    
    public class CharactorStateCompment : CompomentData
    {
        public bool EnterState = false;
        public bool StayState = false;
        public bool ExistState = false;

        public CharactorState State = CharactorState.NoAwake;
        public CharactorState PeriodState = CharactorState.NoAwake;
    }
}