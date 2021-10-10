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
            GameObject armature = GameObject.Find("/" + thisObject.name + "/Armature");
            float objectScale = thisObject.transform.lossyScale.x;
            Animator anim = armature.GetComponent<Animator>();
            anim.SetBool("isMoving", MoveToDir(objectScale * objectSpeed * Time.deltaTime, thisObject));
        }
    }
    private bool MoveToDir(float m_objectSpeed, GameObject m_thisObject)
    {
        float rotSpeed = 5;
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 45, 0), rotSpeed * Time.deltaTime);
                    //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(45, m_thisObject));
                    return true;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 315, 0), rotSpeed * Time.deltaTime);
                    //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(315, m_thisObject));
                    return true;
                }
                m_thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 0, 0), rotSpeed * Time.deltaTime);
                //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(360, m_thisObject));
                return true;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 135, 0), rotSpeed * Time.deltaTime);
                    //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(135, m_thisObject));
                    return true;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                    m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 225, 0), rotSpeed * Time.deltaTime);
                    //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(225, m_thisObject));
                    return true;
                }
                m_thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed;
                m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 180, 0), rotSpeed * Time.deltaTime);
                //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(180, m_thisObject));
                return true;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
                m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 90, 0), rotSpeed * Time.deltaTime);
                //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(90, m_thisObject));
                return true;
            }
            else
            {
                m_thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
                m_thisObject.transform.rotation = Quaternion.Slerp(m_thisObject.transform.rotation, Quaternion.Euler(0, 270, 0), rotSpeed * Time.deltaTime);
                //m_thisObject.transform.rotation = Quaternion.Euler(RotateTo(270, m_thisObject));
                return true;
            }
        }
        else
            return false;
    }
}
