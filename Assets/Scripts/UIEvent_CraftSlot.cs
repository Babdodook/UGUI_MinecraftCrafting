using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEvent_CraftSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(!UIEventHandler.instance.OnDragCraftedItem)
            AutoCrafting.instance.CheckRecipe();
        //print("크래프팅에놓음");
    }
}
