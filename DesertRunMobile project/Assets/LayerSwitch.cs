using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -3);
    }
}
