using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript3D : MonoBehaviour
{


    public float speed;
    private GameObject Cube;
    


    void Start()
    {
        speed = 2f;
    }

    
    void Update()
    {
        move();
        FindObject();
    }




    void move()
    {
        


        if (Input.GetAxis("Vertical")!= 0)
        {

            if (Input.GetAxis("Vertical") == 1)
            {

                Cube.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            }
            if (Input.GetAxis("Vertical") == -1)
            {

                Cube.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            }


            transform.position += new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

            
        }

        if (Input.GetAxis("Horizontal")!= 0)
        {


            if (Input.GetAxis("Horizontal") == 1)
            {

                Cube.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

            }
            if (Input.GetAxis("Horizontal") == -1)
            {

                Cube.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

            }

            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);

        }
    }

    void FindObject()
    {

        Cube = GameObject.Find("TestCube");

    }
}
