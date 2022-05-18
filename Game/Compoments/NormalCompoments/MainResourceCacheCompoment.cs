using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class MainResourceCacheCompoment : SingletonCompoment<MainResourceCacheCompoment>
    {
        public MainResourceCacheCompoment()
        {
            Singlcomp = this;

            this.DelayTimeCountor = new ARPGTimeCountor(5.0f);
        }

        public ARPGTimeCountor DelayTimeCountor;
    }
}