using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWeapon : MonoBehaviour
{
    public GameObject selectedWeapon;
    public Vector3 test; // for debuging weapon position with create
    public void GiveWeapon(string weaponName)
    {
        
    }
    public void ChangeWeapon(string weaponName, GameObject thisObject, float objectScale)
    {
        GameObject hand = thisObject.transform.Find("Armature/mainBone/armIK.R/arm3.R").gameObject;
        switch (weaponName)
        {
            case "hand":
                if (selectedWeapon != null)
                    Destroy(selectedWeapon);
                break;
            case "sword":
                if (selectedWeapon != null)
                    Destroy(selectedWeapon);
                selectedWeapon = Instantiate(Resources.Load<GameObject>("Prefabs/Weapons/sword"), hand.transform);
                selectedWeapon.transform.position += new Vector3(0.05f, -0.02f, 0.03f) * objectScale;
                selectedWeapon.transform.Rotate(Vector3.right, 90f);
                selectedWeapon.transform.Rotate(Vector3.up, 90f);
                break;
        }
    }
}
