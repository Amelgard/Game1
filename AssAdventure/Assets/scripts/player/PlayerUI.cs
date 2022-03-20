using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    private float health;
    private float mana;
    private float stamina;
    private GameObject HealthBar;
    private GameObject ManaBar;
    private GameObject StaminaBar;
    void Update()
    {
        UIStatBarUpdate();
    }
    public void UIStatBarUpdate()
    {
        if (HealthBar==null || ManaBar==null || StaminaBar==null)
        {
            HealthBar = GameObject.Find("HealthBar");
            ManaBar = GameObject.Find("ManaBar");
            StaminaBar = GameObject.Find("StaminaBar");
        }
        
        health = gameObject.GetComponent<PlayerStats>().Health;
        mana = gameObject.GetComponent<PlayerStats>().Mana;
        stamina = gameObject.GetComponent<PlayerStats>().Stamina;


        HealthBar.GetComponent<Image>().fillAmount = health/100;

    }
}
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> Icons = new List<Image>();

}