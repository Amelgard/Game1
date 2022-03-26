using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats _playerStats;
    void Start()
    {
        _playerStats = gameObject.GetComponent<PlayerStats>();    
    }
   
    void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert= Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horiz,0,vert);
        gameObject.transform.Translate(move * _playerStats.Speed * Time.deltaTime);
    }
}
