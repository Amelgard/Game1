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
        if (Input.GetKeyDown(KeyCode.T))
        {
            _inventoryUI.GetComponent<Image>().sprite = icon;
        }
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
        int numberOfContainer = 15;
        containers = new List<GameObject>();
        int line = 0;
        for (int i = 0; i < numberOfContainer; i++)
        {
            containers.Add(Instantiate(Resources.Load<GameObject>("Prefabs/UI/Container"), _inventoryUI.transform));
            if (i / numberInLine - line >= 1)
                line += 1;
            containers[i].GetComponent<RectTransform>().localPosition += new Vector3(distX * ((i % numberInLine)), -distY * line, 0);
        }
    }
}
