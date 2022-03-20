using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range (1, 5)]
    private float speed;

    [SerializeField]
    [Range(0, 10)]
    private float rotationSpeed;

    private float _targetRotation = 0;

    private CharacterController _characterController;

    private void Update()
    {
        _characterController = transform.GetComponent<CharacterController>();
        PlayerMover();
    }

    private void PlayerMover()
    {
        var moveDiraction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _characterController.SimpleMove(moveDiraction * speed);

        if(Input.GetAxis("Fire2") != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _targetRotation = Mathf.Atan2(hit.point.x - transform.position.x, hit.point.z - transform.position.z) * Mathf.Rad2Deg;
            }
        }

        else if(moveDiraction != Vector3.zero)
            _targetRotation = Mathf.Atan2(moveDiraction.x, moveDiraction.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation,
                                             Quaternion.Euler(Vector3.up * _targetRotation),
                                             Time.deltaTime * rotationSpeed);
    }
}
