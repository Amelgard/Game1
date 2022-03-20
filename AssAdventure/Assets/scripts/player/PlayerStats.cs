using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Speed=1.5f;
    public float Health;
    private float MaxHealth = 100f;
    public float Mana;
    private float MaxMana = 100f;
    public float Stamina;
    private float MaxStamina = 100f;

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
        if (Health<MaxHealth)
        {
            Health += HealthRegeneration*Time.deltaTime;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}
