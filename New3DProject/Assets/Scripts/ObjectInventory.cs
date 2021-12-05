using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInventory : MonoBehaviour
{
    public Inventory inventory;
    private void Start()
    {
        inventory = new Inventory();
    }
}
