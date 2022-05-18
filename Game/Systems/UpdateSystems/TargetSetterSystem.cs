using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class TargetSetterSystem : ARPGSystemInFrame
    {
        public TargetSetterSystem()
        {
            this.EntitiesGroupID = ARPGEntitiesGroupID.CubeHunterGroupID;
        }
        
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[this.EntitiesGroupID];
            entities.ForEach(entity =>
            {
                var targetComp = GetCompomentData<TargetLockCompoment>(entity);
                var transComp  = GetCompomentData<TranslateCompoment>(entity);

                // Set Target
                {
                    var mapGridComp = MapGridsCompoment.Singlcomp;
                    var x = transComp.MapGridX;
                    var y = transComp.MapGridY;

                    var charProComp = GetCompomentData<CharactorPorpertiesCompment>(entity);
                    var viewDistance = charProComp.ViewDistance;
                    var viewGrid = (int)(viewDistance / (100 / mapGridComp.XNums));

                    Transform target = null;
                    int currentCheckGrids = 3;
                    for (int i = 1; i <= viewGrid; i++)
                    {
                        var edges = currentCheckGrids >> 1; 
                        // X + 1
                        for (int j = 0; j < edges; j++)
                        {
                            var checkX = x + i;
                            var checkY = y + j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;

                            checkY = y - j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;
                        }
                        if (target != null)
                            break;
                        
                        // X - 1
                        for (int j = 0; j < edges; j++)
                        {
                            var checkX = x - i;
                            var checkY = y + j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;

                            checkY = y - j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;
                        }
                        if (target != null)
                            break;
                        
                        // Y + 1
                        for (int j = 0; j < edges; j++)
                        {
                            var checkX = x + j;
                            var checkY = y + i;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;

                            checkX = x - j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;
                        }
                        if (target != null)
                            break;
                        
                        // Y - 1
                        for (int j = 0; j < edges; j++)
                        {
                            var checkX = x + j;
                            var checkY = y - i;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;

                            checkX = x - j;
                            target = CheckID(mapGridComp.MapGrids, checkX, checkY);
                            if(target != null)
                                break;
                        }
                        if (target != null)
                            break;
                        
                        currentCheckGrids += 2;
                    }

                    targetComp.target = target;
                }
            });
        }
        
        private Transform CheckID(int[][]mapGrids, int x, int y)
        {
            if (x < 0 || x > mapGrids.Length - 1 || y < 0 || y > mapGrids.Length - 1)
            {
                return null;
            }
            
            if (mapGrids[x][y] != -1)
            {
                var id = mapGrids[x][y];
                var cube = WorldGod.Singleton.CurrentWorld.EntitiesList[id];

                return GetCompomentData<TranslateCompoment>(cube).transform;   
            }

            return null;
        }
    }
}