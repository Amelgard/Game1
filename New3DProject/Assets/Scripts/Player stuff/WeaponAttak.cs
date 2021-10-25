using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttak : MonoBehaviour
{
    private bool isAttaking;
    public void Attak()
    {
        isAttaking = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Mob" || other.tag == "Player") && isAttaking) 
        {
            isAttaking = false;
            ObjectStats objectStats = other.GetComponent("ObjectStats") as ObjectStats;
            objectStats.TakeDamage(25); 
        }
    }
}
