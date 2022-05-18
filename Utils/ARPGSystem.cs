namespace AssetsPackage.Scripts.Utils
{
    public abstract class ARPGSystem
    {
        public static T GetCompomentData<T>(ARPGEntity entity) where T : ARPGCompoment
        {
            return entity.CompomentsList[typeof(T)] as T;
        }
    }
    
    public abstract class ARPGSystemInFrame : ARPGSystem
    {
        public ARPGEntitiesGroupID EntitiesGroupID;

        public virtual void ExecuteOnFixedUpdate(){}
        public virtual void ExecuteOnUpdate(){}
        public virtual void ExecuteOnLateUpdate(){}
    }

    public abstract class ARPGSystemMethodSet<T> : ARPGSystem where T : new()
    {
        protected static T system;
        private static object mutex = new object();

        public static T System
        {
            get
            {
                if (system == null)
                {
                    lock (mutex)
                    {
                        if (system == null)
                        {
                            system = new T();
                        }
                    }
                }

                return system;
            }
        }
    }
    
    public abstract class ARPGSystemInState : ARPGSystem
    {
        public virtual void ExecuteOnFixedUpdate(ARPGEntity entity){}
        public virtual void ExecuteOnUpdate(ARPGEntity entity){}
        public virtual void ExecuteOnLateUpdate(ARPGEntity entity){}
        
        public virtual void Enter(ARPGEntity entity){}
        public virtual void Exist(ARPGEntity entity){}
        
        public static void ChangeState(ref ARPGSystemInState currentSystemState, ARPGSystemInState nextSystemState, ARPGEntity entity)
        {
            currentSystemState.Exist(entity);
            nextSystemState.Enter(entity);
            currentSystemState = nextSystemState;
        }
    }
}