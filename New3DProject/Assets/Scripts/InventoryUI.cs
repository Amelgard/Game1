using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    List<GameObject> containers;
    Inventory inventory;
    Inventory anotherInventory;
    public Sprite icon;
    public GameObject _inventoryUI;
    bool inventoryIsActive;
    int maxContainers = 15;
    private void Start()
    {
        inventoryIsActive = false;
        inventory = new Inventory();
        CreateContaners();
    }
    private void Update()
    {
        ShowInventory();
        GetAnotherInventory();


        //test
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(AllGameItems.GetItem(Random.Range(0,2)));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RemoveItem(0);
        }
        //test
    }
    private void GetAnotherInventory()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<ObjectInventory>())
                {
                    anotherInventory = hit.transform.GetComponent<ObjectInventory>().inventory;
                }
            } 
        }
    }
    private void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryIsActive = !inventoryIsActive;
            _inventoryUI.SetActive(inventoryIsActive);
        }
    }
    private void CreateContaners()
    {
        int distX = 155;
        int distY = 115;
        int numberInLine = 5;
        containers = new List<GameObject>();
        int line = 0;
        for (int i = 0; i < maxContainers; i++)
        {
            containers.Add(Instantiate(Resources.Load<GameObject>("Prefabs/UI/Container"), _inventoryUI.transform));
            if (i / numberInLine - line >= 1)
                line += 1;
            containers[i].GetComponent<RectTransform>().localPosition += new Vector3(distX * ((i % numberInLine)), -distY * line, 0);
        }
    }
    private void AddItem(Item item)
    {
        inventory.AddItem(item);
        int id = inventory.GetRange() - 1;
        RefreshItems();
    }
    private void RemoveItem(int containerId)
    {
        if (inventory.GetRange() - 1 >= containerId)
        {
            inventory.RemoveItem(containerId);
            RefreshItems();
        }
    }
    private void RefreshItems() 
    {
        for (int i = 0; i < inventory.GetRange(); i++)
        {
            containers[i].transform.GetChild(0).GetComponent<Image>().sprite = inventory.GetItem(i).itemIcon;
        }
        for (int i = inventory.GetRange(); i < maxContainers; i++)
        {
            containers[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
    }

}
