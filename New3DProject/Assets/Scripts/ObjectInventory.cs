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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            inventory.AddItem(AllGameItems.GetItem(Random.Range(0, 2)));
        }
    }


}
