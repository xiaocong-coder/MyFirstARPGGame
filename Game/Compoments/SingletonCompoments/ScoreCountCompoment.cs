using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class ScoreCountCompoment : SingletonCompoment<ScoreCountCompoment>
    {
        public ScoreCountCompoment()
        {
            Singlcomp = this;
        }

        public int MaxDoubleHit = 0;
        public bool IsPlayerWin = false;
    }
}