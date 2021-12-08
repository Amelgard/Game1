using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    List<GameObject> containers;
    Inventory inventory;
    Inventory anotherInventory;
    public GameObject _inventoryUI;
    bool inventoryIsActive;
    int maxContainers = 15;

    GraphicRaycaster m_Raycaster;
    EventSystem m_EventSystem;
    private void Start()
    {
        inventoryIsActive = false;
        isReplasing = false;
        inventory = new Inventory();
        CreateContaners();

        m_Raycaster = GetComponent<GraphicRaycaster>();
    }
    private void Update()
    {
        ShowInventory();
        GetAnotherInventory();
        ReplaseContainer();
        //test
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(AllGameItems.GetItem(Random.Range(0, 2)));
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

    //
    GameObject con1;
    bool isReplasing;
    private void ReplaseContainer()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && EventSystem.current.IsPointerOverGameObject()) 
        {
            con1 = GetTouchedContainer();
            isReplasing = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && isReplasing && con1 != null)
        {
            isReplasing = false;
            GameObject con2 = GetTouchedContainer();
            int containerIdA = 0;
            int containerIdB = 0;
            for (int i = 0; i < maxContainers; i++)
            {
                if (containers[i] == con1)
                    containerIdA = i;
            }
            if (con2 == null)
            {
                RemoveItem(containerIdA);
                RefreshItems();
            }
            else
            {
                for (int i = 0; i < maxContainers; i++)
                {
                    if (containers[i] == con2)
                        containerIdB = i;
                }
                inventory.Swap(containerIdA,containerIdB);
                RefreshItems();
            }
            con1 = null;
        }
    }
    private GameObject GetTouchedContainer()
    {
        PointerEventData m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        foreach (RaycastResult result in results)
        {
            for (int i = 0; i < maxContainers; i++)
            {
                if (result.gameObject == containers[i])
                {
                    return result.gameObject;
                }
            }
        }
        return null;
    }
}
