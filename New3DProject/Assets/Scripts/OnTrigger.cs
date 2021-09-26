using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public bool onTrigger;
    private void Awake()
    {
        onTrigger = false;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        onTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }
}
