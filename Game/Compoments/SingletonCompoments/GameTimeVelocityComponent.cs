using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class GameTimeVelocityComponent : SingletonCompoment<GameTimeVelocityComponent>
    {
        public GameTimeVelocityComponent()
        {
            Singlcomp = this;

            this.ChangeDelayTimer = new ARPGTimer(2.0f);
        }
        
        // Singleton CompomentData
        public float TimeVelocity = 1.0f;
        public float LateTimeVelocity = 0.0f;

        public ARPGTimer ChangeDelayTimer;
    }
}