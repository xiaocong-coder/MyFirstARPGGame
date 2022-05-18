using AssetsPackage.Scripts.Utils;

namespace AssetsPackage.Scripts.Game.Compoments.NormalCompoments
{
    public class CharactorPorpertiesCompment : CompomentData
    {
        public CharactorPorpertiesCompment(Faction faction)
        {
            this.Faction = faction;
        }
        
        public Faction Faction;
        public float HP = 1000;
        public float MaxHP = 1000;
        public float Speed = 2;
        public float Attack = 100;
        public float ViewDistance = 10;
        public float AttackDistance = 3.5f;
        public float ViewAngle = 120;
    }

    public enum Faction
    {
        CubeHunter,
        Cube
    } 
}