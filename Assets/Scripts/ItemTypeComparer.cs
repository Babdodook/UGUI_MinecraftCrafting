using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemDef
{
    public class ItemTypeComparer : IEqualityComparer<ItemType>
    {
        bool IEqualityComparer<ItemType>.Equals(ItemType x, ItemType y)
        {
            return (int)x == (int)y;
        }

        int IEqualityComparer<ItemType>.GetHashCode(ItemType obj)
        {
            return ((int)obj).GetHashCode();
        }

        #region remove codes
        /*
        public bool Equals(ItemType x, ItemType y)

        {

            return (int)x == (int)y;

        }

        public int GetHashCode(ItemType obj)

        {

            return ((int)obj).GetHashCode();

        }
        */
        #endregion
    }
}
