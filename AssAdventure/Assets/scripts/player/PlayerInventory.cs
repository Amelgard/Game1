using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public InventorySlot(Item item, int amount = 1)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<InventorySlot> items = new List<InventorySlot>();
    [SerializeField] private int size = 4;
    [SerializeField] public UnityEvent OnInventoryChanged;

    [SerializeField] private float maxWeight = 20;
    [SerializeField] private float currentWeight;

    public bool AddItems(Item item, int amount = 1)
    {
        if (!(currentWeight + (item.weight * amount) <= maxWeight))
            return false;

        if (item.stackable)
            foreach (InventorySlot slot in items)
            {
                if (slot.item.id == item.id)
                {
                    slot.amount += amount;
                    OnInventoryChanged.Invoke();
                    UpdateCurrentWeight();
                    return true;
                }
                if (items.Count >= size) return false;
            }

        InventorySlot new_slot = new InventorySlot(item, amount);
        items.Add(new_slot);
        OnInventoryChanged.Invoke();
        UpdateCurrentWeight();
        return true;
    }
    private void UpdateCurrentWeight()
    {
        var s = 0f;
        foreach (InventorySlot slot in items)
            s += (slot.item.weight * slot.amount);
        currentWeight = s;
    }
    public Item GetItem(int i)
    {
        return i < items.Count ? items[i].item : null;
    }
    public int GetAmount(int i)
    {
        return i < items.Count ? items[i].amount : 0;
    } 
    public int GetSize()
    {
        return items.Count;
    }
}

