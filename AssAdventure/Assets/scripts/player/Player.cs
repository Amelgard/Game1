using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameObject _PS;

    void Start()
    {
        _PS= GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        movement();
        Abilities();
        death();
    }
    public void movement()
    {
        _PS.gameObject.transform.Translate(movementVector * _PS.GetComponent<PlayerStats>().Speed*Time.fixedDeltaTime);
    }
    private Vector3 movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }
    public void Abilities()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _PS.GetComponent<PlayerStats>().Health -= 15f;
        }
    }
    public void death()
    {
        if (_PS.GetComponent<PlayerStats>().Health <= 0)
        {
            Destroy(_PS);
        }
    }
}
