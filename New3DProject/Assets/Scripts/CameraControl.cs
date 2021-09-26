using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 mousePos;
    private GameObject Camera;
    private void Awake()
    {
        FindCamera();
    }
    private void FindCamera()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void CameraMover(GameObject cameraTarget, float cameraSpeed, Vector3 cameraOffset, float maxDistenceToObject)
    {
        Vector3 cameraMove = new Vector3(0, 0, 0);
        float targetSize = cameraTarget.transform.lossyScale.x;
        Vector3 newCameraCenter = Camera.transform.position - cameraOffset * targetSize;
        maxDistenceToObject *= targetSize;
        cameraMove.x = CameraMoveOnOneAxis(cameraMove.x, cameraTarget.transform.position.x, cameraSpeed, newCameraCenter.x, maxDistenceToObject, targetSize);
        cameraMove.z = CameraMoveOnOneAxis(cameraMove.z, cameraTarget.transform.position.z, cameraSpeed, newCameraCenter.z, maxDistenceToObject, targetSize);
        cameraMove.y = CameraMoveOnOneAxis(cameraMove.y, cameraTarget.transform.position.y, cameraSpeed, newCameraCenter.y, maxDistenceToObject, targetSize);
        Camera.transform.position += cameraMove;
    }
    private float CameraMoveOnOneAxis(float cameraMove, float cameraTarget, float cameraSpeed, float newCameraCenter, float maxDistenceToObject, float targetSize)
    {
        if (cameraTarget != newCameraCenter)
        {
            if (Mathf.Abs(cameraTarget - newCameraCenter) > 0.01f * targetSize)
            {
                if (cameraTarget < newCameraCenter)
                {
                    if (Mathf.Abs(cameraTarget - newCameraCenter) <= maxDistenceToObject)
                        cameraMove = -cameraSpeed * Time.deltaTime * targetSize;
                    else
                        cameraMove = cameraTarget - newCameraCenter + maxDistenceToObject;
                }
                else
                {
                    if (Mathf.Abs(cameraTarget - newCameraCenter) <= maxDistenceToObject)
                        cameraMove = cameraSpeed * Time.deltaTime * targetSize;
                    else
                        cameraMove = cameraTarget - newCameraCenter - maxDistenceToObject;
                }
            }
            else
                cameraMove = cameraTarget - newCameraCenter;
        }
        return cameraMove;
    }
    private void ObjectTransparency()
    {

    }
}
