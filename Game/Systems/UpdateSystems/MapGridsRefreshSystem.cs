using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.CubeHunterStates;
using AssetsPackage.Scripts.Game.CustomClasses.CubeStates;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class MapGridsRefreshSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();

            var cubeHunters = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeHunterGroupID];
            var cubes = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeGroupID];
            
            cubeHunters.ForEach(entity =>
            {
                var stateComp = GetCompomentData<CubeHunterStateCompoment>(entity);
                if(stateComp.CurrentState.Equals(stateComp.States[typeof(CHDeadState)]))
                    return;
                
                var mapGridsComp = MapGridsCompoment.Singlcomp; 
                var transComp    = GetCompomentData<TranslateCompoment>(entity);

                mapGridsComp.MapGrids[transComp.MapGridX][transComp.MapGridY] = -1;

                var position = transComp.transform.position;
                var pos = new Vector2(position.x, position.z) - mapGridsComp.StartPoint;
                var edge = 100 / mapGridsComp.XNums;
                var x = (int)Mathf.Floor(pos.x / edge);
                var y = (int)Mathf.Floor(pos.y / edge);

                transComp.MapGridX = Mathf.Max(0, x);
                transComp.MapGridY = Mathf.Max(0, y);

                mapGridsComp.MapGrids[x][y] = entity.EntityID;
            });
            
            cubes.ForEach(entity =>
            {
                var stateComp = GetCompomentData<CubeStateCompoment>(entity);
                if(stateComp.CurrentState.Equals(stateComp.States[typeof(CDeadState)]))
                    return;
                
                var mapGridsComp = MapGridsCompoment.Singlcomp; 
                var transComp    = GetCompomentData<TranslateCompoment>(entity);

                mapGridsComp.MapGrids[transComp.MapGridX][transComp.MapGridY] = -1;

                var position = transComp.transform.position;
                var pos = new Vector2(position.x, position.z) - mapGridsComp.StartPoint;
                var edge = 100 / mapGridsComp.XNums;
                var x = (int)Mathf.Floor(pos.x / edge);
                var y = (int)Mathf.Floor(pos.y / edge);

                transComp.MapGridX = Mathf.Max(0, x);
                transComp.MapGridY = Mathf.Max(0, y);

                mapGridsComp.MapGrids[x][y] = entity.EntityID;
            });
        }
    }
}