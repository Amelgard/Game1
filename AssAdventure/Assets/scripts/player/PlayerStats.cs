using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Speed=1.5f;
    public float Health;
    public float MaxHealth = 100f;
    public float Mana;
    public float MaxMana = 100f;
    public float Stamina;
    public float MaxStamina = 100f;

    private float HealthRegeneration;
    private float ManaRegeneration;
    private float StaminaRegeneration;

    void Start()
    {

        Health = MaxHealth;
        Mana = MaxMana;
        Stamina = MaxStamina;

        HealthRegeneration = 3f;
        StaminaRegeneration = 1f;
        ManaRegeneration = 1f;
        
    }
    void Update()
    {
        StatRegeneration();
    }
    public void StatRegeneration()
    {
        if (Input.GetMouseButtonDown(0)==true)
        {
            Health -= 15f;
        }

        if (Health<MaxHealth)
        {
            Health += HealthRegeneration*Time.deltaTime;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}