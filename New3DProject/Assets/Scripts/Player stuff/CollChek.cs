using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollChek : MonoBehaviour
{
    public bool IsForwardBlocked()
    {
        bool isForwardBlocked = gameObject.transform.Find("wallForvardTrigger").gameObject.GetComponent<OnTrigger>().onTrigger;
        return isForwardBlocked;
    }
    public bool IsBackBlocked()
    {
        bool isBackBlocked = gameObject.transform.Find("wallBackTrigger").gameObject.GetComponent<OnTrigger>().onTrigger;
        return isBackBlocked;
    }
    public bool IsLeftBlocked()
    {
        bool isLeftBlocked = gameObject.transform.Find("wallLeftTrigger").gameObject.GetComponent<OnTrigger>().onTrigger;
        return isLeftBlocked;
    }
    public bool IsRightBlocked()
    {
        bool isRightBlocked = gameObject.transform.Find("wallRightTrigger").gameObject.GetComponent<OnTrigger>().onTrigger;
        return isRightBlocked;
    }
}
