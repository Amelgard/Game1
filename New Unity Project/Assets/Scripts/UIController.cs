using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject thisCamera;
    public Image staminaBar;
    private float stamina;

    private void Update()
    {
        UI();
    }
    private void UI()
    {
        thisCamera = gameObject;
        stamina = thisCamera.GetComponent<PlayerControl>().stamina;
        StatBar(staminaBar, stamina);
        //StatBar(helthBar, helth);
    }

    private void StatBar(Image attrBar, float attrLVL)
    {
        attrBar.rectTransform.localScale = new Vector3(attrLVL / 100, 1, 1);
        attrBar.rectTransform.localPosition = new Vector3(((attrLVL / 100) * 75) - 75, 0, 0);
    }
}
