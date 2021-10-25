using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject emp1, emp2;
    private Vector3 lastPlayerPos;
    private float lastDir, timer = 0.2f;
    public float test;
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
            anim.SetInteger("attackDir", Attack(thisObject, mouseGlobalPos));
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
    private int Attack(GameObject player, Vector3 m_mouseGlobalPos)
    {
        // 1= руб 2 =прав-лев 3=кол 4=лев-прав
        int att = 0;
        if (emp1 != null)
        {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
            {
                emp2 = Instantiate(Resources.Load<GameObject>("Prefabs/Empty"), m_mouseGlobalPos, new Quaternion(0, 0, 0, 0));
                emp2.transform.LookAt(player.transform.position);
                emp1.transform.LookAt(player.transform.position);
                float rot1 = emp1.transform.eulerAngles.y - emp2.transform.eulerAngles.y;
                Vector3 pos1 = emp1.transform.position - player.transform.position;
                Vector3 pos2 = emp2.transform.position - player.transform.position;

                //if()
                test = rot1;
                if (rot1 > -25 && rot1 < 25)
                {
                    if (Mathf.Abs(pos1.x - pos2.x) > Mathf.Abs(pos1.z - pos2.z))
                    {
                        if (Mathf.Abs(pos1.x) > Mathf.Abs(pos2.x))
                            att = 3;
                        else
                            att = 1;
                    }
                    else
                    {
                        if (Mathf.Abs(pos1.z) > Mathf.Abs(pos2.z))
                            att = 3;
                        else
                            att = 1;
                    }
                }
                else if (rot1 > 0)
                    att = 2;
                else
                    att = 4;
                SelectedWeapon m_selectedWeapon = player.GetComponent("SelectedWeapon") as SelectedWeapon;
                WeaponAttak weaponAttak = m_selectedWeapon.selectedWeapon.GetComponent("WeaponAttak") as WeaponAttak;
                weaponAttak.Attak();
                Destroy(emp1);
                Destroy(emp2);
                timer = 0.2f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            emp1 = Instantiate(Resources.Load<GameObject>("Prefabs/Empty"), m_mouseGlobalPos, new Quaternion(0, 0, 0, 0));
        }
        return att;
    }
    private Vector3 GetMousePosition(float playerY)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 mousePos;
        if (Physics.Raycast(ray, out hit))
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
