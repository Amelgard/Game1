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
        if(thisObject != null)
            thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * objectSpeed * Time.deltaTime; ;
    }
}
