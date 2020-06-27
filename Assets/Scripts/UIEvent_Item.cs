using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEvent_Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originParent = null;
    Vector3 originPosition;

    // 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (originParent != null && originParent.GetComponent<UIEvent_CraftedSlot>() != null)
            UIEventHandler.instance.OnDragCraftedItem = true;
        originParent = transform.parent;
        originPosition = transform.position;
        transform.SetParent(UIEventHandler.instance._Canvas);
        GetComponent<Image>().raycastTarget = false;

        UIEventHandler.instance.selectedObj = this.GetComponent<RectTransform>();
    }
     
    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    // 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        UIEventHandler.instance.OnDragCraftedItem = false;

        UIEvent_Slot slotScript = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIEvent_Slot>();
        UIEvent_CraftSlot craftSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIEvent_CraftSlot>();
        UIEvent_CraftedSlot craftedSlot = originParent.GetComponent<UIEvent_CraftedSlot>();

        // 크래프팅된 아이템 크래프트슬롯에 놓지 않도록하기
        if (craftSlot != null && craftedSlot != null) 
        {
            transform.SetParent(originParent);
            transform.position = originPosition;
            return;
        }

        // 슬롯에 놓지않음 or 이미 슬롯에 아이템 있음
        if (slotScript == null || slotScript.OnSetItem)
        {
            print("슬롯이 아니거나 아이템 이미 있음");
            transform.SetParent(originParent);
            transform.position = originPosition;
            return;
        }

        // 슬롯에 놓음
        if(slotScript != null)
        {
            if (craftedSlot != null)
                ItemGenerator.instance.RemoveItemInCraftGrid();

            //print("슬롯 있음");
            if (originParent.GetComponent<UIEvent_Slot>() != null)
                originParent.GetComponent<UIEvent_Slot>().OnSetItem = false;

            slotScript.OnSetItem = true;
        }
    }
}
