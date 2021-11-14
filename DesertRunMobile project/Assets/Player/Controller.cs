using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Camera currentCamera;
    ObjectDirector objectDirector;
    private Rigidbody2D rb;
    private CameraBorder cameraBorder;
    private byte horSpeed = 5;
    private void Start()
    {
        objectDirector = gameObject.GetComponent("ObjectDirector") as ObjectDirector;
        currentCamera = Camera.main;
        cameraBorder = new CameraBorder(currentCamera, 50, 50, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        transform.position = currentCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/3.5f, 8));
    }
    void Update()
    {
        ObjectMover();
    }
    void ObjectMover()
    {
        if (Input.touches.Length > 0)
        {
            var direction = (Vector2)(currentCamera.ScreenToWorldPoint(Input.touches[0].position) - transform.position);
            rb.velocity = new Vector2(Mathf.Clamp(direction.x, -1, 1) * horSpeed, 0);
            if ((transform.position.x > cameraBorder.RightBorder && rb.velocity.x > 0)
                || (transform.position.x < cameraBorder.LeftBorder && rb.velocity.x < 0))
                rb.velocity = Vector2.zero;
        }
        else
        {
            if (transform.position.x > cameraBorder.RightBorder)
                rb.velocity = Vector2.right * -Mathf.Abs(rb.velocity.x);
            else if (transform.position.x < cameraBorder.LeftBorder)
                rb.velocity = Vector2.right * Mathf.Abs(rb.velocity.x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // dead
        if (collision.gameObject.tag == "Obstacle")
        {
            objectDirector.verSpeed = 0;
            horSpeed = 0;
        }
    }

}
