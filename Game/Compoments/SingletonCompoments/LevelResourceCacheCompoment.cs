using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class LevelResourceCacheCompoment : SingletonCompoment<LevelResourceCacheCompoment>
    {
        public LevelResourceCacheCompoment()
        {
            Singlcomp = this;

            this.DelayTimeCountor = new ARPGTimeCountor(5.0f);
        }

        public ARPGTimeCountor DelayTimeCountor;
    }
}