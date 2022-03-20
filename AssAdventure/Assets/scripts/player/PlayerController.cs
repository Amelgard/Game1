using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range (1, 5)]
    private float speed;

    private CharacterController _characterController;

    private void Update()
    {
        _characterController = transform.GetComponent<CharacterController>();
        PlayerMover();
    }

    private void PlayerMover()
    {
        _characterController.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * speed);
    }
}
