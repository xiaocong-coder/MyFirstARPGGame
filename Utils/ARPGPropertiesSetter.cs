using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGPropertiesSetter
    {
        public static void SetCubeHunterProperties(ref ARPGEntity entity)
        {
            var charPorperComp = ARPGSystem.GetCompomentData<CharactorPorpertiesCompment>(entity);
            
            charPorperComp.HP    = 1000;
            charPorperComp.MaxHP = 1000;
            
            charPorperComp.Attack = 100;
            charPorperComp.Speed  = 2;
            
            charPorperComp.AttackDistance = 0.0f;
            charPorperComp.ViewDistance = 5.0f;
            charPorperComp.ViewAngle = 120;
        }
        
        public static void SetNormalCubeProperties(ref ARPGEntity entity)
        {
            var charPorperComp = ARPGSystem.GetCompomentData<CharactorPorpertiesCompment>(entity);
            
            charPorperComp.HP    = 500;
            charPorperComp.MaxHP = 500;
            
            charPorperComp.Attack = 100;
            charPorperComp.Speed  = 2;
            
            charPorperComp.AttackDistance = 1.5f;
            charPorperComp.ViewDistance = 10.0f;
            charPorperComp.ViewAngle = 120;
        }
    }
}