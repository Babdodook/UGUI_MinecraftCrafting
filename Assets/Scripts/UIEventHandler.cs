using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public static UIEventHandler instance;
    public Transform _Canvas;
    public RectTransform selectedObj = null;
    public bool OnDragCraftedItem = false;

    private void Awake()
    {
        instance = this;
    }
}
