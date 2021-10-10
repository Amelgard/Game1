using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManipulate : MonoBehaviour
{
    public int staminaRegenSpeed, manaRegenSpeed, helthRegenSpeed;
    private float lastStamina, lastMana, lastHelth;
    private float staminaRegenDelay, manaRegenDelay, helthRegenDelay;

    public float StaminaRecavery(float stat, int maxStat, float regenDelay)
    {
        if (stat < lastStamina)
            staminaRegenDelay = 0;
        if (staminaRegenDelay < regenDelay) // time to stamina regen
            staminaRegenDelay += 1 * Time.deltaTime;
        else
        {
            staminaRegenDelay = regenDelay; // time to stamina regen
            if (stat < maxStat)
                stat += staminaRegenSpeed * Time.deltaTime;
            else
                stat = maxStat;
        }
        lastStamina = stat;
        return stat;
    }
    public float ManaRecavery(float stat, int maxStat, float regenDelay)
    {
        if (stat < lastMana)
            manaRegenDelay = 0;
        if (manaRegenDelay < regenDelay) // time to stamina regen
            manaRegenDelay += 1 * Time.deltaTime;
        else
        {
            manaRegenDelay = regenDelay; // time to stamina regen
            if (stat < maxStat)
                stat += manaRegenSpeed * Time.deltaTime;
            else
                stat = maxStat;
        }
        lastMana = stat;
        return stat;
    }
    public float HelthRecavery(float stat, int maxStat, float regenDelay)
    {
        if (stat < lastHelth)
            helthRegenDelay = 0;
        if (helthRegenDelay < regenDelay) // time to stamina regen
            helthRegenDelay += 1 * Time.deltaTime;
        else
        {
            helthRegenDelay = regenDelay; // time to stamina regen
            if (stat < maxStat)
                stat += helthRegenSpeed * Time.deltaTime;
            else
                stat = maxStat;
        }
        lastHelth = stat;
        return stat;
    }
}
