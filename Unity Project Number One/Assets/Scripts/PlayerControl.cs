using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerBody;
    public bool bodyExist;
    public float speed;

    Animator bodyAnimator;

    public float stamina, lastStamina ,staminaRegenDelay;

    private bool isDashing;
    private float dashForceRollback;

    void Start()
    {
        bodyExist = false;
        speed = 1;
        stamina = 100;
        isDashing = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (bodyExist == false)
        {
            TakeNewBody();
        }
        else
        {
            BodyControl();
        }
    }

    void TakeNewBody()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.zero);
        if (hit.collider != null)
        {

            if ((hit.collider.tag == "Body" ) && (Input.GetMouseButtonDown(0)))
            {   
                playerBody = hit.transform.gameObject;
                playerBody.tag = "Player";
                bodyAnimator = playerBody.GetComponent<Animator>();
                bodyExist = true;
            }
        }
    }

    void BodyControl()
    {
        playerBody.transform.position += new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * 2 * speed * Dash() * Time.deltaTime;
        StaminaRecovery();
        AnimControllor();
    }

    void AnimControllor()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
            bodyAnimator.SetBool("isMoving", true);
        else
            bodyAnimator.SetBool("isMoving", false);
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0) // dir 0=up, dir 1=left, dir 2=up, dir 3=right
                bodyAnimator.SetInteger("dir", 1);
            else
                bodyAnimator.SetInteger("dir", 3);
        }
        else 
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") < 0)
                    bodyAnimator.SetInteger("dir", 0);
                else
                    bodyAnimator.SetInteger("dir", 2);
            } 
        }
    }
    void StaminaRecovery()
    {
        if (stamina < lastStamina)
            staminaRegenDelay = 0;
        if (staminaRegenDelay < 2) // time to stamina regen
            staminaRegenDelay += 1 * Time.deltaTime;
        else 
        {
            staminaRegenDelay = 2; // time to stamina regen
            if (stamina < 100)
                stamina += 10 * Time.deltaTime;
            else
                stamina = 100;
        }
        lastStamina = stamina;
    }
    float Dash()
    {
        float dashForce;
        if ((stamina >= 20) && (Input.GetKeyDown(KeyCode.LeftShift)))
        {
            stamina -= 20;
            dashForceRollback = 0;
            isDashing = true;
        }
        if (isDashing)
        {
            dashForce = 2;              //speed bust with dash
            if (dashForceRollback < 0.5f)
                dashForceRollback += 1 * Time.deltaTime;
            else
            {
                dashForceRollback = 0.5f;
                isDashing = false;
            }
        }
        else
            dashForce = 1;
        return dashForce;
    }
}
