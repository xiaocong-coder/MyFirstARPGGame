using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class UpdateUISystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();

            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            var cubeHunterEntity = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.CubeHunterGroupID][0];
            entities.ForEach(entity =>
            {
                var uiContainComp = GetCompomentData<UIContainCompoment>(entity);
                var playUI = uiContainComp.UIContainer[typeof(PlayUI)] as PlayUI;

                var charProComp = GetCompomentData<CharactorPorpertiesCompment>(cubeHunterEntity);
                var currentHp = charProComp.HP;
                var MaxHp = charProComp.MaxHP;
                var hpPercent = currentHp / MaxHp;

                playUI?.HpMaterial.SetFloat("_HP_Percent", hpPercent);
            });
        }
    }
}