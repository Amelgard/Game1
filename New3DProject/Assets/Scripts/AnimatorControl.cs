using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private int dir;
    private bool isMoving;
    private float lastPosX, lastPosZ;
    private void Awake()
    {
        PositionRefresh();
    }
    private void Update()
    {
        isMoving = MoveCheck();
        DirCheck();
        ControlAnimation();
        PositionRefresh();
    }
    private void ControlAnimation()
    {
        gameObject.GetComponent<Animator>().SetInteger("dir", dir);
        gameObject.GetComponent<Animator>().SetBool("isMoving", isMoving);
    }
    private void DirCheck() 
    {
        if (isMoving)
        {
            if (lastPosX != gameObject.transform.position.x)
            {
                if (Mathf.Abs(lastPosX - gameObject.transform.position.x) > 0.025f) 
                {
                    if (gameObject.transform.position.x > lastPosX) // move right
                        dir = 3;
                    else                                            // move left
                        dir = 1; 
                }
            }
            else
            {
                if (Mathf.Abs(lastPosZ - gameObject.transform.position.z) > 0.025f)
                {
                    if (gameObject.transform.position.z > lastPosZ) // move up
                        dir = 2;
                    else                                            // move down
                        dir = 0;
                }
            }
        }
    }
    private void PositionRefresh() //must be called on end of script
    {
        lastPosX = gameObject.transform.position.x;
        lastPosZ = gameObject.transform.position.z;
    }

    private bool MoveCheck()
    {
        bool m_isMoving;
        if (lastPosX != gameObject.transform.position.x ||
            lastPosZ != gameObject.transform.position.z)
            m_isMoving = true;
        else
            m_isMoving = false;
        return m_isMoving;
    }
}
