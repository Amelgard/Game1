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
            CollChek collChek = thisObject.GetComponent("CollChek") as CollChek;
            float objectScale = thisObject.transform.lossyScale.x;
            Animator anim = armature.GetComponent<Animator>();
            anim.SetBool("isMoving", MoveToDir(objectScale * objectSpeed * Time.deltaTime, thisObject, armature, collChek));
        }
    }
    private bool MoveToDir(float m_objectSpeed, GameObject m_thisObject, GameObject m_armature, CollChek m_collChek)
    {
        
        float rotSpeed = 5;
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            if (Input.GetAxis("Vertical") > 0 && !m_collChek.IsForwardBlocked())
            {
                if (Input.GetAxis("Horizontal") > 0 && !m_collChek.IsRightBlocked())
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 45, 0), rotSpeed * Time.deltaTime);
                    return true;
                }
                if (Input.GetAxis("Horizontal") < 0 && !m_collChek.IsLeftBlocked())
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 315, 0), rotSpeed * Time.deltaTime);
                    return true;
                }
                m_thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 0, 0), rotSpeed * Time.deltaTime);
                return true;
            }
            if (Input.GetAxis("Vertical") < 0 && !m_collChek.IsBackBlocked())
            {
                if (Input.GetAxis("Horizontal") > 0 && !m_collChek.IsRightBlocked())
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 135, 0), rotSpeed * Time.deltaTime);
                    return true;
                }
                if (Input.GetAxis("Horizontal") < 0 && !m_collChek.IsLeftBlocked())
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 225, 0), rotSpeed * Time.deltaTime);
                    return true;
                }
                m_thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 180, 0), rotSpeed * Time.deltaTime);
                return true;
            }
            if (Input.GetAxis("Horizontal") > 0 && !m_collChek.IsRightBlocked())
            {
                m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 90, 0), rotSpeed * Time.deltaTime);
                return true;
            }
            if (Input.GetAxis("Horizontal") < 0 && !m_collChek.IsLeftBlocked())
            {
                m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
                m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, 270, 0), rotSpeed * Time.deltaTime);
                return true;
            }
            return false;
        }
        else
            return false;
    }
}
