using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemDef
{
    public enum ItemType
    {
        None=0,

        Wood,
        WoodStick,
        String,
        Paper,
        RedStonePowder,
        Iron_Ingot,
        Carrot,
        Compass,
        Map,
        Fishing_rod,
        Carrot_Fishing_rod,

        Max
    }

    public class Item : MonoBehaviour
    {
        public ItemType m_type;
        public bool m_isStackable;
        public int m_ItemLayer;
        public int m_Count;
    }

    /*
    public class WoodStick : Item
    {

    }

    public class String : Item
    {

    }

    public class Paper : Item
    {

    }

    public class RedStonePowder : Item
    {

    }

    public class Iron_Ingot : Item
    {

    }

    public class Carrot : Item
    {

    }

    public class Compass : Item
    {

    }

    public class Map : Item
    {

    }

    public class Fishing_rod : Item
    {

    }

    public class Carrot_Fishing_rod : Fishing_rod
    {

    }
    */
}