using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public int maxHelth, maxMana, maxStamina, defaultSpeed;
    public float helth, mana, stamina, speed;
    public void TakeDamage(float damage)
    {
        helth -= damage;
        if (helth <= 0)
            Destroy(gameObject);
    }
}
