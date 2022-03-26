using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIitem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup  _CG;
    private RectTransform _RT;
    private Canvas _UI;
    private GridLayoutGroup _inventory;
    private PlayerInventory _PI;
    private UIcontroller _UIcontroller;

    public void Start()
    {
        _UIcontroller = GameObject.FindObjectOfType<UIcontroller>();
        _PI = GameObject.FindObjectOfType<PlayerInventory>();
        _UI = GameObject.FindObjectOfType<Canvas>();
        _RT = GetComponent<RectTransform>();
        _CG = GetComponent<CanvasGroup>();
        _inventory = GetComponentInParent<GridLayoutGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.transform.SetParent(_inventory.transform.GetChild(_inventory.transform.childCount-1));
        _CG.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _RT.anchoredPosition += eventData.delta/_UI.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var ItemDrag = eventData.pointerDrag;

        if (eventData.pointerEnter.gameObject.transform.parent == eventData.pointerDrag.transform.parent.parent)
        {
            ItemDrag.transform.SetParent(eventData.pointerEnter.transform);
            transform.localPosition = new Vector3(45, 45, 0);
            _CG.blocksRaycasts = true;
        }
        if (eventData.pointerEnter.gameObject.transform == eventData.pointerDrag.transform.parent.parent.parent)
        {
            for (int i = 0; i != _inventory.transform.childCount - 1; i++)
            {
                if (_inventory.transform.GetChild(i).transform.childCount == 0)
                {
                    ItemDrag.transform.SetParent(_inventory.transform.GetChild(i));
                    ItemDrag.transform.localPosition = new Vector3(45, 45, 0);
                    _CG.blocksRaycasts = true;
                    break;
                }
            }
        }
    }
}
