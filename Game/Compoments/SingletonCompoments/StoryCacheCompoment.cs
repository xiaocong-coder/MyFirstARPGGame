using System.Text;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage._2._Scripts.Game.Compoments.SingletonCompoments
{
    public class StoryCacheCompoment : SingletonCompoment<StoryCacheCompoment>
    {
        public StoryCacheCompoment()
        {
            Singlcomp = this;
            
            this.StoryCacheText = new StringBuilder("");
            this.Index = 0;
            this.DelayTimer = new ARPGTimer(3.0f);
            this.RefreshTextTimerCounter = new ARPGTimeCountor(0.1f);
        }

        public StringBuilder StoryCacheText;
        public int Index;
        public ARPGTimer DelayTimer;
        public ARPGTimeCountor RefreshTextTimerCounter;
    }
}