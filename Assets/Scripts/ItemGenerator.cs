using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemDef;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator instance;
    public Transform itemTemplate;
    public ItemSettings itemSettings;

    private void Awake()
    {
        instance = this;
        SetItems();
    }

    // 최초 인벤토리에 들어갈 아이템 생성해두기
    int setindex = 0;
    void SetItems()
    {
        itemTemplate.gameObject.SetActive(false);

        InstantiateItem(ItemType.WoodStick, 1);
        InstantiateItem(ItemType.WoodStick, 1);
        InstantiateItem(ItemType.WoodStick, 1);
        InstantiateItem(ItemType.String, 1);
        InstantiateItem(ItemType.String, 1);
        InstantiateItem(ItemType.Carrot, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Paper, 1);
        InstantiateItem(ItemType.Iron_Ingot, 1);
        InstantiateItem(ItemType.Iron_Ingot, 1);
        InstantiateItem(ItemType.Iron_Ingot, 1);
        InstantiateItem(ItemType.Iron_Ingot, 1);
        InstantiateItem(ItemType.RedStonePowder, 1);
    }

    // 아이템 생성
    void InstantiateItem(ItemType type, int Count)
    {
        Transform item;
        item = Instantiate(itemTemplate);
        item.name = type.ToString();
        item.GetComponent<Item>().m_type = type;
        item.GetComponent<Item>().m_Count = Count;
        SetSprite(item, type);
        SetIsStackable(item, type);
        
        item.SetParent(SlotGenerator.instance.ItemGrid[setindex++]);
        item.localPosition = Vector3.zero;
        item.gameObject.SetActive(true);
    }

    // 스프라이트 이미지 세팅
    void SetSprite(Transform item, ItemType _type)
    {
        item.GetComponent<Image>().sprite = itemSettings.GetSprite(_type);
    }

    // 쌓기 가능한 아이템인지 세팅
    void SetIsStackable(Transform item, ItemType _type)
    {
        item.GetComponent<Item>().m_isStackable = itemSettings.GetisStackable(_type);
    }

    // 아이템 조합성공하면 생성하기
    public Transform CreateItem(ItemType _type)
    {
        Transform item = Instantiate(itemTemplate);
        item.name = _type.ToString();
        item.GetComponent<Item>().m_type = _type;
        item.GetComponent<Item>().m_Count = 1;
        SetSprite(item, _type);
        SetIsStackable(item, _type);

        return item;
    }

    // 크래프팅 그리드안에 아이템 지우기
    public void RemoveItemInCraftGrid()
    {
        for (int i = 0; i < GridSize.SIZE; i++) 
        {
            for (int j = 0; j < GridSize.SIZE; j++) 
            {
                Item item = SlotGenerator.instance.CraftGrid[i, j].GetComponentInChildren<Item>();
                if (item != null)
                {
                    item.m_Count -= 1;

                    // 0개 이하면 삭제
                    if (item.m_Count <= 0)
                    {
                        Destroy(item.gameObject);
                        SlotGenerator.instance.CraftGrid[i, j].GetComponent<UIEvent_Slot>().OnSetItem = false;
                    }
                }
            }
        }
        
    }
}
