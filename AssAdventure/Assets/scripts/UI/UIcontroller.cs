using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject ManaBar;
    public GameObject StaminaBar;
    public GameObject PlayerInventoryUI;
    public GameObject UIItemPrefab;
    public PlayerStats _PS;
    public PlayerInventory _PI;
    [SerializeField] List<InventorySlot> UIitem;

    private void Start()
    {
        StartCoroutine(Find());
    }
    private IEnumerator Find()
    {
        while (true)
        {
            yield return null;
            if (_PS == null)
            {
                _PS = GameObject.FindObjectOfType<PlayerStats>();
            }
            else
            {
                StartCoroutine(UIStatBarUpdate());
            }
            if (_PI == null)
            {
                _PI = GameObject.FindObjectOfType<PlayerInventory>();
            }
            else
            {
                StartCoroutine(UIkeyActivate());
                yield break;
            }
        }
    }

    private IEnumerator UIStatBarUpdate()
    {
        while (true)
        {
            if (_PS != null)
            {
                HealthBar.GetComponent<Image>().fillAmount = _PS.Health / _PS.MaxHealth;
                ManaBar.GetComponent<Image>().fillAmount = _PS.Mana / _PS.MaxMana;
                StaminaBar.GetComponent<Image>().fillAmount = _PS.Stamina / _PS.MaxStamina;
            }
            else
            {
                StartCoroutine(Find());
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator UIkeyActivate()
    {
        var a = UIinventoryUpdate();
        var activate = true;
        while (true)
        {
            if (Input.GetKeyDown("tab"))
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(activate);
                if (activate)
                {
                    StartCoroutine(a);
                }
                else
                {
                    StopCoroutine(a);
                }
                activate = !activate;
            }
            yield return null;
        }
    }

    public IEnumerator UIinventoryUpdate()
    {
        var Create = 0;
        while (true)
        {
            if (_PI != null)
            {
                if (_PI.GetSize()!=0)
                {
                    for (int i=0; i!=PlayerInventoryUI.transform.childCount ;i++)
                    {
                        if (PlayerInventoryUI.transform.GetChild(i).transform.childCount == 0)
                        {
                            for (int j =0; j!=_PI.GetSize();j++)
                            {
                                if (PlayerInventoryUI.transform.GetChild(i).transform.childCount == 0 && Create != _PI.GetSize())
                                {
                                    GameObject item = Instantiate(UIItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                                    item.transform.SetParent(PlayerInventoryUI.transform.GetChild(i));
                                    item.GetComponent<RectTransform>().transform.localPosition = new Vector3(45, 45, 0);
                                    item.GetComponent<RectTransform>().transform.localRotation = new Quaternion(0, 0, 0, 0);
                                    item.GetComponent<RectTransform>().transform.localScale = Vector3.one;
                                    item.GetComponentInChildren<Image>().sprite = _PI.items[Create].item.icon;
                                    item.GetComponentInChildren<Text>().text = _PI.GetAmount(Create).ToString();
                                    Create += 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j= 0; j!=_PI.GetSize();j++)
                            {
                                if (PlayerInventoryUI.transform.GetChild(i).transform.GetChild(0).GetComponentInChildren<Image>().sprite == _PI.items[j].item.icon)
                                {
                                    PlayerInventoryUI.transform.GetChild(i).transform.GetChild(0).GetComponentInChildren<Text>().text = _PI.items[j].amount.ToString();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                StartCoroutine(Find());
                yield break;
            }
            yield return null;
        }
    }
}