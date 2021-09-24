using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject Camera;
    private void Awake()
    {
        FindCamera();
    }
    private void FindCamera()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void CameraMover(GameObject cameraTarget, float cameraSpeed, float distenceToObject, float maxDistenceToObject)
    {
        Vector3 cameraMove = new Vector3(0, 0, 0);
        if (distenceToObject < maxDistenceToObject)
        {
            distenceToObject = maxDistenceToObject;
        }
        Vector3 newCameraCenter = Camera.transform.position + new Vector3(0, 0, distenceToObject);
        if (cameraTarget.transform.position.x != Camera.transform.position.x)
        {
            if (Mathf.Abs(cameraTarget.transform.position.x - Camera.transform.position.x) > 0.01f)
            {
                if (cameraTarget.transform.position.x < Camera.transform.position.x) // target move left
                {
                    if (Mathf.Abs(cameraTarget.transform.position.x - Camera.transform.position.x) <= maxDistenceToObject)
                        cameraMove.x = -cameraSpeed * Time.deltaTime;
                    else
                        cameraMove.x = cameraTarget.transform.position.x - Camera.transform.position.x + maxDistenceToObject;
                }
                else                                                                // target move right
                {
                    if (Mathf.Abs(cameraTarget.transform.position.x - Camera.transform.position.x) <= maxDistenceToObject)
                        cameraMove.x = cameraSpeed * Time.deltaTime;
                    else
                        cameraMove.x = cameraTarget.transform.position.x - Camera.transform.position.x - maxDistenceToObject;
                }
            }
            else
                cameraMove.x = cameraTarget.transform.position.x - Camera.transform.position.x;
        }
        if (cameraTarget.transform.position.z != newCameraCenter.z)
        {
            if (Mathf.Abs(cameraTarget.transform.position.z - newCameraCenter.z) > 0.01f)
            {
                if (cameraTarget.transform.position.z < newCameraCenter.z) // target move left
                {
                    if (Mathf.Abs(cameraTarget.transform.position.z - newCameraCenter.z) <= maxDistenceToObject)
                        cameraMove.z = -cameraSpeed * Time.deltaTime;
                    else
                        cameraMove.z = cameraTarget.transform.position.z - newCameraCenter.z + maxDistenceToObject;
                }
                else                                                                // target move right
                {
                    if (Mathf.Abs(cameraTarget.transform.position.z - newCameraCenter.z) <= maxDistenceToObject)
                        cameraMove.z = cameraSpeed * Time.deltaTime;
                    else
                        cameraMove.z = cameraTarget.transform.position.z - newCameraCenter.z - maxDistenceToObject;
                }
            }
            else
                cameraMove.z = cameraTarget.transform.position.z - newCameraCenter.z;
        }
        Camera.transform.position += cameraMove;
    }
}
