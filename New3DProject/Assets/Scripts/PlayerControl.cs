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
            CollChek blockChek = thisObject.GetComponent<CollChek>();
            AnimatorControl anim = thisObject.GetComponent<AnimatorControl>();
            bool isMoving = false;
            float objectScale = thisObject.transform.lossyScale.x;
            if (Input.GetAxis("Vertical") > 0 && !blockChek.IsForwardBlocked())
            {
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed * objectScale);
                anim.dir = 2;
                isMoving = true;
            }
            if (Input.GetAxis("Vertical") < 0 && !blockChek.IsBackBlocked())
            {
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed * objectScale);
                anim.dir = 0;
                isMoving = true;
            }
            if (Input.GetAxis("Horizontal") > 0 && !blockChek.IsLeftBlocked())
            {
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed * objectScale, 0, 0);
                anim.dir = 3;
                isMoving = true;
            }
            if (Input.GetAxis("Horizontal") < 0 && !blockChek.IsRightBlocked())
            {
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed * objectScale, 0, 0);
                anim.dir = 1;
                isMoving = true;
            }
            anim.isMoving = isMoving;
        }
    }
}
