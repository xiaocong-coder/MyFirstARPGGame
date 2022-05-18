namespace AssetsPackage.Scripts.Utils
{
    public abstract class ARPGState
    {
        public ARPGSystemInFrame[] SystemList;

        public static DefaultState DefaultState = new DefaultState();
        
        public virtual void Enter(){}
        public virtual void Exist(){}
        
        public static void ChangeState(ref ARPGState currentState, ARPGState nextState)
        {
            currentState.Exist();
            nextState?.Enter();
            currentState = nextState;
        }
    }

    public class DefaultState : ARPGState
    {
        public DefaultState()
        {
            this.SystemList = new ARPGSystemInFrame[] { };
        }
    }
}