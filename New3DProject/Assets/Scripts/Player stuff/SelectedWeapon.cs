using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWeapon : MonoBehaviour
{
    public GameObject selectedWeapon;
    //public Vector3 test; // for debuging weapon position with create
    public void ChangeWeapon(string weaponName, GameObject thisObject, float objectScale, Animator anim)
    {
        GameObject hand = thisObject.transform.Find("Armature/Hips/Spine/Chest/UpperChest/Shoulder.R/UpperArm.R/LowerArm.R/Hand.R").gameObject;
        switch (weaponName)
        {
            case "hand"://id 0
                if (selectedWeapon != null)
                    Destroy(selectedWeapon);
                anim.SetInteger("selectedWeapon", 0);
                break;
            case "sword"://id 1
                if (selectedWeapon != null)
                    Destroy(selectedWeapon);
                selectedWeapon = Instantiate(Resources.Load<GameObject>("Prefabs/Weapons/sword"), hand.transform);
                selectedWeapon.transform.localPosition += new Vector3(0.03f, 0.06f, -0.06f) * objectScale;
                selectedWeapon.transform.Rotate(Vector3.right, 87);
                selectedWeapon.transform.Rotate(Vector3.up, 90);
                anim.SetInteger("selectedWeapon", 1);
                break;
        }
    }
}
