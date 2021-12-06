using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameItems
{
    public static Item GetItem(int id)
    {
        Item item;
        switch (id)
        {
            //sword
            case 0:
                int damage =  Random.Range(10, 14) ;
                item = new MaleWeaponItem("simpleSword", id, MaleWeaponItem.WeaponType.OneHandSword, "Icons/Weapon/HoboSword", damage, "Prefabs/Weapons/sword");
                return item;
            default:
                Debug.LogError("Item with this Id don't exist!");
                return null;
        }
    }
}
