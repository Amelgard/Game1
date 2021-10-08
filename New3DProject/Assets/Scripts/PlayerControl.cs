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
            //CollChek blockChek = thisObject.GetComponent<CollChek>();
            GameObject armature = GameObject.Find("/" + thisObject.name + "/Armature");
            AnimatorControl anim = armature.GetComponent<AnimatorControl>();
            bool isMoving = false;
            float objectScale = thisObject.transform.lossyScale.x;
            if (Input.GetAxis("Vertical") > 0 /*&& !blockChek.IsForwardBlocked()*/)
            {
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed * objectScale);
                thisObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                isMoving = true;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed * objectScale);
                thisObject.transform.rotation = Quaternion.Euler(new Vector3 (0, 180, 0));
                isMoving = true;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed * objectScale, 0, 0);
                thisObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                isMoving = true;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed * objectScale, 0, 0);
                thisObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                isMoving = true;
            }
            //anim.isMoving = isMoving;
        }
    }
}
