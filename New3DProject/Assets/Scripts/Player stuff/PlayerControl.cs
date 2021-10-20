using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject FindPlayer()
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
    public void ObjectMover(GameObject thisObject, float objectSpeed)
    {
        if (thisObject != null)
        {
            GameObject armature = thisObject.transform.Find("Armature").gameObject;
            float objectScale = thisObject.transform.lossyScale.x;
            Animator anim = armature.GetComponent<Animator>();
            Rigidbody rb = thisObject.GetComponent<Rigidbody>();
            SelectedWeapon selectedWeapon = thisObject.GetComponent("SelectedWeapon") as SelectedWeapon;
            Vector3 move = MoveToDir(objectScale * objectSpeed, armature);
            move.x -= rb.velocity.x;
            move.z -= rb.velocity.z;
            rb.velocity += move;
            if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
                anim.SetBool("isMoving", true);
            else
                anim.SetBool("isMoving", false);
            if (Input.GetKeyDown(KeyCode.E))
                selectedWeapon.ChangeWeapon("sword" ,thisObject, objectScale, anim);
            if (Input.GetKeyDown(KeyCode.R))
                selectedWeapon.ChangeWeapon("hand", thisObject, objectScale, anim);
        }
    }
    private Vector3 MoveToDir(float m_objectSpeed, GameObject m_armature)
    {
        float rotSpeed = 5;
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 45, 0), rotSpeed * Time.deltaTime);
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 315, 0), rotSpeed * Time.deltaTime);
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed; ;
                }
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 0, 0), rotSpeed * Time.deltaTime);
                return new Vector3 (0, 0, Input.GetAxis("Vertical") * m_objectSpeed);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 135, 0), rotSpeed * Time.deltaTime);
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed; ;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 225, 0), rotSpeed * Time.deltaTime);
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                }
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 180, 0), rotSpeed * Time.deltaTime);
                return new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed; ;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 90, 0), rotSpeed * Time.deltaTime);
                return new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 270, 0), rotSpeed * Time.deltaTime);
                return new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
            }
            return new Vector3(0, 0, 0);
        }
        else
            return new Vector3(0, 0, 0);
    }
}
