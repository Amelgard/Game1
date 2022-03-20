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
        Abilities();
        death();
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
