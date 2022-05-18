using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGEntitiesGroup : Dictionary<ARPGEntitiesGroupID, List<ARPGEntity>>
    {
        public void AddEntityToGroup(ARPGEntitiesGroupID GroupID, ARPGEntity Entity)
        {
            if (!this.ContainsKey(GroupID))
            {
                this.Add(GroupID, new List<ARPGEntity>());
            }
            this[GroupID].Add(Entity);
        }

        #region GenerateGroupID
        public static int GenerateGroupID(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Tuple<Type> type8)
        {
            var tuple = Tuple.Create(type1, type2, type3, type4, type5, type6, type7, type8);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
        {
            var tuple = Tuple.Create(type1, type2, type3, type4, type5, type6, type7);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
        {
            var tuple = Tuple.Create(type1, type2, type3, type4, type5, type6);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2, Type type3, Type type4, Type type5)
        {
            var tuple = Tuple.Create(type1, type2, type3, type4, type5);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2, Type type3, Type type4)
        {
            var tuple = Tuple.Create(type1, type2, type3, type4);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2, Type type3)
        {
            var tuple = Tuple.Create(type1, type2, type3);
            return tuple.GetHashCode();
        }
        public static int GenerateGroupID(Type type1, Type type2)
        {
            var tuple = Tuple.Create(type1, type2);
            return tuple.GetHashCode();
        } 
        public static int GenerateGroupID(Type type1)
        {
            var tuple = Tuple.Create(type1);
            return tuple.GetHashCode();
        }
        #endregion
    }
}