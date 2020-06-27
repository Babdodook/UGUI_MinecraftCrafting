using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEvent_Slot : MonoBehaviour, IDropHandler
{
    RectTransform rectTransform;
    public bool OnSetItem = false;

    public void OnDrop(PointerEventData eventData)
    {
        if(UIEventHandler.instance.selectedObj != null)
        {
            UIEventHandler.instance.selectedObj.gameObject.transform.SetParent(this.transform);
            UIEventHandler.instance.selectedObj.localPosition = Vector3.zero;

            UIEventHandler.instance.selectedObj = null;
        }
    }
}
