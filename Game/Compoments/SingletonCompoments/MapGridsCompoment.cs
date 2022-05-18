using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Compoments.SingletonCompoments
{
    public class MapGridsCompoment : SingletonCompoment<MapGridsCompoment>
    {
        public MapGridsCompoment(int XNums)
        {
            Singlcomp = this;
            
            this.XNums = XNums;

            this.StartPoint = new Vector2(0,0);
            this.MapGrids = new int[XNums][];

            for (int i = 0; i < XNums; i++)
            {
                var list = new int[XNums];
                for (int j = 0; j < XNums; j++)
                {
                    list[j] = -1;
                }

                this.MapGrids[i] = list;
            }
        }

        public int XNums;
        public Vector2 StartPoint;

        public int[][] MapGrids;
    }
}