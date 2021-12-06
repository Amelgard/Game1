using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInventory : MonoBehaviour
{
    public Inventory inventory;
    private void Start()
    {
        inventory = new Inventory();
        inventory.AddItem((AllGameItems.GetItem(0)));
    }
}
