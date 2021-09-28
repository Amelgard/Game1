using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    public int dir;
    public bool isMoving;
    private void Update()
    {
        ControlAnimation();
    }
    private void ControlAnimation()
    {
        gameObject.GetComponent<Animator>().SetInteger("dir", dir);
        gameObject.GetComponent<Animator>().SetBool("isMoving", isMoving);
    }
}
