using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGenerator : MonoBehaviour
{
    public static SlotGenerator instance;
    public Transform itemSlotTemplate;
    public Transform craftSlotTemplate;
    public Transform itemParent;
    public Transform craftParent;
    Vector3 originPosition;

    public List<Transform> ItemGrid;
    public Transform[,] CraftGrid;

    private void Awake()
    {
        instance = this;
        
        SetSlots();
    }

    void SetSlots()
    {
        // 크래프팅용 슬롯 생성
        craftSlotTemplate.gameObject.SetActive(false);
        originPosition = craftSlotTemplate.GetComponent<RectTransform>().anchoredPosition;

        CraftGrid = new Transform[GridSize.SIZE, GridSize.SIZE];
        for (int i = 0; i < GridSize.SIZE; i++)
        {
            for (int j = 0; j < GridSize.SIZE; j++)
            {
                var slotItem = Instantiate(craftSlotTemplate);
                slotItem.name = "craft_Slot_" + i + "_" + j;
                slotItem.SetParent(craftParent);
                slotItem.GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(originPosition.x + j * 30.8f, originPosition.y - i * 32.5f, 0);

                slotItem.gameObject.SetActive(true);

                CraftGrid[i, j] = slotItem;
            }
        }

        // 인벤토리용 슬롯 생성
        itemSlotTemplate.gameObject.SetActive(false);
        originPosition = itemSlotTemplate.GetComponent<RectTransform>().anchoredPosition;

        ItemGrid = new List<Transform>();
        for (int i = 0; i < InvSize.Y; i++) 
        {
            for (int j = 0; j < InvSize.X; j++) 
            {
                var slotItem = Instantiate(itemSlotTemplate);
                slotItem.name = "Slot_" + i + "_" + j;
                slotItem.SetParent(itemParent);
                slotItem.GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(originPosition.x + j * 30.8f, originPosition.y - i*32.5f, 0);

                slotItem.gameObject.SetActive(true);

                ItemGrid.Add(slotItem);
            }
        }
    }
}
