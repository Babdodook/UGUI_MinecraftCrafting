using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemDef;

public static class GridSize
{
    public static int SIZE = 3;
}

public static class InvSize
{
    public static int X = 9;
    public static int Y = 3;
}

public class AutoCrafting : MonoBehaviour
{
    public static AutoCrafting instance;
    public Transform CreatedItemSlot;

    //int GRID_SIZE = 3;

    Dictionary<ItemType, ItemType[,]> Dict_Recipes = new Dictionary<ItemType, ItemType[,]>(new ItemTypeComparer());

    private void Awake()
    {
        instance = this;
        InitRecipes();
    }

    // 조합법 정의하기
    void InitRecipes()
    {
        ItemType[,] recipe = new ItemType[GridSize.SIZE, GridSize.SIZE];
        // 나무막대기
        recipe[0, 0] = ItemType.None; recipe[0, 1] = ItemType.None; recipe[0, 2] = ItemType.None;
        recipe[1, 0] = ItemType.None; recipe[1, 1] = ItemType.Wood; recipe[1, 2] = ItemType.None;
        recipe[2, 0] = ItemType.None; recipe[2, 1] = ItemType.Wood; recipe[2, 2] = ItemType.None;
        Dict_Recipes.Add(ItemType.WoodStick,recipe);
        // 나침반
        recipe = new ItemType[GridSize.SIZE, GridSize.SIZE];
        recipe[0, 0] = ItemType.None; recipe[0, 1] = ItemType.Iron_Ingot; recipe[0, 2] = ItemType.None;
        recipe[1, 0] = ItemType.Iron_Ingot; recipe[1, 1] = ItemType.RedStonePowder; recipe[1, 2] = ItemType.Iron_Ingot;
        recipe[2, 0] = ItemType.None; recipe[2, 1] = ItemType.Iron_Ingot; recipe[2, 2] = ItemType.None;
        Dict_Recipes.Add(ItemType.Compass, recipe);
        // 빈 지도
        recipe = new ItemType[GridSize.SIZE, GridSize.SIZE];
        recipe[0, 0] = ItemType.Paper; recipe[0, 1] = ItemType.Paper; recipe[0, 2] = ItemType.Paper;
        recipe[1, 0] = ItemType.Paper; recipe[1, 1] = ItemType.Compass; recipe[1, 2] = ItemType.Paper;
        recipe[2, 0] = ItemType.Paper; recipe[2, 1] = ItemType.Paper; recipe[2, 2] = ItemType.Paper;
        Dict_Recipes.Add(ItemType.Map, recipe);
        // 낚시대
        recipe = new ItemType[GridSize.SIZE, GridSize.SIZE];
        recipe[0, 0] = ItemType.None; recipe[0, 1] = ItemType.None; recipe[0, 2] = ItemType.WoodStick;
        recipe[1, 0] = ItemType.None; recipe[1, 1] = ItemType.WoodStick; recipe[1, 2] = ItemType.String;
        recipe[2, 0] = ItemType.WoodStick; recipe[2, 1] = ItemType.None; recipe[2, 2] = ItemType.String;
        Dict_Recipes.Add(ItemType.Fishing_rod, recipe);
        // 당근낚시대
        recipe = new ItemType[GridSize.SIZE, GridSize.SIZE];
        recipe[0, 0] = ItemType.None; recipe[0, 1] = ItemType.None; recipe[0, 2] = ItemType.None;
        recipe[1, 0] = ItemType.None; recipe[1, 1] = ItemType.Fishing_rod; recipe[1, 2] = ItemType.None;
        recipe[2, 0] = ItemType.None; recipe[2, 1] = ItemType.None; recipe[2, 2] = ItemType.Carrot;
        Dict_Recipes.Add(ItemType.Carrot_Fishing_rod, recipe);
    }

    // 크래프팅 그리드에 올라간 아이템 타입 알아오기
    ItemType[,] GetItemsOnCraftSlot()
    {
        ItemType[,] recipe = new ItemType[3, 3];

        for (int i = 0; i < GridSize.SIZE; i++) 
        {
            for (int j = 0; j < GridSize.SIZE; j++) 
            {
                if (SlotGenerator.instance.CraftGrid[i, j].GetComponentInChildren<Item>() != null)
                {
                    recipe[i, j] = SlotGenerator.instance.CraftGrid[i, j].GetComponentInChildren<Item>().m_type;
                }
                else
                    recipe[i, j] = ItemType.None;
            }
        }

        return recipe;
    }

    public void CheckRecipe()
    {
        ItemType type;
        Transform CreatedItem = null;

        type = GetItemType();
        if (type != ItemType.None)
        {
            CreatedItem = ItemGenerator.instance.CreateItem(type);

            CreatedItem.SetParent(CreatedItemSlot);
            CreatedItem.localPosition = Vector3.zero;
            CreatedItem.gameObject.SetActive(true);
        }
    }

    ItemType GetItemType()
    {
        ItemType[,] recipe = GetItemsOnCraftSlot();
        bool same;
        ItemType returnType = ItemType.None;

        foreach (ItemType key_type in Dict_Recipes.Keys)
        {
            ItemType[,] recipeOfKey = Dict_Recipes[key_type];

            same = true;
            returnType = key_type;
            for (int i = 0; i < GridSize.SIZE; i++)
            {
                for (int j = 0; j < GridSize.SIZE; j++)
                {
                    if (recipe[i, j] != recipeOfKey[i, j])
                    {
                        same = false;
                        break;
                    }
                }
                if (!same)
                    break;
            }

            if (same)
                return returnType;
        }

        return ItemType.None;
    }
}
