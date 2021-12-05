using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject _inventoryUI;
    bool inventoryIsActive;
    private void Start()
    {
        inventoryIsActive = false;
        inventory = new Inventory();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryIsActive = !inventoryIsActive;
            _inventoryUI.SetActive(inventoryIsActive);
        }
    }
}
