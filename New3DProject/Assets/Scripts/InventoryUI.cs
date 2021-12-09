using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryUI : MonoBehaviour
{
    List<GameObject> containers;
    List<GameObject> anotherContainers;
    Inventory inventory;
    Inventory anotherInventory;
    public GameObject m_inventoryUI;
    public GameObject m_anotherInventoryUI;
    bool inventoryIsActive;

    readonly int maxContainers = 10;
    readonly int maxAnotherContainers = 10;

    GraphicRaycaster m_Raycaster;
    readonly EventSystem m_EventSystem;
    void Start()
    {
        inventoryIsActive = false;
        inventory = new Inventory();
        CreateContaners();
        m_inventoryUI.SetActive(false);
        m_anotherInventoryUI.SetActive(false);

        m_Raycaster = GetComponent<GraphicRaycaster>();
    }
    void Update()
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
    private void CreateContaners()
    {
        int distX = 155;
        int distY = 115;
        int lineLength = 5;
        containers = new List<GameObject>();
        anotherContainers = new List<GameObject>();
        int line = 0;
        for (int i = 0; i < maxContainers; i++)
        {
            containers.Add(Instantiate(Resources.Load<GameObject>("Prefabs/UI/Container"), m_inventoryUI.transform));
            if (i / lineLength - line >= 1)
                line += 1;
            containers[i].GetComponent<RectTransform>().localPosition += new Vector3(distX * ((i % lineLength)), -distY * line, 0);
        }
        line = 0;
        for (int i = 0; i < maxAnotherContainers; i++)
        {
            anotherContainers.Add(Instantiate(Resources.Load<GameObject>("Prefabs/UI/Container"), m_anotherInventoryUI.transform));
            if (i / lineLength - line >= 1)
                line += 1;
            anotherContainers[i].GetComponent<RectTransform>().localPosition += new Vector3(distX * ((i % lineLength)), -distY * line, 0);
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
                    RefreshItems(anotherInventory);
                }
            }
        }
    }
    private void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryIsActive = !inventoryIsActive;
            m_inventoryUI.SetActive(inventoryIsActive);
            m_anotherInventoryUI.SetActive(inventoryIsActive);
            if (inventoryIsActive)
                StartCoroutine(ReplaseContainer());
            else
                StopCoroutine(ReplaseContainer());
        }
    }
    private void AddItem(Item item)
    {
        inventory.AddItem(item);
        RefreshItems(inventory);
    }
    private void RemoveItem(int containerId)
    {
        if (inventory.GetRange() - 1 >= containerId)
        {
            inventory.RemoveItem(containerId);
            RefreshItems(inventory);
        }
    }
    private void RefreshItems(Inventory _inventory)
    {
        if (_inventory == inventory)
        {
            for (int i = 0; i < inventory.GetRange(); i++)
            {
                containers[i].transform.GetChild(0).GetComponent<Image>().sprite = inventory.GetItem(i).ItemIcon;
            }
            for (int i = inventory.GetRange(); i < maxContainers; i++)
            {
                containers[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
        else if(_inventory == anotherInventory)
        {
            for (int i = 0; i < anotherInventory.GetRange(); i++)
            {
                anotherContainers[i].transform.GetChild(0).GetComponent<Image>().sprite = anotherInventory.GetItem(i).ItemIcon;
            }
            for (int i = anotherInventory.GetRange(); i < maxAnotherContainers; i++)
            {
                anotherContainers[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }

    //
    
    IEnumerator ReplaseContainer()
    {
        GameObject con1 = null;
        GameObject containerIcon = null;
        Vector3 containerIconPos = Vector3.zero;
        bool isReplasing = false;
        bool firstInventory = true;
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Mouse0) && EventSystem.current.IsPointerOverGameObject())
            {
                con1 = GetTouchedContainer();
                if (con1 != null)
                {
                    if (containers.Contains(con1))
                        firstInventory = true;
                    else
                        firstInventory = false;
                    isReplasing = true;
                    containerIcon = con1.transform.GetChild(0).gameObject;
                    con1.GetComponent<Image>().raycastTarget = false;
                    con1.transform.SetSiblingIndex(maxContainers);
                    con1.transform.parent.SetSiblingIndex(999999);
                    containerIconPos = containerIcon.transform.position;
                }
            }
            if (isReplasing)
            {
                containerIcon.transform.position = Input.mousePosition;
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {

                    GameObject con2 = GetTouchedContainer();
                    int containerIdA;
                    int containerIdB;
                    if (firstInventory)
                    {
                        containerIdA = containers.IndexOf(con1);
                        containerIdB = containers.IndexOf(con2);
                        if (containerIdA < inventory.GetRange())
                        {
                            if (!EventSystem.current.IsPointerOverGameObject())// drop
                            {
                                RemoveItem(containerIdA);
                                RefreshItems(inventory);
                            }
                            else
                            {
                                if (con2 != null && containers.Contains(con2) && containerIdB < inventory.GetRange())
                                {
                                    inventory.Swap(containerIdA, containerIdB);
                                    RefreshItems(inventory);
                                }
                            }
                        }
                    }
                    else
                    {
                        containerIdA = anotherContainers.IndexOf(con1);
                        if (containerIdA < anotherInventory.GetRange())
                        {
                            if (anotherContainers.Contains(con2))
                            {
                                containerIdB = anotherContainers.IndexOf(con2);
                                if (containerIdB < anotherInventory.GetRange() && EventSystem.current.IsPointerOverGameObject())
                                {
                                    anotherInventory.Swap(containerIdA, containerIdB);
                                    RefreshItems(anotherInventory);
                                }
                            }
                            else
                            {
                                if ((con2.transform.parent.gameObject == m_inventoryUI || con2 == m_inventoryUI) &&
                                    inventory.GetRange() < maxContainers)
                                {
                                    inventory.AddItem(anotherInventory.GetItem(containerIdA));
                                    anotherInventory.RemoveItem(containerIdA);
                                    RefreshItems(inventory);
                                    RefreshItems(anotherInventory);
                                }
                            }
                        }
                    }
                    containerIcon.transform.position = containerIconPos;
                    con1.GetComponent<Image>().raycastTarget = true;
                    con1 = null;
                    isReplasing = false;
                }
            }
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
            if (containers.Contains(result.gameObject))
                return result.gameObject;
            else if (anotherContainers.Contains(result.gameObject))
                return result.gameObject;
            else if(result.gameObject == m_inventoryUI || result.gameObject == m_anotherInventoryUI)
                return result.gameObject;
        }
        return null;
    }

}
