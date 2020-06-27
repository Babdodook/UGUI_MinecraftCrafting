using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemDef
{

    public class ItemSettings : MonoBehaviour
    {
        public static ItemSettings instance;

        public Sprite WoodStick;
        public Sprite String;
        public Sprite Paper;
        public Sprite RedStonePowder;
        public Sprite Iron_Ingot;
        public Sprite Carrot;
        public Sprite Compass;
        public Sprite Map;
        public Sprite Fishing_rod;
        public Sprite Carrot_Fishing_rod;
        
        private void Awake()
        {
            instance = this;
        }

        // 스프라이트 이미지 정보 넘겨주기
        public Sprite GetSprite(ItemType _type)
        {
            switch (_type)
            {
                case ItemType.WoodStick:
                    return WoodStick;
                case ItemType.String:
                    return String;
                case ItemType.Paper:
                    return Paper;
                case ItemType.RedStonePowder:
                    return RedStonePowder;
                case ItemType.Iron_Ingot:
                    return Iron_Ingot;
                case ItemType.Carrot:
                    return Carrot;
                case ItemType.Compass:
                    return Compass;
                case ItemType.Map:
                    return Map;
                case ItemType.Fishing_rod:
                    return Fishing_rod;
                case ItemType.Carrot_Fishing_rod:
                    return Carrot_Fishing_rod;
            }

            return null;
        }

        // 누적가능한 아이템인지 판별하기
        public bool GetisStackable(ItemType _type)
        {
            switch (_type)
            {
                case ItemType.WoodStick:
                case ItemType.String:
                case ItemType.Paper:
                case ItemType.RedStonePowder:
                case ItemType.Iron_Ingot:
                case ItemType.Carrot:
                    return true;
                case ItemType.Compass:
                case ItemType.Map:
                case ItemType.Fishing_rod:
                case ItemType.Carrot_Fishing_rod:
                    return false;
            }

            return false;
        }
    }
}