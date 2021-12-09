using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> ItemList;
    public Inventory()
    {
        ItemList = new List<Item>();
    }
    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }
    public void RemoveItem(int containerId)
    {
        ItemList.RemoveAt(containerId);
    }
    public int GetRange()
    {
        return ItemList.Count;
    }
    public Item GetItem(int containerId)
    {
        return ItemList[containerId];
    }
    public void ItemReplacement (int containerId, Item item)
    {
        ItemList[containerId] = item;
    }
    public void Swap(int containerA, int containerB)
    {
        Item tmp = ItemList[containerA];
        ItemList[containerA] = ItemList[containerB];
        ItemList[containerB] = tmp;
    }
}
