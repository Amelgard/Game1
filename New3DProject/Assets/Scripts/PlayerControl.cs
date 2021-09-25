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
            //  Work, but bad!
            /*int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit hit1, hit2;
            ;
            Physics.Raycast(thisObject.transform.position, Vector3.back, out hit2, 0.25f);
            if (Input.GetAxis("Vertical") > 0 &&
                (!Physics.Raycast(thisObject.transform.position + new Vector3(0.25f, -0.15f, 0), Vector3.forward, out hit1, 0.26f, layerMask) &&
                !Physics.Raycast(thisObject.transform.position - new Vector3(0.25f, 0.15f, 0), Vector3.forward, out hit2, 0.26f, layerMask)))
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed);
            if (Input.GetAxis("Vertical") < 0 &&
                (!Physics.Raycast(thisObject.transform.position + new Vector3(0.25f, -0.15f, 0), Vector3.back, out hit1, 0.26f, layerMask) &&
                !Physics.Raycast(thisObject.transform.position - new Vector3(0.25f, 0.15f, 0), Vector3.back, out hit2, 0.26f, layerMask)))
                thisObject.transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * objectSpeed);
            if (Input.GetAxis("Horizontal") > 0 &&
                (!Physics.Raycast(thisObject.transform.position + new Vector3(0, -0.15f, 0.25f), Vector3.right, out hit1, 0.26f, layerMask) &&
                !Physics.Raycast(thisObject.transform.position - new Vector3(0, 0.15f, 0.25f), Vector3.right, out hit2, 0.26f, layerMask)))
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed, 0, 0);
            if (Input.GetAxis("Horizontal") < 0 &&
                (!Physics.Raycast(thisObject.transform.position + new Vector3(0, -0.15f, 0.25f), Vector3.left, out hit1, 0.26f, layerMask) &&
                !Physics.Raycast(thisObject.transform.position - new Vector3(0, 0.15f, 0.25f), Vector3.left, out hit2, 0.26f, layerMask)))
                thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * objectSpeed, 0, 0);*/
            thisObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * objectSpeed * Time.deltaTime;
        }
    }
}
