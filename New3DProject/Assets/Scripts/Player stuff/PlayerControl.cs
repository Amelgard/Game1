using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 lastPlayerPos;
    private float lastDir;
    public float test1, test2;
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
            Vector3 mouseGlobalPos = GetMousePosition(thisObject.transform.position.y);
            float angle = AngleToObject(thisObject.transform.position, mouseGlobalPos);
            Vector3 move = MoveToDir(objectScale * objectSpeed, armature, angle);
            move.x -= rb.velocity.x;
            move.z -= rb.velocity.z;
            rb.velocity += move;
            MoveAnimation(anim, angle, thisObject.transform.position);
            //              Test zone!
            if (Input.GetKeyDown(KeyCode.E))
                selectedWeapon.ChangeWeapon("sword" ,thisObject, objectScale, anim);
            if (Input.GetKeyDown(KeyCode.R))
                selectedWeapon.ChangeWeapon("hand", thisObject, objectScale, anim);
        }
    }
    private Vector3 MoveToDir(float m_objectSpeed, GameObject m_armature, float RotateAngle)
    {
        float rotSpeed = 2.5f;
        m_armature.transform.rotation = Quaternion.Slerp(m_armature.transform.rotation, Quaternion.Euler(-90, RotateAngle, 0), rotSpeed * Time.deltaTime);
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                if (Input.GetAxis("Horizontal") < 0)
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                return new Vector3(0, 0, Input.GetAxis("Vertical") * m_objectSpeed);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                if (Input.GetAxis("Horizontal") < 0)
                    return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * m_objectSpeed;
                return new Vector3(0, 0, Input.GetAxis("Vertical")) * m_objectSpeed; ;
            }
            if (Input.GetAxis("Horizontal") > 0)
                return new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
            if (Input.GetAxis("Horizontal") < 0)
                return new Vector3(Input.GetAxis("Horizontal"), 0, 0) * m_objectSpeed;
            return new Vector3(0, 0, 0);
        }
        else
            return new Vector3(0, 0, 0);
    }
    private Vector3 GetMousePosition(float playerY)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos;
        if (Physics.Raycast(ray, out RaycastHit hit))
        { }
        mousePos = new Vector3 (hit.point.x, playerY, hit.point.z);
        return mousePos;
    }
    private float AngleToObject(Vector3 player, Vector3 Object)
    {
        float m_angle = -Mathf.Atan2(Object.z - player.z, Object.x - player.x) * Mathf.Rad2Deg;
        m_angle += 90;
        if (m_angle < 0)
            m_angle += 360;
        return m_angle;
    }
    private void MoveAnimation(Animator m_anim, float m_angle, Vector3 playerPos)
    {
        float moveDir = lastDir;
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            if (playerPos != lastPlayerPos)
            {
                moveDir = AngleToObject(lastPlayerPos, playerPos) - m_angle;
                if (moveDir < 0)
                    moveDir += 360;
            }
            m_anim.SetBool("isMoving", true);
            if (moveDir >= 135 && moveDir <= 225)// back
            {
                m_anim.SetInteger("moveDir", 3);
            }
            else if (moveDir > 225 && moveDir < 335)//left
            {
                m_anim.SetInteger("moveDir", 4);
            }
            else if (moveDir > 45 && moveDir < 115)// right
            {
                m_anim.SetInteger("moveDir", 2);
            }
            else if (moveDir >= 315 || moveDir <= 45)// forvard
            {
                m_anim.SetInteger("moveDir", 1);
            }

        }
        else
            m_anim.SetBool("isMoving", false);
        lastDir = moveDir;
        lastPlayerPos = playerPos;
    }
}
