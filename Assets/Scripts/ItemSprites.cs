using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprites : MonoBehaviour
{
    public static ItemSprites instance;

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
}
